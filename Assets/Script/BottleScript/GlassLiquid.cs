using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassLiquid : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Renderer rend;

    bool filling;
    float timer;

    Color currentColorSide;
    Color currentColorTop;

    float previousLevel;

    [SerializeField]
    private float m_maxLiquid = .6f;
    [SerializeField]
    private float m_minLiquid = .55f;


    public List<Boisson> boissons;
    Boisson currentBoisson;


    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.material.SetFloat("_Fill", m_minLiquid);
        filling = false;
        timer = 0f;
        previousLevel = 0.0f;

        boissons = new List<Boisson>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (filling && timer <= 0.05f)
        {
            timer += Time.deltaTime;

            float level = rend.material.GetFloat("_Fill");
            if (level < m_maxLiquid)
            {
                level += Time.deltaTime * speed;
                if(currentBoisson != null)
                    currentBoisson.volumeInGlass += Time.deltaTime * speed;
                rend.material.SetFloat("_Fill", level);
            }

            if (boissons.Count != 0)
            {
                float red_side = 0, green_side = 0, blue_side = 0;
                float red_top = 0, green_top = 0, blue_top = 0;
                //Moyenne pondérée
                //(Couleur précédente * son volume ) + (couleur actuelle * son volume) / (somme des volumes) 
                foreach (Boisson boisson in boissons)
                {
                    red_side += boisson.sideColor.r * boisson.volumeInGlass;
                    red_top += boisson.topColor.r * boisson.volumeInGlass;

                    green_side += boisson.sideColor.g * boisson.volumeInGlass;
                    green_top += boisson.topColor.g * boisson.volumeInGlass;

                    blue_side += boisson.sideColor.b * boisson.volumeInGlass;
                    blue_top += boisson.topColor.b * boisson.volumeInGlass;
                }

                float totVolume = (rend.material.GetFloat("_Fill") - m_minLiquid);
                red_side = red_side / totVolume;
                green_side = green_side / totVolume;
                blue_side = blue_side / totVolume;

                red_top = red_top / totVolume;
                green_top = green_top / totVolume;
                blue_top = blue_top / totVolume;

                rend.material.SetColor("_SideLiquidColor", new Color(red_side, green_side, blue_side));
                rend.material.SetColor("_SurfaceLiquidColor", new Color(red_top, green_top, blue_top));

                Debug.Log($"Side color :  {new Color(red_side, green_side, blue_side)}");
                Debug.Log($"Top color : {new Color(red_top, green_top, blue_top)}");
            }

        }


    }
    public void fillGlass(Color p_sideColor, Color p_topColor, string p_name)
    {
        currentBoisson = boissons.Find(x => x.name == p_name); 
        if (currentBoisson == null)
        {
            boissons.Add(new Boisson(p_name, p_sideColor, p_topColor));
        }
       
        filling = true;
        timer = 0;
        currentColorSide = p_sideColor;
        currentColorTop = p_topColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject bottle;
    
    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private GameObject PouringLiquid;

    [SerializeField]
    private GameObject Liquid;

    bool isPouring;
    bool isInstantiated;


    GameObject instantiatedPouringLiquid;
    void Start()
    {
        bottle = transform.parent.gameObject;

        StartCoroutine(coroutine_pourLiquid());
        isPouring = false;
        isInstantiated = false;
    }

    private IEnumerator coroutine_pourLiquid()
    {
        WaitForSeconds tmp = new WaitForSeconds(0.05f);
        while (true)
        {
            yield return tmp;
            pourLiquid();
        }
    }

    private void pourLiquid()
    {
        if (((bottle.transform.rotation.eulerAngles.x >= 90 && bottle.transform.rotation.eulerAngles.x <= 270) || 
            (bottle.transform.rotation.eulerAngles.z >= 90 && bottle.transform.rotation.eulerAngles.z <= 270)) && 
            Liquid.GetComponent<Pouring>().getCurrentLevelOfLiquid() > Liquid.GetComponent<Pouring>().getMinLiquid())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layer))
            {
                isPouring = true;
                if (!instantiatedPouringLiquid)
                {
                    instantiatedPouringLiquid = Instantiate(PouringLiquid, transform.position, Quaternion.identity);
                    instantiatedPouringLiquid.transform.SetParent(transform);
                    isInstantiated = true;
                }

                if (instantiatedPouringLiquid)
                {
                    instantiatedPouringLiquid.transform.localScale = new Vector3(instantiatedPouringLiquid.transform.localScale.x, (hit.distance / 2), instantiatedPouringLiquid.transform.localScale.z);
                    if (hit.transform.gameObject.CompareTag("Glass"))
                    {
                        hit.transform.gameObject.GetComponentInChildren<GlassLiquid>().fillGlass(Liquid.GetComponent<Renderer>().material.GetColor("_SideLiquidColor"), Liquid.GetComponent<Renderer>().material.GetColor("_SurfaceLiquidColor"), Liquid.GetComponent<Pouring>().getName());
                    }
                }
            }
        }
        else
        {
            if (instantiatedPouringLiquid)
            {

                Destroy(instantiatedPouringLiquid);
                isInstantiated = false;
            }
            isPouring = false;
        }
    }

    public bool getIsPouring()
    {
        return isPouring;
    }
}

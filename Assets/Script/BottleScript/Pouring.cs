using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject liquid;

    [SerializeField]
    private string m_liquidName;

    [SerializeField]
    private float m_maxLiquid = .639f;

    [SerializeField]
    private float m_minLiquid = .546f;

    Renderer rend; 
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_Fill", m_maxLiquid);
    }

    // Update is called once per frame
    void Update()
    {
        bool isPouring = liquid.GetComponent<PourLiquid>().getIsPouring();
        float level = rend.material.GetFloat("_Fill");
        if (level > m_minLiquid && isPouring)
        {
            level -= Time.deltaTime * speed;
            rend.material.SetFloat("_Fill", level);
        }
    }

    public float getCurrentLevelOfLiquid()
    {
        return rend.material.GetFloat("_Fill");
    }

    public string getName()
    {
        return m_liquidName;
    }

    public float getMinLiquid()
    {
        return m_minLiquid;
    }
}

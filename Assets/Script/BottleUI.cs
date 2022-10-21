using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleUI : MonoBehaviour
{

    [SerializeField]
    private GameObject m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void display()
    {
        m_ui.SetActive(true);
    }

    public void hide()
    {
        m_ui.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuitBtn : MonoBehaviour
{

    public int sceneIndex;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(quitter);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void quitter()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDigit : MonoBehaviour
{
    public float temps = 0f;
    public int sceneIndex;
    //GameObject interfaceDigit;
    void Start()
    {
        StartCoroutine(chronos());
        temps = temps + 1;
    }
    IEnumerator chronos()
    {
        
        while (temps > 0)
        {
            //ValEtatErreurSaisie = GameObject.Find("Digicode").GetComponent(Digicode).ValErreur();
            //Debug.Log(ValEtatErreurSaisie);
            temps = temps - 1;
            yield return new WaitForSeconds(1f);
            GetComponent<Text> ().text = string.Format("{0:0}:{1:00}", Mathf.Floor(temps /60), temps % 60);
        }
        //Debug.Log("PERDU Fin du temps");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        
    }

    
}

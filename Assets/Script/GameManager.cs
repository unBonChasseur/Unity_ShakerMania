using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Visit.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Gestion du temps
    [SerializeField]
    private TimerDigit m_timerDigit;

    // Gestion des points
    private float m_score;

    // Gestion spawn bouteilles aléatoire
    private SpawnManager m_spawnManager;

    // Gestion fin de la partie
    public int sceneIndex= 0;

    private int lastScore = 0;
    [SerializeField]
    private GameObject interfaceScore;
    // Score : Nombre de shake, alcool choisi, nombre d'alcools, soft utilisés, nombre de softs, verre utilisé || glaçons ? petit palmier ? 
    // Choix de 10 bouteilles(Vodka, rhum, malibu, martini, jager, havana, crema, cointreau, chivas, baileys), 4 aléatoires d'alcool sur le bar 
    // 4 soft(coca, jus d'orange, jus de pomme, limonade)
    [SerializeField]
    private string[] beverage_name;
    [SerializeField]
    private float[] scoreByAlcool = { };

    [SerializeField]
    private GameObject glass;

    public float score;

    void Start()
    {
        m_spawnManager = GetComponent<SpawnManager>();
        interfaceScore.GetComponent<Text>().text = score.ToString();
        lastScore = PlayerPrefs.GetInt("Score");
        StartNewGame();

    }
    private void Update()
    {
        if (m_timerDigit.temps == 0)
        {
            List<Boisson> finalBoisson = glass.GetComponent<GlassLiquid>().boissons;
            foreach (Boisson boisson in finalBoisson)
            {
                for (int i = 0; i < beverage_name.Length; i++)
                {
                    if (boisson.name == beverage_name[i])
                    {
                        score += (boisson.volumeInGlass * 10) * scoreByAlcool[i];
                        PlayerPrefs.SetFloat("Score", score);
                    }
                }
            }
        }
    }

    //void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
    //}


    private IEnumerator StartNewGame()
    {
        yield return new WaitForSeconds(.1f); 
        m_spawnManager.InitializeSpawn();
        string score = PlayerPrefs.HasKey("Score") ? PlayerPrefs.GetFloat("Score").ToString() : "0";
        interfaceScore.GetComponent<Text>().text = "Previous Score : " + score;
        // Cacher les UI
        // Vérifier la génération des Objets randoms --> pas de duplicatat
        // Démarrer le chrono
    }


}

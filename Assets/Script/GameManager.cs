using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Visit.Random;

public class GameManager : MonoBehaviour
{
    // Gestion du temps

    // Gestion des points
    

    // Gestion spawn bouteilles aléatoire
    private SpawnManager m_spawnManager;

    // Gestion fin de la partie


    // Score : Nombre de shake, alcool choisi, nombre d'alcools, soft utilisés, nombre de softs, verre utilisé || glaçons ? petit palmier ? 
    // Choix de 10 bouteilles(Vodka, rhum, malibu, martini, jager, havana, crema, cointreau, chivas, baileys), 4 aléatoires d'alcool sur le bar 
    // 4 soft(coca, jus d'orange, jus de pomme, limonade)

    void Start()
    {
        m_spawnManager = GetComponent<SpawnManager>();
    }

    private void StartNewGame()
    {
        m_spawnManager.InitializeSpawn();
        // Cacher les UI
        // Vérifier la génération des Objets randoms --> pas de duplicatat
        // Démarrer le chrono
    }

    private void FinishGame()
    {
        string textFinal = "";
        //if(!verre.m_isVide && timer != 0)
        //foreach( boisson in Verre)
        // Afficher UI de fin de jeu + zone de texte avec {{{{ Nom de la boisson : Score }}} Malus : Mauvais dosage / Mauvais mélange d'alcool / Manque soft / Manque alcool / Pas de mélange
        // Si chrono = 0 -->  score = 0 : client insatisfait !
    }
}

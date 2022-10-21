using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Visit.Random;

public class SpawnManager : MonoBehaviour
{
    public RandomGameObject[] m_randomBottles;
    public GameObject[] m_spawnObjects;


    // Start is called before the first frame update
    public void InitializeSpawn()
    {
        m_randomBottles = GetComponents<RandomGameObject>();

        string[] names = new string[m_randomBottles.Length];
        for (int i = 0; i < m_randomBottles.Length; i++)
        {
            m_randomBottles[i].ReplaceByRandomObject();
            for(int j = 0; j < i; j++)
            {
                if(m_randomBottles[i].name == m_randomBottles[j].name)
                {
                    m_randomBottles[i].ReplaceByRandomObject();
                    j = 0;
                }
            }

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boisson : IComparable<Boisson>
{
    // Start is called before the first frame update
    public string name;
    public float volumeInGlass;
    public Color sideColor;
    public Color topColor;

    public Boisson(string p_name, Color p_sideColor, Color p_topColor)
    {
        name = p_name;
        sideColor = p_sideColor;
        topColor = p_topColor;
    }

    public int CompareTo(Boisson other)
    {
        if(other == null)
        {
            return 0;
        }
        if (volumeInGlass > other.volumeInGlass)
        {
            return 1; 
        }
        else if (volumeInGlass <= other.volumeInGlass)
        {
            return -1;
        }

        return 0;
    }
}

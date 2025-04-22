using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorContainer", menuName = "ColorContainer")]
public class ColorsConteiner : ScriptableObject
{
    public List<Material> ColorsList = new List<Material>();

    private static ColorsConteiner _instance;


    public static ColorsConteiner Instance
    {
        get 
        { 
            if( _instance == null)
            {
                _instance = Resources.Load<ColorsConteiner>("ColorContainer");
            }
                
            return _instance; 
        }
    }

    public int GetColorCount()
    {
        return ColorsList.Count;
    }

    public Material GetColor(int index)
    {
        if (index < ColorsList.Count)
        {
            return ColorsList[index];
        }

        return ColorsList[0];
    }
}

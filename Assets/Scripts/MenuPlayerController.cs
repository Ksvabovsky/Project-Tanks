using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MenuPlayerController : MonoBehaviour
{
    public MeshRenderer forkliftMats;

    public ColorsConteiner ColorsList;

    public int CurrentColor = 0;

    public PlayerInputController inputs;

    // Start is called before the first frame update
    void Start()
    {
        ColorsList = ColorsConteiner.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerInit(PlayerInputController i)
    {
        inputs = i;
        inputs.changeColorNext += ChangeColorNext;
        inputs.changeColorPrevious += ChangeColorPrevious;
    }

    public void ChangeColorNext()
    {
        List<Material> materials = new List<Material>();
        forkliftMats.GetMaterials(materials);

        int colorsCount = ColorsList.GetColorCount();

        CurrentColor++;
        if(CurrentColor >= colorsCount)
        {
            CurrentColor = 0;
        }

        materials[1] = ColorsList.GetColor(CurrentColor);
        forkliftMats.SetMaterials(materials);
    }

    public void ChangeColorPrevious()
    {
        List<Material> materials = new List<Material>();
        forkliftMats.GetMaterials(materials);

        int colorsCount = ColorsList.GetColorCount();

        CurrentColor--;
        if (CurrentColor < 0)
        {
            CurrentColor = colorsCount-1;
        }

        materials[1] = ColorsList.GetColor(CurrentColor);
        forkliftMats.SetMaterials(materials);
    }
}

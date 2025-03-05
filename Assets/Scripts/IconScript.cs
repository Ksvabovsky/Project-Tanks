using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconScript : MonoBehaviour
{
    public Image icon;
    public TMP_Text icon_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIcon(Color color, string text)
    {
        icon.color = color;
        icon_text.text = text;
    }
}

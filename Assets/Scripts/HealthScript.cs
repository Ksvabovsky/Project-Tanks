using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    float startHP;
    [SerializeField]
    float maxHP;
    [SerializeField]
    float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = startHP;
    }

    public float GetHP()
    {
        return currentHP;
    }

    public void GetDamage(float dmg)
    {
        currentHP = -dmg;

        if(currentHP <= 0) {
            TimeToDIE();
        }
    }

    void TimeToDIE()
    {

    }

}

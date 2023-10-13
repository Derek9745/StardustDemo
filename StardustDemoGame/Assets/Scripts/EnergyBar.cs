using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Image fill;
    public int EnergyLevel = 0;
    public int currentEnergy;
    public Rigidbody rb;
    public HealthBar healthBar;
    void Start()
    {
        currentEnergy = EnergyLevel;
        healthBar.SetMaxHealth(20);
    }

    void Update()
    {
        if (EnergyLevel == 20)
        {

        }
    }

   
}

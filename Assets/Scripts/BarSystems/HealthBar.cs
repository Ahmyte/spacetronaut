using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour{

    public Slider HealthVaule;
    public PlayerNeedSystems playerNeedSystems;
    [SerializeField] Image image;

    private void Start(){
        playerNeedSystems.healthSystem.OnHealthChanged += BarChanged;
    }

    private void BarChanged(object sender, EventArgs e){        
        HealthVaule.value = playerNeedSystems.healthSystem.GetHealthPercent();
        if (HealthVaule.value == 0) Destroy(image);
    }
}

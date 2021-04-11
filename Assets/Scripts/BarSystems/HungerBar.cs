using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HungerBar : MonoBehaviour{

    public Slider HungerVaule;
    public PlayerNeedSystems playerNeedSystems;

    private void Start(){
        playerNeedSystems.hungerSystem.OnHungerChanged += BarChanged;
    }

    private void BarChanged(object sender, EventArgs e){
        HungerVaule.value = playerNeedSystems.hungerSystem.GetHungerPercent();
    }
}

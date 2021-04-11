using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class O2Bar : MonoBehaviour{

    public Slider O2Value;
    public PlayerNeedSystems playerNeedSystems;

    private void Start(){
        playerNeedSystems.o2System.OnOxChanged += BarChanged;
    }

    private void BarChanged(object sender, EventArgs e){
        O2Value.value = playerNeedSystems.o2System.GetOxPercent();
    }
}

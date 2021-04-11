using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCounter : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI textWood;
    [SerializeField] private TextMeshProUGUI textIron;
    [SerializeField] private TextMeshProUGUI textTorch;
    [SerializeField] private TextMeshProUGUI textCan;
    [SerializeField] private TextMeshProUGUI textCarbon;
    [SerializeField] private TextMeshProUGUI textCoal;
    [SerializeField] private TextMeshProUGUI textStone;
    [SerializeField] private TextMeshProUGUI textSteel;
    [SerializeField] private TextMeshProUGUI textMoonStone;
    [SerializeField] private PlayerInventory Inventory;

    public void UpdatedeText(){
        textWood.text = "Wood " + Inventory.woodCount;
        textIron.text = "Iron " + Inventory.ironCount;
        textTorch.text = "Torch " + Inventory.torchCount;
        textCan.text = "Can " + Inventory.canCount;
        textCarbon.text = "Carbon " + Inventory.carbonCount;
        textCoal.text = "Coal " + Inventory.coalCount;
        textStone.text = "Stone " + Inventory.stoneCount;
        textSteel.text = "Steel " + Inventory.steelCount;
        textMoonStone.text = "Moon Stone " + Inventory.moonStoneCount;
    }


}

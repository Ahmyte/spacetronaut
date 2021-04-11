using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour{

    public List<CraftMaterial> inventory;
    public int stoneCount;
    public int coalCount;
    public int carbonCount;
    public int canCount;
    public int woodCount;
    public int torchCount;
    public int steelCount;
    public int ironCount;
    public int moonStoneCount;
    [SerializeField] private AudioSource audioData;
    [SerializeField] private Ship ship;

    public bool oven=false;

    [SerializeField] private ItemCounter itemCounter;

    public void Add(CraftMaterial material){
        inventory.Add(material);

        if (material.type == CraftMaterial.itemType.Stone){
            stoneCount++;
        }
        else if (material.type == CraftMaterial.itemType.Coal){
            coalCount++;
        }
        else if (material.type == CraftMaterial.itemType.Iron){
            ironCount++;
        }
        else if (material.type == CraftMaterial.itemType.Wood){
            woodCount++;
        }
        else if (material.type == CraftMaterial.itemType.Torch){
            torchCount++;
        }
        else if (material.type == CraftMaterial.itemType.Carbon){
            carbonCount++;
        }
        else if (material.type == CraftMaterial.itemType.Can){
            canCount++;
        }
        else if (material.type == CraftMaterial.itemType.Steel){
            steelCount++;
        }
        else if (material.type == CraftMaterial.itemType.Wood){
            woodCount++;
        }
        else if (material.type == CraftMaterial.itemType.MoonStone){
            moonStoneCount++;
        }
        itemCounter.UpdatedeText();
    }

    public void CraftIron(){
        if (oven){
            if (canCount >= 3 && coalCount >= 1){
                canCount = canCount - 3;
                coalCount = coalCount - 1;
                ironCount++;
                audioData.Play();
                itemCounter.UpdatedeText();
            }
        }
    }
    public void CraftTorch(){
        if (woodCount >= 1 && coalCount >= 1){
            woodCount = woodCount - 1;
            coalCount = coalCount - 1;
            torchCount++;
            audioData.Play();
            itemCounter.UpdatedeText();
        }
    }
    public void CraftFuel(){
        if (woodCount >= 5 && steelCount >= 2 && moonStoneCount >= 1 && coalCount >= 5){
            woodCount = woodCount - 5;
            steelCount = steelCount - 2;
            moonStoneCount = moonStoneCount - 1;
            coalCount = coalCount - 5;
            audioData.Play();
            itemCounter.UpdatedeText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ship.win = true;
        }
    }
    public void CraftSteel(){
        if (stoneCount >= 3 && ironCount >= 1){
            stoneCount = stoneCount - 3;
            ironCount = ironCount - 1;
            steelCount++;
            audioData.Play();
            itemCounter.UpdatedeText();
        }
    }
    public void CraftCarbon(){
        if (carbonCount >= 1 && woodCount >= 2){
            carbonCount = carbonCount - 1;
            woodCount = woodCount - 2;
            carbonCount++;
            audioData.Play();
            itemCounter.UpdatedeText();
        }
    }
    public void CraftOven(){
        if (stoneCount >= 5 && torchCount >= 4){
            stoneCount = stoneCount - 5;
            torchCount = torchCount - 4;
            audioData.Play();
            oven = true;
        }
    }
}

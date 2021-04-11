using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffPanel : MonoBehaviour{

    private bool easy = false;
    private bool hard = false;
    private bool medium = true;

    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update(){
        GameObject unit = GameObject.Find("unit");
        if (unit != null){
            if(this.hard == true)unit.GetComponent<PlayerMove>().SetHard();
            else if(this.easy == true)unit.GetComponent<PlayerMove>().SetEasy();
            else if(this.medium == true)unit.GetComponent<PlayerMove>().SetMedium();
            Destroy(this.gameObject);
        }
    }

    public void SetEasy(){
        this.easy = true;
        this.medium = false;
        this.hard = false;
    } 

    public void SetMedium(){
        this.easy = false;
        this.medium = true;
        this.hard = false;
    }

    public void SetHard(){
        this.easy = false;
        this.medium = false;
        this.hard = true;
    }

}

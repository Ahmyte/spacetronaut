using System;

public class HungerSystem{

    private float hunger;
    private float hungerMax;
    public event EventHandler OnHungerChanged;
    public HungerSystem(float hungerMax){
        this.hungerMax = hungerMax;
        hunger = hungerMax;
    }
    public float GetHunger(){
        return hunger;
    }
    public float GetHungerPercent(){
        return hunger / hungerMax;
    }
    public void GetHungary(float DamageAmount){
        hunger -= DamageAmount;
        if (hunger < 1) hunger = 0;
        if (OnHungerChanged != null) OnHungerChanged(this, EventArgs.Empty);
    }
    public void Eat(float HealAmount){
        hunger += HealAmount;
        if (hunger > hungerMax) hunger = hungerMax;
        if (OnHungerChanged != null) OnHungerChanged(this, EventArgs.Empty);
    }
}

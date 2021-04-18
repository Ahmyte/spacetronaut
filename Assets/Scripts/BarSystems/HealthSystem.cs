using System;

public class HealthSystem{

    private float health;
    private float healtMax;
    public event EventHandler OnHealthChanged;
    public HealthSystem(float healthMax){
        this.healtMax = healthMax;
        health = healtMax;
    }
    public float GetHealth(){
        return health;
    }
    public float GetHealthPercent(){
        return health / healtMax;
    }
    public void TakeDamage(float DamageAmount){
        health -= DamageAmount;
        if (health < 1) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this,EventArgs.Empty);
    }
    public void Heal(float HealAmount){
        health += HealAmount;
        if (health > healtMax) health = healtMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
    public void SetMaxHealth(float health){
        this.healtMax = health;
        this.health = health;
    }
}
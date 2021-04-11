using System;

public class O2System{

    private float O2;
    private float O2Max;
    public event EventHandler OnOxChanged;

    public O2System(float O2){
        this.O2Max = O2;
        O2 = O2Max;
    }
    public float GetOx(){
        return O2;
    }
    public float GetOxPercent(){
        return O2 / O2Max;
    }
    public void ReduceOx(float DamageAmount){
        O2 -= DamageAmount;
        if (O2 < 1) O2 = 0;
        if (OnOxChanged != null) OnOxChanged(this, EventArgs.Empty);
    }
    public void GainOx(float HealAmount){
        O2 += HealAmount;
        if (O2 > O2Max) O2 = O2Max;
        if (OnOxChanged != null) OnOxChanged(this, EventArgs.Empty);
    }
}

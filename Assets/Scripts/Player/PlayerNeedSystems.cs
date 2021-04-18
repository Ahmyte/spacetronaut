using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNeedSystems : MonoBehaviour{

    public HealthSystem healthSystem = new HealthSystem(100);
    public O2System o2System = new O2System(100);
    public HungerSystem hungerSystem = new HungerSystem(100);

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private O2Bar o2Bar;
    [SerializeField] private HungerBar hungerBar;
    [SerializeField] private AudioSource audioData;
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioClip Outro;
    public float O2reduceSpeed = 0.008f;
    public float maxHp;
    private bool isOnce = false;

    void Start(){
        if (!Music.isPlaying){
            Music.Play();
        }
        o2System.GainOx(100);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if( o2System.GetOxPercent() < 0.20f || hungerSystem.GetHungerPercent() < 0.20f || healthSystem.GetHealthPercent() < 0.20f){
            if (!audioData.isPlaying)
                audioData.Play();
        }
        else
        {
            audioData.Stop();
        }

        hungerSystem.GetHungary(0.0002f);
        if (o2System.GetOx() == 0f) healthSystem.TakeDamage(0.064f);
        if (hungerSystem.GetHunger() == 0f) healthSystem.TakeDamage(0.064f);

        if (healthSystem.GetHealthPercent() > 0.5){
            o2System.ReduceOx(O2reduceSpeed);
        } else o2System.ReduceOx(2*O2reduceSpeed);
        if (healthSystem.GetHealth()==0){
            GetComponent<PlayerMove>().enabled = false;
            GetComponentInChildren<SideRocketLeft>().enabled = false;
            GetComponentInChildren<SideRocketRight>().enabled = false;
            GetComponentInChildren<BackRocket>().enabled = false;
            Music.clip = Outro;
            Music.loop = false;
            if (audioData.isPlaying)
            {
                audioData.Stop();
            }
            
            if (!Music.isPlaying && !isOnce)
            {
                Music.Play();
                isOnce = true;
            }
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(Outro.length);
        SceneManager.LoadScene(3);
    }
}

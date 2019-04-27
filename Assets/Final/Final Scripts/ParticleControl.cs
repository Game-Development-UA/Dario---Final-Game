using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem Grape;
    public ParticleSystem Tomato;
    public ParticleSystem Pineapple;
    public ParticleSystem Watermelon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EasyOn() {
        Grape.Play();
        Tomato.Play();
        Pineapple.Stop();
        Watermelon.Stop();
    }

    public void HardOn()
    {
        Grape.Stop();
        Tomato.Stop();
        Pineapple.Play();
        Watermelon.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip Music;
    public AudioSource MusicSource;
    public Initiate Button;
    public bool ClickedMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = Music;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicControl() {
        print(Button.Clicked);
        if (Button.Clicked) {
            if (ClickedMusic) {
                MusicSource.Stop();
                ClickedMusic = false;
            }
            else {
                MusicSource.Play();
                ClickedMusic = true;
            }
        }
    }
}

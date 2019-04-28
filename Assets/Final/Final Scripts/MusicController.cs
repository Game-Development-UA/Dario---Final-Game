using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip Music;
    public AudioSource MusicSource;
    
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
        //print(Button.Clicked);
        
            if (ClickedMusic) {
            UIManager.Singleton.UpdateMusicSprite(ClickedMusic);
            MusicSource.Stop();
            ClickedMusic = false;
            }
            else {
            UIManager.Singleton.UpdateMusicSprite(ClickedMusic);
                MusicSource.Play();
                ClickedMusic = true;
            }
        
    }
}

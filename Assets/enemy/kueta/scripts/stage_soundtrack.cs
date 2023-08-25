using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_soundtrack : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip clip;
    public bool decimate=false;
    bool locked = false;
    void Start(){
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!audiosource.isPlaying && !locked){ 
            audiosource.clip = clip;
            audiosource.loop = true;
            audiosource.Play();
        }
        if(decimate && audiosource.volume!=0){
            audiosource.volume-=0.001f;
        }
        if(decimate && audiosource.volume==0){
            locked = true;
            audiosource.Stop();
            audiosource.loop = false;
            audiosource.clip = clip;
            FindObjectOfType<boss_soundtrack>().Enable();
            decimate = false;        
        }
    }

    public void Disable(){
        decimate = true;
    }

    public void Enable(){
        audiosource.volume = 1.0f;
        audiosource.Play();
        locked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_soundtrack : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip loop;
    public AudioClip start;
    public bool decimate=false;
    bool locked = true;
    void Start(){
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!audiosource.isPlaying && !locked){ 
            audiosource.clip = loop;
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
            audiosource.clip = start;
            FindObjectOfType<stage_soundtrack>().Enable();
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

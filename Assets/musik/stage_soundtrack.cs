using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_soundtrack : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip start1, start2, loop1, loop2;
    int prob;
    public bool decimate=false;
    bool locked = false;
    void Start(){
        audiosource = GetComponent<AudioSource>();
        prob = Random.Range(1,3);
        if (prob == 1){
            audiosource.clip = start1;
            audiosource.Play();
        }
        if (prob == 2){
            audiosource.clip = start2;
            audiosource.Play();
        }
    }
    void Update()
    {
        if(prob == 1){
            if (!audiosource.isPlaying && !locked){ 
                audiosource.clip = loop1;
                audiosource.loop = true;
                audiosource.Play();
            }
        }

        else if(prob == 2){
            if (!audiosource.isPlaying && !locked){ 
                audiosource.clip = loop2;
                audiosource.loop = true;
                audiosource.Play();
            }
        }
        if(decimate && audiosource.volume!=0){
            audiosource.volume-=0.002f;
        }
        if(decimate && audiosource.volume==0){
            locked = true;
            audiosource.Stop();
            audiosource.loop = false;
            if (prob == 1){
                audiosource.clip = start2;
                prob = 2;
            }
            else if (prob == 2){
                audiosource.clip = start1;
                prob = 1;
            }
            FindObjectOfType<boss_soundtrack>().Enable();
            FindObjectOfType<spawner>().summonboss();
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

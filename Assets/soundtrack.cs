using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrack : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip audioclip;
    void Start(){
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!audiosource.isPlaying){
            audiosource.clip = audioclip;
            audiosource.loop = true;
            audiosource.Play();
        }
    }
    private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("soundtrack");
        DontDestroyOnLoad(this.gameObject);
    }
}

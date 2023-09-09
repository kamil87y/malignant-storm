using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fungsitombol : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
    }
    public void Begin(){
        SceneManager.LoadScene(1);
    }
    public void Return(){
        SceneManager.LoadScene(0);
    }
}

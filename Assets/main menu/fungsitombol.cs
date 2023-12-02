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
        FindObjectOfType<pause>().pause_noaktif();
        SceneManager.LoadScene(0);
    }
    public void Continue(){
        FindObjectOfType<pause>().pause_noaktif();
    }
    public void Credits(){
        FindObjectOfType<menuchange>().tocredits();
    }
    public void Main(){
        FindObjectOfType<menuchange>().tomain();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseGameObject;
    bool pausecheck=false;
    // Start is called before the first frame update
    void Start()
    {
        pauseGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausecheck == false)
            {
                pause_aktif();
                pausecheck = true;
            }

            else if (pausecheck == true)
            {
                pause_noaktif();
                 pausecheck = false;

            }


        }
    }
    void pause_aktif()
    {
        pauseGameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void pause_noaktif()
    {
        pauseGameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

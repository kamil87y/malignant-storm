using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_sp : MonoBehaviour
{
    [SerializeField]float speed = 0.007f;
    public int p;
    public float hp = 100;
    public int corruption;
    darah darah;
    public GameObject dhil;
    // Start is called before the first frame update
    void Start()
    {
        darah=FindObjectOfType<darah>();
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = -speed*Input.GetAxis("Vertical")*Time.deltaTime;
        float gerak_samping = speed * Input.GetAxis("Horizontal")*Time.deltaTime;
        transform.Translate(gerak, gerak_samping, 0);

         if(corruption==100 && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Special Attack Unleashed!");
            corruption=0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "shield")
        {
            p = 1;
            
        }
        if(other.tag == "laser_musuh")
        {
            hp -= 2.5f;
            darah.Health(hp);
        }
    }
    
    public void Corruption()
    {
        if (corruption<100)
        {
            corruption += 5;
            Debug.Log($"Corruption is at {corruption}%");
        }
        if (corruption==100)
        {
            Debug.Log("Special Attack Ready! Press SPACE to unleash");
        }
    }
    
}

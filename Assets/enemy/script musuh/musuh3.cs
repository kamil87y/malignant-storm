using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh3 : MonoBehaviour
    
{
    public GameObject proyektil;
    public GameObject ledak;
    public Transform titik1;
    public Transform titik2;
    public Transform titik3;
    public int health = 20;
    float waktu = 0;
    
    int interval;
    scoring Scoring;
    int sekor=50;
    int mati;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 6f * Time.deltaTime, 0);
        interval = Random.Range(1, 4);
        waktu += Time.deltaTime;

        if (waktu >= interval)
        {
            tembakan();
            waktu = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "penghancur2")
        {
            Destroy(gameObject);

        }

        if (other.tag == "laser")
        {
            health -= 1;
            Debug.Log(health);
            FindObjectOfType<gerak_sp>().corrupthit();
            //Debug.Log(health);
            if (health <= 0)
            {
                Instantiate(ledak, titik3.position, titik3.rotation);
                Destroy(gameObject);
                FindObjectOfType<gerak_sp>().corruptkill();
            }

        }

        if (other.tag == "spaceship" || other.tag == "force_field" || other.tag == "roket")
        {
            Instantiate(ledak,titik3.position,titik3.rotation);
            Destroy(gameObject);
        }
    }

    void tembakan()
    {
       Instantiate(proyektil,titik1.position,titik1.rotation);
        Instantiate(proyektil, titik2.position, titik2.rotation);
    }

    private void OnDestroy()
    {
        if (transform.position.x>-15)
        {
           
            FindObjectOfType<suara_Ledak>().putar();

           
            Scoring.perubahan(sekor);
            
        }
    }
}

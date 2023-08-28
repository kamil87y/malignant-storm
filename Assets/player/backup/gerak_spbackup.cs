using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak_spbackup : MonoBehaviour
{
    public Transform titik;
    public GameObject ledak;
    [SerializeField]float speed = 0.007f;
    public int p;
    public float hp = 100;
    public float corruption;
    public Text corrupt;
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

        corrupt.text = corruption.ToString();
        float gerak = -speed*Input.GetAxis("Vertical")*Time.deltaTime;
        float gerak_samping = speed * Input.GetAxis("Horizontal")*Time.deltaTime;
        transform.Translate(gerak, gerak_samping, 0);

        if(corruption==100 && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Special Attack Unleashed!");
            corruption=0;
        }
        if (hp<=0){
            Instantiate(ledak,titik.position,titik.rotation);
            Destroy(gameObject);
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
            hp -= 1;
            darah.Health(hp);
        }

        if(other.tag == "enemy")
        {
            hp -= 5;
            darah.Health(hp);
        }
        if (other.tag == "darah_supply")
        {
            hp = 100;
            darah.Health(hp);

        }
    }
    
    public void corrupthit()
    {
        if (corruption>99.75f){
            corruption=100f;
        }
        else if (corruption<100)
        {
            corruption += 0.25f;
            Debug.Log($"Corruption is at {corruption}%");
        }
    }

    public void corruptkill(){
        if (corruption>97f){
            corruption=100f;
        }
        if (corruption<100)
        {
            corruption += 3f;
            Debug.Log($"Corruption is at {corruption}%");
        }
    }
    
}

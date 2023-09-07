using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_sp : MonoBehaviour
{
    public Transform titik;
    public GameObject ledak;
    public GameObject highborder, lowborder;
    [SerializeField]float speed = 0.007f;
    public int p;
    public float hp = 100;
    public float corruption;
    darah darah;
    public GameObject dhil;
    public Animator animator;
    public int jml_roket;
    private Vector3 highlimit;
    private Vector3 lowlimit;
    private Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        darah=FindObjectOfType<darah>();
        highlimit = highborder.transform.position;
        lowlimit = lowborder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        
        if((transform.position.x <= lowlimit.x && input.x <= 0)||(transform.position.x >= highlimit.x && input.x >= 0)){
            input.x = 0;
        }

        if((transform.position.y <= lowlimit.y && input.y <= 0)||(transform.position.y >= highlimit.y && input.y >= 0)){
            input.y = 0;
        }


        transform.position += new Vector3 (speed * input.x * Time.deltaTime, speed * input.y * Time.deltaTime, 0);

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
        if(other.tag == "enemy")
        {
            animator.Play("Base Layer.chara-anim", 0, 0);
            
            

            // animator.SetBool("tabrakan",true);

        }
        if(other.tag== "roket_pwrup")
        {
            jml_roket++;
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
        }
    }

    public void corruptkill(){
        if (corruption>97f){
            corruption=100f;
        }
        if (corruption<100)
        {
            corruption += 3f;

        }
    }
    
}

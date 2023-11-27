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
    public int hp = 100;
    public float corruption;
    darah darah;
    corruption corrup;
    public GameObject dhil;
    public Animator animator;
    public int jml_roket;
    private Vector3 highlimit;
    private Vector3 lowlimit;
    private Vector2 input;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        darah=FindObjectOfType<darah>();
        corrup=FindObjectOfType<corruption>();
        highlimit = highborder.transform.position;
        lowlimit = lowborder.transform.position;
        corrup.corruptcall(corruption);
    }

    // Update is called once per frame
    void Update()
    {
        if(paused == false){
            input = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        
            if((transform.position.x <= lowlimit.x && input.x <= 0)||(transform.position.x >= highlimit.x && input.x >= 0)){
                input.x = 0;
            }

            if((transform.position.y <= lowlimit.y && input.y <= 0)||(transform.position.y >= highlimit.y && input.y >= 0)){
                input.y = 0;
            }


            transform.position += new Vector3 (speed * input.x * Time.deltaTime, speed * input.y * Time.deltaTime, 0);

            if(corruption==100  &&Input.GetButtonDown("Jump") || corruption == 100 && Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                FindObjectOfType<spawner_corruption>().corruptunleash();
                corruption=0;
                if(hp>1){
                    hp=hp-(hp/5);
                }
                darah.Health(hp);
                corrup.corruptcall(corruption);
            }
            if (hp<=0){
                killingblow();
            }
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

        if(other.tag == "enemy" || other.tag == "roket_musuh")
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
            jml_roket+=3;
        }
    }
    
    public void corrupthit()
    {
        if (corruption>99.75f){
            corruption=100f;
            FindObjectOfType<gameover>().specialready();
        }
        else if (corruption<100)
        {
            corruption += 0.25f;
        }
        corrup.corruptcall(corruption);
    }

    public void corruptkill(){
        if (corruption>97f){
            corruption=100f;
            FindObjectOfType<gameover>().specialready();
        }
        if (corruption<100)
        {
            corruption += 3f;

        }
        corrup.corruptcall(corruption);
    }

    public void killingblow(){
        FindObjectOfType<scoring>().gameover();
        FindObjectOfType<gameover>().activate();
        Instantiate(ledak,titik.position,titik.rotation);
        Destroy(gameObject);
        FindObjectOfType<suara_Ledak>().putar();
    }

    public void paused_control(){
        paused = true;
    }

    public void continue_control(){
        paused = false;
    }
    
}

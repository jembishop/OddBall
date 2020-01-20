using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {
    public bool debug;
    public bool teleportenabled;
    public bool rocketenabled;
    public bool bombsenabled;
    public bool grappleenabled;
    public bool timestopenabled;
    public int jumplim;
    public float djheight = 0.1f;
    private Vector2 dis;
    public CameraFollow c;
    public float timestopradius;
    private LineRenderer line;
    public float maxgrapple;
    public Color col1;
    public Color col2;
 
    public Color col3;
    public float bombspeed;
    public float drag;
    public bool moveenabled;
    public float maxhealth;
    public float wait;
    public float acc;
    public float timeslow;

    public float max;
    public Rigidbody2D rb,rb2;
    private SpriteRenderer s;
    public GameObject bomb;
    public bool touching=true;
    public float strength = 1.6f;
    public float jumstren= 24f;
    public float timestoptime;
    public int jumps;
    public bool balltouch = true;
    public float djtime = 0.1f;
    public float t;
    Rigidbody2D l;
    Camera cam;
    int charge;
    private DistanceJoint2D grapple;
    private RaycastHit2D ray;
    private Vector2 acceleration;
    public float bomboffset;
    public Rigidbody2D bombrb;
    private float bombrad;
    public bool timestopnow;
    public float rayoffset;
    public List<Key> keys;
    public List<Key2> keys2;
    public List<key3> keys3;
    public Camera p;
    public GameObject b;
    public GameObject sl;
    public bool deathmode;
    public float reduce;
    public GameObject bombsprite;
    private SpriteRenderer s1;
    Vector2 grav;
    private Vector2 poi;
    private float initgrapdist;
    // Use this for initialization
    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("Time") + Time.timeSinceLevelLoad);
    }
    void Start() {


        foreach (Key k in FindObjectsOfType<Key>())
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }
        foreach (Key2 k in FindObjectsOfType<Key2>())
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }
        foreach (key3 k in FindObjectsOfType<key3>())
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }


        cam = Camera.main;
        if (debug){
            PlayerPrefs.SetInt("TeleportEnabled", 1);
            PlayerPrefs.SetInt("RocketEnabled",1);
            PlayerPrefs.SetInt("BombsEnabled",1);
            PlayerPrefs.SetInt("GrappleEnabled",1);
            PlayerPrefs.SetInt("TimestopEnabled",1);
            PlayerPrefs.SetInt("Jumplim",1);

             PlayerPrefs.SetFloat("CamSize",12);
        }

   




        teleportenabled =PlayerPrefs.GetInt("TeleportEnabled")==1;
     rocketenabled = PlayerPrefs.GetInt("RocketEnabled") == 1; ;
    bombsenabled = PlayerPrefs.GetInt("BombsEnabled") == 1; ;
     grappleenabled = PlayerPrefs.GetInt("GrappleEnabled") == 1; ;
        timestopenabled = PlayerPrefs.GetInt("TimestopEnabled") == 1;
        jumplim = PlayerPrefs.GetInt("Jumplim");

        cam.orthographicSize = PlayerPrefs.GetFloat("CamSize");
        keys = new List<Key>();
        keys2 = new List<Key2>();
        keys3 = new List<key3>();
        rb = GetComponent<Rigidbody2D>();
       grapple = GetComponent<DistanceJoint2D>();
        s = GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();
        bombrad = bomb.GetComponent<CircleCollider2D>().radius-reduce;
        string checkpoint = PlayerPrefs.GetString("Checkpoint");
        s1 = bombsprite.GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") -1);
        GameOver();
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {   
        
      
            balltouch = true;
            
            jumps = jumplim;
        
        
    }
    void Change(float t)
    {
        Vector2 pos = rb.position;
        c.FollowSpeed = c.FollowSpeed * t;
        Vector2 vel1 = rb.velocity * t;
        Vector2 vel2 = rb2.velocity * t;
        rb.gravityScale = rb.gravityScale * t * t;
        rb2.gravityScale = rb2.gravityScale * t * t;
        rb.mass = rb.mass / (t * t);
        rb2.mass = rb2.mass / (t * t);
        drag = drag*t;
        rb2.drag = rb2.drag*t;
        Time.timeScale = Time.timeScale / t;
        Time.fixedDeltaTime = Time.fixedDeltaTime / (t);
        rb.angularDrag = rb.angularDrag*t;
        rb2.angularDrag = rb.angularDrag*t;
        djheight = djheight * t;  
        wait = wait /t;
        djtime = djtime / t;
        acc = acc * t * t*t ;
        max = max * t;
        rb.position = pos;
        rb.velocity = vel1;
        rb2.velocity = vel2;
    }
   
    public void GameOver() {

        PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths")+1);
        if (timestopnow)
            {

                Change(1 / timeslow);

                timestopnow = false;

            }

            foreach (Key i in keys)
            {
            if (i != null)
            {
                i.Wake();
            }


        }

            
            foreach (Explosion i in (Object.FindObjectsOfType<Explosion>()))
            {

                i.Explode();

            }
            foreach (rigi i in (Object.FindObjectsOfType<rigi>()))
            {
            if (i != null)
            {
                i.Wake();
            }
        }
      
            rb.position = rb2.position = GameObject.Find(PlayerPrefs.GetString("Checkpoint")).GetComponent<Rigidbody2D>().position;

            rb.velocity = Vector2.zero;
            rb2.velocity = Vector2.zero;
            p.transform.position = rb.position;
            grapple.enabled = false;
    }
  
    void OnCollisionExit2D(Collision2D col)
    {
        
        t = djtime;
        balltouch = false;
      


    }
    // Update is called once per frame
    void FixedUpdate () {
       
        bool charged = charge > (int)(wait / Time.deltaTime);

        Vector2 dir = transform.right;
        Vector3 b = dir * bomboffset;
        Collider2D coli= Physics2D.OverlapCircle((transform.position - b), bombrad);
        bool intersect = Physics2D.OverlapCircle((transform.position - b), bombrad);
        bool ischeck=false;

        if (coli!= null)
        {
           ischeck = coli.gameObject.tag == "CheckPoint";
        }

        intersect = intersect && !ischeck;
      
        if (charged && Input.GetButtonUp("Bomb")&&!intersect)
        {
            
                GameObject mybomb = Instantiate(bomb, (transform.position - b), transform.rotation);
                bombrb = mybomb.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                bombrb.velocity = vel;
                bombrb.velocity += -dir * bombspeed;          
        }
        
        
        if (Input.GetButton("Bomb")&&bombsenabled)
        {
            charge++;
        }
        else { charge = 0; }
        
        
        float x = jumstren;
        t -= Time.deltaTime;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
        Vector2 pos = new Vector2(rb.transform.position.x, rb.transform.position.y);
         dis = worldPoint2d - pos;
        

        float angle = Vector2.SignedAngle(dis,dir);
        rb.AddTorque(-strength * angle);
       
        bool canjump = !touching && !balltouch && (t < 0) && (jumps > 0);
        if (canjump) { s.color = new Color(0, 1, 0, 0.5f); }
        else { s.color = new Color(1, 0, 0, 0.5f); }
        
        if (Input.GetMouseButton(0)) { x = -x;
            

        }
        if (Input.GetButtonDown("Teleport")&& teleportenabled)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.velocity = Vector2.zero;
        }
       
            rb.AddForce(x * dir);
            rb2.AddForce(-x * dir);
        

       
        if (Input.GetMouseButtonUp(0)&&canjump)
        {
           rb.velocity=-djheight*dir;
           
            jumps--;

        }

        float a = Input.GetAxis("Horizontal");
        if (moveenabled&&rocketenabled)
          
        {
            Vector2 i = Vector2.right;
            float proj = Vector2.Dot(rb.velocity, i);
            if (a > 0) { if (proj< max) { rb.AddForce(acc * a *i* rb.mass); } }
            else { if (-proj < max) { rb.AddForce(acc * a * i * rb.mass); } }
        }

        if (charged) { s1.enabled=true; }
        else { s1.enabled=false; }
        
        
        


         if (timestopnow)
         {
             p.backgroundColor = col2;
         }
         else { p.backgroundColor = col1; }
         
    }
    private void Update()
    {
        if (Input.GetButtonDown("Exit")){
            SceneManager.LoadScene("Main Menu");

        }

            if (Input.GetButtonDown("Grapple") & grappleenabled)
        {
            if (grapple.enabled)
            {
                grapple.enabled = false;
            }
            else
            {
                dis.Normalize();
                RaycastHit2D hit;

                hit = Physics2D.Raycast(rb.position, dis, maxgrapple, ~(1 << 10));



                if (hit.collider != null)

                {
                    bool iselectric = (hit.transform.gameObject.tag == "Electric")|| (hit.transform.gameObject.tag == "Floors");

                    if (!iselectric && hit.rigidbody != null)
                    {

                        poi = hit.point;
                        grapple.enabled = true;
                        initgrapdist = grapple.distance;

                        grapple.connectedBody = hit.rigidbody;
                        grapple.connectedAnchor = hit.rigidbody.transform.InverseTransformPoint(hit.point);

                        l = hit.rigidbody;


                    }


                }
            }
        }
        if (grapple.enabled)
        { //Debug.DrawLine(l, rb.position, Color.red);
            line.enabled = true;
            Vector3 k = l.transform.TransformPoint(grapple.connectedAnchor);
            Vector3 j = rb.position;
            Vector3[] m = new Vector3[2];
            m[0] = k;
            m[1] = j;
            line.SetPositions(m);
            float f = (rb.position - poi).magnitude / initgrapdist;

            Color mycol = new Color(1, f, f, 0.7f);
            line.startColor = mycol;
            line.endColor = mycol;
            moveenabled = false;
            rb.drag = 0;
        }
        else { moveenabled = true; rb.drag = drag; line.enabled = false; }

        if (Input.GetButtonDown("Timestop") && timestopenabled)
        {
          

            if (!timestopnow)
            {
               
                Change(timeslow);

                timestopnow = true;
              
            }
            else
            {
               
                Change(1 / timeslow);

                timestopnow = false;
            }



        }
      
    }



}


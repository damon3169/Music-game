using UnityEngine;
//using System.Collections;


public class EnterTheZone : MonoBehaviour
{

    private GameObject Enemi = null;
    // Use this for initialization
    private Transform image;

    [SerializeField]
    private GameObject Player;


    private bool isDead = false;

    private float errorTimer = 1.0f;

    private float now;
    private Animator anim;

    private int hit;

    private bool moveForward = false;
    private bool moveBackward = false;

    private float _enteringSceneTargetZPos = 10.0f;


    void Start()
    {
        image = transform.GetChild(0);
        image.GetComponent<Renderer>().material.color = Color.green;
        PlayerPrefs.SetInt("Error", 0);
        anim = Player.GetComponent<Animator>();
        hit = Animator.StringToHash("Hit");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Error") == 1 && Time.time < PlayerPrefs.GetFloat("time_error") + errorTimer)
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (PlayerPrefs.GetInt("Error") == 1)
            {
                PlayerPrefs.SetInt("Error", 0);
                foreach (Transform child in transform.parent.gameObject.transform)
                {
                    child.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                }
            }


            if (moveForward)
            {
                Player.transform.position += Player.transform.forward * Time.deltaTime * 20.0f;
                if (Player.GetComponent<Collision_object>().getIsCollision())
                {
                    Player.GetComponent<Collision_object>().setIsCollision(false);
                    Player.GetComponent<Hitting>().setIsHitting(false);
                    moveForward = false;
                    moveBackward = true;
                    damage();
                }
            }
            if (moveBackward)
            {
                
                Vector3 targetPos = new Vector3(0f, 1.1f, 0f);
                Vector3 lerp = Vector3.Lerp(Player.transform.position, targetPos, 0.6f);
                Player.transform.position = lerp;
                if (Player.transform.position == new Vector3(0f, 1.1f, 0f))
                {
                    
                    moveBackward = false;
                }
            }

            if (Enemi != null)
            {


                if (Enemi.GetComponent<EnemiMovement>().getDirection() == Directions.Left)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {                   

                        anim.SetTrigger(hit);
                        Player.transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
                        Player.GetComponent<Hitting>().setIsHitting(true);
                        moveForward = true;

                    }
                }
                if (Enemi.GetComponent<EnemiMovement>().getDirection() == Directions.Right)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {                    

                        anim.SetTrigger(hit);
                        Player.transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
                        Player.GetComponent<Hitting>().setIsHitting(true);
                        moveForward = true;

                    }
                }
                if (Enemi.GetComponent<EnemiMovement>().getDirection() == Directions.Down)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {                    

                        anim.SetTrigger(hit);
                        Player.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
                        Player.GetComponent<Hitting>().setIsHitting(true);
                        moveForward = true;

                    }
                }
                if (Enemi.GetComponent<EnemiMovement>().getDirection() == Directions.Up)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {                  
                        anim.SetTrigger(hit);
                        Player.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1));
                        Player.GetComponent<Hitting>().setIsHitting(true);
                        moveForward = true;

                    }
                }
              /*  if (anim.GetBool("Hit"))
                {
                }*/
            }
            else
            {

                if (gameObject.name == "pushZoneUp")
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        PlayerPrefs.SetInt("Error", 1);
                        PlayerPrefs.SetFloat("time_error", Time.time);
                    }
                }
                if (gameObject.name == "pushZoneDown")
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        PlayerPrefs.SetInt("Error", 1);
                        PlayerPrefs.SetFloat("time_error", Time.time);
                    }
                }
                if (gameObject.name == "pushZoneRight")
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        PlayerPrefs.SetInt("Error", 1);
                        PlayerPrefs.SetFloat("time_error", Time.time);
                    }
                }
                if (gameObject.name == "pushZoneLeft")
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        PlayerPrefs.SetInt("Error", 1);
                        PlayerPrefs.SetFloat("time_error", Time.time);
                    }
                }

            }
        }
    }

    void damage()
    {
        if (Enemi != null)
        {
            isDead = Enemi.GetComponent<Life>().TakeDamage(0, false);
            if (Enemi.gameObject.name == "Enemi_change(Clone)")
            {
                Enemi.GetComponent<Directions_change>().DirectionChangement();
            }
            if (isDead == true)
            {
                image = transform.GetChild(0);
                image.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemi")
        {
            GameObject enemi = other.gameObject;
            Enemi = other.gameObject;
            image = transform.GetChild(0);
            image.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerStay(Collider other)
    {
        image.GetComponent<Renderer>().material.color = Color.red;
    }

      void OnTriggerExit(Collider other)
    {
        image.GetComponent<Renderer>().material.color = Color.green;
        Enemi = null;
    }
}


using UnityEngine;
using System.Collections.Generic;

public class EnterTheZone : MonoBehaviour
{

    private GameObject Enemi = null;


    // Use this for initialization
    private Transform image;

    [SerializeField]
    private GameObject Player;


    private bool isDead = false;

    [SerializeField]
    private float errorTimer = 1.0f;

    private float now;
    private Animator anim;

    private int hit;

    private bool moveForward = false;
    private bool moveBackward = false;

    List<GameObject> PreviousEnemies = new List<GameObject>();

    void Start()
    {
        // Set la zone en vert
        image = transform.GetChild(0);
        image.GetComponent<Renderer>().material.color = Color.green;
        //Set l'erreur de touche a zero
        PlayerPrefs.SetInt("Error", 0);
        anim = Player.GetComponent<Animator>();
        hit = Animator.StringToHash("Hit");
    }

    // Update is called once per frame
    void Update()
    {
        //Si il y a eu une erreur de touche rends la zone jaune et que le temps de bloquage n'est pas terminé
        if (PlayerPrefs.GetInt("Error") == 1 && Time.time < PlayerPrefs.GetFloat("time_error") + errorTimer)
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
        }
        //Si il n'y a pas eu d'erreur de touche
        else
        {
            //Si il y a eu une erreur de touche
            if (PlayerPrefs.GetInt("Error") == 1)
            {
                // Remet l'erreur de touche en faux et remet les zones en vert
                PlayerPrefs.SetInt("Error", 0);
                foreach (Transform child in transform.parent.gameObject.transform)
                {
                    child.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                }
            }

            //Si le joueur doit avancer
            if (moveForward)
            {
                //fais avancer le joueur
                Player.transform.position += Player.transform.forward * Time.deltaTime * 20.0f;
                //Si collision 
                if (Player.GetComponent<Collision_object>().getIsCollision())
                {
                    //Set la collision a faux
                    Player.GetComponent<Collision_object>().setIsCollision(false);
                    //Fini de frapper
                    Player.GetComponent<Hitting>().setIsHitting(false);
                    //Indique qu'il faut aretter d'avancer , commencer a reculer et lancer dammage
                    moveForward = false;
                    moveBackward = true;
                    damage();
                }
            }

            //Si le joueur doit reculer
            if (moveBackward)
            {
                //fais reculer le joueur jusqu'a sa position de base
                Vector3 targetPos = new Vector3(0f, 1.1f, 0f);
                Vector3 lerp = Vector3.Lerp(Player.transform.position, targetPos, 0.6f);
                Player.transform.position = lerp;
                if (Player.transform.position == new Vector3(0f, 1.1f, 0f))
                {
                    moveBackward = false;
                }
            }

            // Si il y a un ennemi dans la zone 
            if (Enemi != null)
            {
                //Vérifie si le joueur clique sur la bonne touche, si oui lance l'animation de coup de pied, indiquequ'il faut avancer et fait tourner le joueur
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
            }
            // Si il n'y a pas d'ennemi sur la zone met une erreur
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

    //Enlève des pv a l'enemi, si il y a un autre enemi sur la zone, le tue et si l'enemi est mort remet la zone en vert, si l'enemi est un enemi change, le fait changer de direction
    void damage()
    {
        isDead = Enemi.GetComponent<Life>().TakeDamage(0, false);
        if (Enemi.gameObject.name == "Enemi_change(Clone)" && Enemi != null)
        {
            Enemi.GetComponent<Directions_change>().DirectionChangement();
        }

        if (PreviousEnemies.Count != 0)
        {
            for (int i = 0;i< PreviousEnemies.Count;i++)
            {
                GameObject enemi = PreviousEnemies[i];
                PreviousEnemies.RemoveAt(i);
                GameObject.Destroy(enemi);
            }
        }

        if (isDead == true)
        {
            image = transform.GetChild(0);
            image.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    //récupère l'enemi qui rentre dans la zone , et garde ceux qui y était déja et met la zone en rouge
    void OnTriggerEnter(Collider other)
    {
        if (Enemi != null)
        {
            PreviousEnemies.Add(Enemi);
        }
        Enemi = other.gameObject;
        image = transform.GetChild(0);
        image.GetComponent<Renderer>().material.color = Color.red;
    }

    // temps que quelques chose est a l'intérieur, la zone est en rouge
    void OnTriggerStay(Collider other)
    {
        image.GetComponent<Renderer>().material.color = Color.red;
    }

    //Si l'énemi sort, remet la zone en rouge
    void OnTriggerExit(Collider other)
    {
        image.GetComponent<Renderer>().material.color = Color.green;
        Enemi = null;
    }
}


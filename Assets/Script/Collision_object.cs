using UnityEngine;
//using System.Collections;

public class Collision_object : MonoBehaviour
{

    private bool isDead;
    // Use this for initialization
    GameObject zone;

    //Particule de coups
    [SerializeField]
    private GameObject Particle;

    private AudioSource audios;

    public AudioClip impact;

    private bool isCollision = false;



    void Start()
    {
        if (tag == "Player")
        {
            //Instancie la source audio
            audios = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Si la collision ne se fait pas avec la zone
        if (col.gameObject.tag != "Zone")
        {
            //Si l'objet qui collisionne est un enemi.
            if (col.gameObject.tag == "Enemi" && tag == "Player")
            {
                if (col.gameObject.tag == "Enemi")
                {
                    //Si c'est un enemie basique ou bien un enemi double
                    if (col.gameObject.name == "Enemi(Clone)" || col.gameObject.name == "Enemi 1(Clone)")
                    {
                        //Faire un knockback a la collision
                        col.gameObject.GetComponent<KnockBack>().CallKnockBack(-4);
                    }
                    //Si c'est un enemie change et que le joueur n'est pas en train de taper
                    if (col.gameObject.name == "Enemi_change(Clone)" && !GetComponent<Hitting>().getIsHitting())
                    {
                        //Faire un knockback a la collision
                        col.gameObject.GetComponent<KnockBack>().CallKnockBack(-4);
                    }
                    //fais une particule et lance un son dans la bonne direction
                    if (col.gameObject.GetComponent<EnemiMovement>().getDirection() == Directions.Left)
                    {
                        audios.PlayOneShot(impact, 0.7F);

                        Instantiate(Particle, col.transform.position + new Vector3(0.5f, 0, 0), col.transform.rotation);
                    }
                    if (col.gameObject.GetComponent<EnemiMovement>().getDirection() == Directions.Right)
                    {
                        audios.PlayOneShot(impact, 0.7F);

                        Instantiate(Particle, col.transform.position + new Vector3(-0.5f, 0, 0), col.transform.rotation);
                    }
                    if (col.gameObject.GetComponent<EnemiMovement>().getDirection() == Directions.Up)
                    {
                        audios.PlayOneShot(impact, 0.7F);

                        Instantiate(Particle, col.transform.position + new Vector3(0, 0, -0.5f), col.transform.rotation);
                    }
                    if (col.gameObject.GetComponent<EnemiMovement>().getDirection() == Directions.Down)
                    {
                        audios.PlayOneShot(impact, 0.7F);
                        Instantiate(Particle, col.transform.position + new Vector3(0, 0, 0.5f), col.transform.rotation);
                    }
                }
                //Si le joueur n'est pas en train de taper il prends un point de dégat
                if (!GetComponent<Hitting>().getIsHitting())
                {
                    GetComponent<Life>().TakeDamage(0, true);
                }
                //Met la collision avec un enemi a vrai
                isCollision = true;
            }
        }
    }

    //Renvoie si en collision ou non
    public bool getIsCollision()
    {
        return isCollision;
    }

    //Peut changer si en collision ou non
    public void setIsCollision(bool newState)
    {
        isCollision = newState;
    }

}
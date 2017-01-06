using UnityEngine;
//using System.Collections;

public class Collision_object : MonoBehaviour
{

    private bool isDead;
    // Use this for initialization
    GameObject zone;

    [SerializeField]
    private GameObject Particle;

    private AudioSource audios;

    public AudioClip impact;

    private bool isCollision = false;

    void Start()
    {
        if (tag == "Player")
        {
            audios = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Zone")
        {
            if (col.gameObject.tag == "Enemi" && tag == "Player")
            {
                if (col.gameObject.name == "Enemi(Clone)" || col.gameObject.name == "Enemi 1(Clone)")
                {
                    col.gameObject.GetComponent<KnockBack>().CallKnockBack(-4);
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

                if (col.gameObject.name == "Enemi_change(Clone)" && !GetComponent<Hitting>().getIsHitting())
                {
                    col.gameObject.GetComponent<KnockBack>().CallKnockBack(-4);
                }

                if (!GetComponent<Hitting>().getIsHitting())
                {
                    GetComponent<Life>().TakeDamage(0, true);
                }
                isCollision = true;
            }
        }
    }

    public bool getIsCollision()
    {
        return isCollision;
    }

    public void setIsCollision(bool newState)
    {
        isCollision = newState;
    }

}
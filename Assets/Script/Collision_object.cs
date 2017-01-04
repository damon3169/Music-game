using UnityEngine;
//using System.Collections;

public class Collision_object : MonoBehaviour
{

    private bool isDead;
    // Use this for initialization
    GameObject zone;



    private bool isCollision = false;

    void Start()
    {

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
                }
                if (col.gameObject.name == "Enemi_change(Clone)" && !GetComponent<Hit>().getIsHitting())
                {
                    col.gameObject.GetComponent<KnockBack>().CallKnockBack(-4);
                }
                if (!GetComponent<Hit>().getIsHitting())
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
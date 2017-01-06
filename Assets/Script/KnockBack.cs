using UnityEngine;
//using System.Collections;

public class KnockBack : MonoBehaviour
{
    private Vector3 veloObject;

    private bool isCall = false;
    private float now;

    private int speed;

    //Durée du knockback
    [SerializeField]
    private float KnockBackDuration = 0.5f;
    // Use this for initialization
    void Start()
    {
        //Récupère la velocité de l'objet
        veloObject = GetComponent<Rigidbody>().velocity;
        now = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Si knockback alors faire reculer l'objet
        if (isCall && now + KnockBackDuration > Time.time)
        {
            GetComponent<Rigidbody>().velocity = speed * transform.forward;
        }
        else
        {   //Sinon le faire avancer vers le joueur avec sa précédente vitesse 
            if (isCall)
            {
                GetComponent<Rigidbody>().velocity = this.GetComponent<EnemiMovement>().getSpeed() * transform.forward;
            }
            isCall = false;
        }
    }

    //Permet de lancer un knockback
    public void CallKnockBack(int speedObject)
    {
        now = Time.time;
        speed = speedObject;
        isCall = true;
        if (gameObject.name == "Enemi_change(Clone)")
        {
            veloObject = GetComponent<Rigidbody>().velocity;
        }
    }
}

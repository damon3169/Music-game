using UnityEngine;
//using System.Collections;

public class KnockBack : MonoBehaviour
{
    private Vector3 veloObject;

    private bool isCall = false;
    private float now;

    private int speed;

    [SerializeField]
    private float KnockBackDuration = 0.5f;
    // Use this for initialization
    void Start()
    {
        veloObject = GetComponent<Rigidbody>().velocity;
        now = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCall && now + KnockBackDuration > Time.time)
        {
            GetComponent<Rigidbody>().velocity = speed * transform.forward;
        }
        else
        {
            if (isCall)
            {
                GetComponent<Rigidbody>().velocity = veloObject;
            }
            isCall = false;
        }
    }

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

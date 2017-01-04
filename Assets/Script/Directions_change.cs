﻿using UnityEngine;
//using System.Collections;

public class Directions_change : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DirectionChangement()
    {
        int speed = GetComponent<EnemiMovement>().getSpeed();
        if (GetComponent<EnemiMovement>().getDirection() == Directions.Left)
        {
            transform.position = new Vector3(0, 0, -transform.position.x);

        }
        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Right)
        {
            transform.position = new Vector3(0, 0, -transform.position.x);
        }
        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Up)
        {
            transform.position = new Vector3(transform.position.z, 0, 0);
        }

        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Down)
        {
            transform.position = new Vector3(transform.position.z, 0, 0);

        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Hit>().setIsHitting(false);
        transform.rotation = Quaternion.LookRotation(Vector3.zero - transform.position);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        GetComponent<EnemiMovement>().setDirection();
        GetComponent <Life>().getZone().transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;



    }
}
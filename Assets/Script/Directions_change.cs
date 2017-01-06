using UnityEngine;
//using System.Collections;

public class Directions_change : MonoBehaviour
{

    public void DirectionChangement()
    {
        //Récupère la vitesse de l'objet
        int speed = GetComponent<EnemiMovement>().getSpeed();
        //Déplace l'objet en fonction de sa position
        if (GetComponent<EnemiMovement>().getDirection() == Directions.Left)
        {
            transform.position = new Vector3(0, 0, -transform.position.x + 1.5f);

        }
        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Right)
        {
            transform.position = new Vector3(0, 0, -transform.position.x - 1.5f);
        }
        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Up)
        {
            transform.position = new Vector3(transform.position.z + 1.5f, 0, 0);
        }

        else if (GetComponent<EnemiMovement>().getDirection() == Directions.Down)
        {
            transform.position = new Vector3(transform.position.z - 1.5f, 0, 0);

        }
        //Change sa direction pour qu'il regarde et avance vers le joueur
        GameObject.FindGameObjectWithTag("Player").GetComponent<Hitting>().setIsHitting(false);
        transform.rotation = Quaternion.LookRotation(Vector3.zero - transform.position);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        GetComponent<EnemiMovement>().setDirection();
    }
}

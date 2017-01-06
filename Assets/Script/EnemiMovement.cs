using UnityEngine;
//using System.Collections;

public enum Directions
{
    None = 0,
    Up = 1,
    Down = 2,
    Right = 3,
    Left = 4,
};

public class EnemiMovement : MonoBehaviour
{
    Directions _direction = Directions.None;

    //Vitesse de base de l'enemi
    [SerializeField]
    private int speed = 10;

    // Set la direction de base de l'enemi est le fait avancer
    void Start()
    {
       setDirection();
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    //Récupère la direction
    public Directions getDirection()
    {
        return _direction;
    }

    //Modifie la vitesse
    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    //Récupère la vitesse
    public int getSpeed()
    {
        return speed;
    }

    //Donne une direction en fonction de la rotation
    public void setDirection()
    {
        if (transform.eulerAngles.y == 180)
        {
            _direction = Directions.Up;
        }
        else if (transform.eulerAngles.y == 0)
        {
            _direction = Directions.Down;
        }
        else if (transform.eulerAngles.y == 90)
        {
            _direction = Directions.Left;
        }
        else if (transform.eulerAngles.y == 270)
        {
            _direction = Directions.Right;
        }
    }

}

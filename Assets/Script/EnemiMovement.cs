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

    [SerializeField]
    private int speed = 10;

    // Use this for initialization
    void Start()
    {
       setDirection();
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Directions getDirection()
    {
        return _direction;
    }

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public int getSpeed()
    {
        return speed;
    }

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

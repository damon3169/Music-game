using UnityEngine;
//using System.Collections;

public class Life : MonoBehaviour
{
    [SerializeField]
    private int life = 3;
    // Use this for initialization

    private float pourcentage;

    private Vector3 veloObject;

    private bool isDead = false;

    private GameObject zone;

    private Transform LifeBar;
    void Start()
    {
        pourcentage = (float)(100.0f / life) / 100.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void healthBar()
    {
        LifeBar = GameObject.Find("LifeBar").transform;
        Transform DamageTaken = LifeBar.Find("DamageTaken");
        Transform bar = DamageTaken.transform.Find("Life");
        //Diminue la taille de la barre de vie quand besoin
        bar.transform.localScale += new Vector3(-pourcentage, 0, 0);
    }

    public bool TakeDamage(int speed, bool collision)
    {
        isDead = false;
        if (life > 0)
        {

            life--;

            if (this.tag == "Player")
            {
                //Appel la fonction qui réduie la barre de vie
                healthBar();
            }
        }

        if (life <= 0)
        {
            isDead = true;
            Die(collision);
        }
        return isDead;
    }

    public void Die(bool collision)
    {
        if (this.tag == "Player")
        {
            //Lancer scène game over
            GameObject.Find("LevelController").GetComponent<GameOver>().gameIsOver();
        }
        else if (this.tag == "Enemi")
        {
            zone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            if (!collision)
            {
                GameObject.Find("Player").GetComponent<Score_manager>().addScore(10);
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (tag == "Enemi")
        {
            if (col.gameObject.tag == "Zone" && col.gameObject.name != "Ground" && col.gameObject.name != "ColorBar")
            {
                zone = col.gameObject;
            }
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (tag == "Enemi")
        {
            if (col.gameObject.tag == "Zone" && col.gameObject.name != "Ground" && col.gameObject.name != "ColorBar")
            {
                zone = col.gameObject;
            }
        }

    }

    public GameObject getZone()
    {
        return zone;
    }
}

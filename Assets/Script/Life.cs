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
        //Calcul la quantité de barre a enlevé a chaque coup
        pourcentage = (float)(100.0f / life) / 100.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void healthBar()
    {
        // Récupère la barre de vie
        LifeBar = GameObject.Find("LifeBar").transform;
        Transform DamageTaken = LifeBar.Find("DamageTaken");
        Transform bar = DamageTaken.transform.Find("Life");
        //Diminue la taille de la barre de vie quand besoin
        bar.transform.localScale += new Vector3(-pourcentage, 0, 0);
    }

    public bool TakeDamage(int speed, bool collision)
    {
        isDead = false;
        //Si l'objet a encore des pv
        if (life > 0)
        {
            //Enlève un point de vie
            life--;
            //Diminué la barre de vie
            if (this.tag == "Player")
            {
                //Appel la fonction qui réduie la barre de vie
                healthBar();
            }
        }

        if (life <= 0)
        {
            // Tue l'objet et indique qu'il est mort
            isDead = true;
            Die(collision);
        }
        return isDead;
    }

    public void Die(bool collision)
    {
        //Si le joueur meurt
        if (this.tag == "Player")
        {
            //Lancer scène game over
            GameObject.Find("LevelController").GetComponent<GameOver>().gameIsOver();
        }
        //Si l'enemi meurt
        else if (this.tag == "Enemi")
        {
            //met la zone sur laquelle était l'enemi en vert
            zone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            // Ajoute 10 de score au joueur
            if (!collision)
            {
                GameObject.Find("Player").GetComponent<Score_manager>().addScore(10);
            }
            //Detruit l'objet
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //Si l'objet est un enemie
        if (tag == "Enemi")
        {
            //Récupère la zone dans laquelle est l' enemi
            if (col.gameObject.tag == "Zone" && col.gameObject.name != "Ground" && col.gameObject.name != "ColorBar")
            {
                zone = col.gameObject;
            }
        }

    }


    void OnTriggerExit(Collider col)
    {
        //Si l'objet est un enemie
        if (tag == "Enemi")
        {
            //Récupère la zone dans laquelle était l' enemi
            if (col.gameObject.tag == "Zone" && col.gameObject.name != "Ground" && col.gameObject.name != "ColorBar")
            {
                zone = col.gameObject;
            }
        }

    }

    public GameObject getZone()
    {
        //Retourne la zone
        return zone;
    }
}

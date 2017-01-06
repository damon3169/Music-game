using UnityEngine;
//using System.Collections;
using System.Collections.Generic;

public class SpawnEnemi : MonoBehaviour
{
    //Contient le prefab des enemies de base
    [SerializeField]
    private GameObject _enemiBasePrefab = null;

    //Contient le prefab des enemies qu'il faut taper deux fois
    [SerializeField]
    private GameObject _enemiDoublePrefab = null;

    //Contient le prefab des enemies qui change de ligne quand on les tapes
    [SerializeField]
    private GameObject _enemiChangePrefab = null;

    //Permet d'obtenir les positions des différents spawn
    [SerializeField]
    private GameObject spawnUp = null;

    [SerializeField]
    private GameObject spawnDown = null;

    [SerializeField]
    private GameObject spawnLeft = null;

    [SerializeField]
    private GameObject spawnRight = null;

    //Nombres d'enemies de chaques types
    [SerializeField]
    private int nbEnemiBase = 0;

    [SerializeField]
    private int nbEnemiDouble = 0;

    [SerializeField]
    private int nbEnemiChange = 0;

    //Min et max des timer de spawn
    [SerializeField]
    private float SpawnTimerMin = 1;

    [SerializeField]
    private float SpawnTimerMax = 2;

    private float now;

    private float randomSpawn;

    private int RandomType;

    private int randomLocation;

    private GameObject enemi;

    //Min est max de la vitesse
    [SerializeField]
    private int MaxSpeed = 10;

    [SerializeField]
    private int MinSpeed = 15;

    private int speed;

    private bool isFinish = false;

    public List<string> enemies = new List<string>();


    // Use this for initialization
    void Start()
    {
        //Si il y a des enemies du bon type, ajouter le types dans la liste
        if (nbEnemiBase != 0)
        {
            enemies.Add("_enemiBasePrefab");
        }

        if (nbEnemiDouble != 0)
        {
            enemies.Add("_enemiDoublePrefab");
        }

        if (nbEnemiChange != 0)
        {
            enemies.Add("_enemiChangePrefab");
        }

        //Prends le timer de start
        now = Time.time;

        //Location de spawn, temps avant le spawn et type du premier enemie 
        randomLocation = Random.Range(1, 5);
        randomSpawn = Random.Range(SpawnTimerMin, SpawnTimerMax + 1);
        RandomType = Random.Range(0, enemies.Count);

        //Garde le nom du niveau pour l'afficher sur l'écran de fin de niveau
        PlayerPrefs.SetString("level_name", Application.loadedLevelName);

    }

    // Update is called once per frame
    void Update()
    {
        //Si la partie n'est pas perdu
        if (!GetComponent<GameOver>().getGameOver())
        {
            //Si il reste encore des enemi a faire spawn
            if (isFinish == false)
            {
                //Si le timer entre les spawn est fini
                if (Time.time > now + randomSpawn)
                {
                    //Random une zone de spawn
                    randomLocation = Random.Range(1, 5);
                    //Si l'enemie random est de basique
                    if (enemies[RandomType] == "_enemiBasePrefab")
                    {
                        //Si il spawn a cette location, le fait spawn, lui donne sa vitesse et le retir de la liste
                        if (randomLocation == 1)
                        {
                            enemi = (GameObject)Instantiate(_enemiBasePrefab, spawnUp.transform.position, spawnUp.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiBase = nbEnemiBase - 1;
                        }
                        else if (randomLocation == 2)
                        {
                            enemi = (GameObject)Instantiate(_enemiBasePrefab, spawnDown.transform.position, spawnDown.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiBase = nbEnemiBase - 1;
                        }
                        else if (randomLocation == 3)
                        {
                            enemi = (GameObject)Instantiate(_enemiBasePrefab, spawnLeft.transform.position, spawnLeft.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiBase = nbEnemiBase - 1;
                        }
                        else if (randomLocation == 4)
                        {
                            enemi = (GameObject)Instantiate(_enemiBasePrefab, spawnRight.transform.position, spawnRight.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiBase = nbEnemiBase - 1;

                        }

                        //Si il n'y a plus d'énemi de base, enlève enemie de base de la liste
                        if (nbEnemiBase == 0)
                        {
                            enemies.RemoveAt(RandomType);
                        }
                    }
                    else if (enemies[RandomType] == "_enemiDoublePrefab")
                    {

                        if (randomLocation == 1)
                        {
                            enemi = (GameObject)Instantiate(_enemiDoublePrefab, spawnUp.transform.position, spawnUp.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiDouble = nbEnemiDouble - 1;
                        }
                        else if (randomLocation == 2)
                        {
                            enemi = (GameObject)Instantiate(_enemiDoublePrefab, spawnDown.transform.position, spawnDown.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiDouble = nbEnemiDouble - 1;
                        }
                        else if (randomLocation == 3)
                        {
                            enemi = (GameObject)Instantiate(_enemiDoublePrefab, spawnLeft.transform.position, spawnLeft.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiDouble = nbEnemiDouble - 1;
                        }
                        else if (randomLocation == 4)
                        {
                            enemi = (GameObject)Instantiate(_enemiDoublePrefab, spawnRight.transform.position, spawnRight.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiDouble = nbEnemiDouble - 1;
                        }
                        if (nbEnemiDouble == 0)
                        {
                            enemies.RemoveAt(RandomType);
                        }
                    }
                    else if (enemies[RandomType] == "_enemiChangePrefab")
                    {
                        if (randomLocation == 1)
                        {
                            enemi = (GameObject)Instantiate(_enemiChangePrefab, spawnUp.transform.position, spawnUp.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiChange = nbEnemiChange - 1;
                        }
                        else if (randomLocation == 2)
                        {
                            enemi = (GameObject)Instantiate(_enemiChangePrefab, spawnDown.transform.position, spawnDown.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiChange = nbEnemiChange - 1;
                        }
                        else if (randomLocation == 3)
                        {
                            enemi = (GameObject)Instantiate(_enemiChangePrefab, spawnLeft.transform.position, spawnLeft.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiChange = nbEnemiChange - 1;
                        }
                        else if (randomLocation == 4)
                        {
                            enemi = (GameObject)Instantiate(_enemiChangePrefab, spawnRight.transform.position, spawnRight.transform.rotation);
                            speed = Random.Range(MinSpeed, MaxSpeed + 1);
                            enemi.GetComponent<EnemiMovement>().setSpeed(speed);
                            nbEnemiChange = nbEnemiChange - 1;
                        }
                        if (nbEnemiChange == 0)
                        {
                            enemies.RemoveAt(RandomType);
                        }
                    }
                    //Random le prochain timer, prends le moment du dernier spawn et random le prochain type d'enemi
                    randomSpawn = Random.Range(SpawnTimerMin, SpawnTimerMax + 0.1f);
                    now = Time.time;
                    RandomType = Random.Range(0, enemies.Count);
                }

                //Si il n'y a plus d'enemi met isFinish a true, sinon le laisse a false
                if (nbEnemiChange == 0 && nbEnemiDouble == 0 && nbEnemiBase == 0)
                {
                    isFinish = true;
                }
                else
                {
                    isFinish = false;
                }

            }
            else
            {
                //Si partie fini lance la victoire et inscrit dans les playersPrefs que le joueur a gagné
                if (!GetComponent<GameOver>().getGameOver() && GameObject.FindGameObjectWithTag("Enemi") ==null)
                {
                    PlayerPrefs.SetString("status", "Win");
                    GetComponent<GameOver>().GameisWin();
                }
            }
        }
    }

}

using UnityEngine;
//using System.Collections;
using System.Collections.Generic;

public class SpawnEnemi : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemiBasePrefab = null;

    [SerializeField]
    private GameObject _enemiDoublePrefab = null;

    [SerializeField]
    private GameObject _enemiChangePrefab = null;

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

    [SerializeField]
    private float SpawnTimerMin = 1;

    [SerializeField]
    private float SpawnTimerMax = 2;

    private float now;

    private float randomSpawn;

    private int RandomType;

    private int randomLocation;

    private GameObject enemi;

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


        now = Time.time;

        randomLocation = Random.Range(1, 5);
        randomSpawn = Random.Range(SpawnTimerMin, SpawnTimerMax + 1);
        RandomType = Random.Range(0, enemies.Count);

        PlayerPrefs.SetFloat("timerBegin", Time.time);
        PlayerPrefs.SetString("level_name", Application.loadedLevelName);

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<GameOver>().getGameOver())
        {
            if (isFinish == false)
            {
                if (Time.time > now + randomSpawn)
                {
                    randomLocation = Random.Range(1, 5);
                    if (enemies[RandomType] == "_enemiBasePrefab")
                    {

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
                    randomSpawn = Random.Range(SpawnTimerMin, SpawnTimerMax + 0.1f);
                    now = Time.time;
                    RandomType = Random.Range(0, enemies.Count);
                }

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
                if (!GetComponent<GameOver>().getGameOver() && GameObject.FindGameObjectWithTag("Enemi") ==null)
                {
                    PlayerPrefs.SetFloat("timerEnd", Time.time);
                    PlayerPrefs.SetString("status", "Win");
                    GetComponent<GameOver>().GameisWin();
                }
            }
        }
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private bool isGameOver = false;

    [SerializeField]
    private Camera camera;
    // Use this for initialization

    [SerializeField]
    private Text GameOverText;

    private bool gameIsWin = false;

    private float now;

    void Start()
    {
        GameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            camera.transform.LookAt(GameObject.Find("Player").transform);
            camera.transform.Translate(Vector3.right * Time.deltaTime);
            GameOverText.text = "Game Over\n Push a button to continu";
            if (Input.anyKey && Time.time > now + 1)
            {
                PlayerPrefs.SetInt("Score", 0);
                PlayerPrefs.SetFloat("timerEnd", Time.time);
                PlayerPrefs.SetString("status", "lost");
                PlayerPrefs.SetInt("Score", GameObject.Find("Player").GetComponent<Score_manager>().getScore());
                Application.LoadLevel("Level end");
            }
        }

        if (gameIsWin)
        {
            camera.transform.LookAt(GameObject.Find("Player").transform);
            camera.transform.Translate(Vector3.right * Time.deltaTime);
            GameOverText.text = "You win\n Push a button to continu";
            if (Input.anyKey && Time.time > now + 1)
            {
                PlayerPrefs.SetInt("Score", GameObject.Find("Player").GetComponent<Score_manager>().getScore());
                PlayerPrefs.SetString("status", "win");
                PlayerPrefs.SetInt("Score", GameObject.Find("Player").GetComponent<Score_manager>().getScore());
                Application.LoadLevel("Level end");
            }
        }
    }

    public void gameIsOver()
    {
        if (isGameOver == false)
        {
            now = Time.time;
        }
        isGameOver = true;
    }

    public bool getGameOver()
    {
        return isGameOver;
    }

    public void GameisWin()
    {
        if (gameIsWin == false)
        {
            now = Time.time;
        }
        gameIsWin = true;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private bool isGameOver = false;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Text GameOverText;

    private bool gameIsWin = false;

    private float now;

    //Met gameover vide 
    void Start()
    {
        GameOverText.text = "";
    }

    void Update()
    {
        //Si le joueur a perdu
        if (isGameOver)
        {
            // la camera tourne autour du joueur et indique que le joueur a perdu en écrivant Game Over sur l'écran. Au click du joueur renvoie 0 de score, la défaite du joueur et lance la fenetre de fin de niveau
            camera.transform.LookAt(GameObject.Find("Player").transform);
            camera.transform.Translate(Vector3.right * Time.deltaTime);
            GameOverText.text = "Game Over\n Push a button to continu";
            if (Input.anyKey && Time.time > now + 1)
            {
                PlayerPrefs.SetInt("Score", 0);
                PlayerPrefs.SetString("status", "lost");
                PlayerPrefs.SetInt("Score", GameObject.Find("Player").GetComponent<Score_manager>().getScore());
                Application.LoadLevel("Level end");
            }
        }

        //Si le joueur a gagné
        if (gameIsWin)
        {
            //la camera tourne autour du joueur et indique que le joueur a perdu en écrivant Win , Au click du joueur renvoie le score, la défaite du joueur et lance la fenetre de fin de niveau
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

    //Lance la fin de la partie défaite
    public void gameIsOver()
    {
        if (isGameOver == false)
        {
            now = Time.time;
        }
        isGameOver = true;
    }

    //Renvoie si le joueur a perdu ou non
    public bool getGameOver()
    {
        return isGameOver;
    }

    //Lance la fin de partie victoire
    public void GameisWin()
    {
        if (gameIsWin == false)
        {
            now = Time.time;
        }
        gameIsWin = true;
    }
}

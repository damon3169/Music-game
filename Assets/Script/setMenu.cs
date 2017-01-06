using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setMenu : MonoBehaviour
{

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text higScoreText;

    public Button buttonMenu;



    // Affiche la victoireo défaite du joueur / le score du joueur/ le high score du joueur et la possibilité de revenir au menu
    void Start()
    {
        levelText.text = PlayerPrefs.GetString("level_name") + " " + PlayerPrefs.GetString("status");

        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");

        if (PlayerPrefs.GetInt(PlayerPrefs.GetString("level_name") + "HighScore") < PlayerPrefs.GetInt("Score") && PlayerPrefs.GetString("status")!="lost")
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("level_name") + "HighScore", PlayerPrefs.GetInt("Score"));
        }

        higScoreText.text = "HighScore: " + PlayerPrefs.GetInt(PlayerPrefs.GetString("level_name") + "HighScore");

        buttonMenu.onClick.AddListener(onClickMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onClickMenu()
    {
        Application.LoadLevel("Menu");
    }
}

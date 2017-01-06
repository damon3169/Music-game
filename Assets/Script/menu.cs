using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    public Button Leave;
    public Button Level;


    // Use this for initialization
    void Start()
    {
        Leave.onClick.AddListener(onClickLeave);

        Level.onClick.AddListener(onClickLevel);


    }

    // Update is called once per frame
    void Update()
    {

    }

    //Quit quand le joueur click sur quitter
    void onClickLeave()
    {
        Application.Quit();
    }

    //Change d'écran quand le joueur click sur select levels
    void onClickLevel()
    {
        Application.LoadLevel("Levels");
    }
}

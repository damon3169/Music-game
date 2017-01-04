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

    void onClickLeave()
    {
        Application.Quit();
    }

	 void onClickLevel()
    {
        Application.LoadLevel("Levels");
    }
}

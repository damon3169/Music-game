using UnityEngine;
using UnityEngine.UI;


public class setLevels : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button Back;



    // Use this for initialization
    void Start()
    {
        level1.onClick.AddListener(() => launchLevel(level1));
        if (PlayerPrefs.GetInt(level1.gameObject.name + "HighScore") != 0)
        {
            level2.gameObject.SetActive(true);
            level2.onClick.AddListener(() => launchLevel(level2));
        }
        if (PlayerPrefs.GetInt(level2.gameObject.name + "HighScore") != 0)
        {
            level3.gameObject.SetActive(true);
            level3.onClick.AddListener(() => launchLevel(level3));
        }

        Back.onClick.AddListener(back);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void launchLevel(Button level)
    {
        Application.LoadLevel(level.gameObject.name);
    }

    void back()
    {
        Application.LoadLevel("Menu");
    }
}

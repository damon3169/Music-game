using UnityEngine;
using System.Collections;

public class Hitting : MonoBehaviour
{

    private bool isHitting = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Set si le joueur frappe ou non
    public void setIsHitting(bool newState)
    {
        isHitting = newState;
    }

    //get si le joueur frappe ou non
    public bool getIsHitting()
    {
        return isHitting;
    }
}

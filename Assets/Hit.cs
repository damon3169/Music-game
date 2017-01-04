using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour
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

    public void setIsHitting(bool newState)
    {
        isHitting = newState;
    }

    public bool getIsHitting()
    {
        return isHitting;
    }
}

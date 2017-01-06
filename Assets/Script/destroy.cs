using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour
{


    private ParticleSystem ps;
    // Use this for initialization
    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
    }

    // Détruit la particule si l'effet est fini
    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}

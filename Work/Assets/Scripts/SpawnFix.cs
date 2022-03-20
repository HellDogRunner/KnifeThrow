using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Apple")
        {
            Destroy(collision.gameObject);

        }
        if (collision.tag == "Knife")
        {
            Destroy(gameObject);
        }
    }

}

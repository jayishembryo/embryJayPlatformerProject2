using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILL : MonoBehaviour
{
    public Stage2GameController stage2GameControllerInstance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
        {

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Collectable")
        {

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Upgrade")
        {

            Destroy(collision.gameObject);
            stage2GameControllerInstance.wrenchOnscreen = false;

        }

    }
}

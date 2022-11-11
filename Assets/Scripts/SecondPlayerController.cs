using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float jumpforce = 40;
    public Stage2GameController stage2GameControllerInstance;
    public AudioClip crash;
    public AudioClip collect;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            rb2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            if (SuperGameController.lives >= 1)
            {

                stage2GameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = crash;
                GetComponent<AudioSource>().Play();

            }

        }

        if (collision.gameObject.tag == "Collectable")
        {

            if (SuperGameController.lives >= 1)
            {

                stage2GameControllerInstance.CollectableScore();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = collect;
                GetComponent<AudioSource>().Play();

            }

            if (stage2GameControllerInstance.gasText == true)
            {

                stage2GameControllerInstance.gasInstructions.SetActive(false);
                stage2GameControllerInstance.gasText = false;

            }

        }

        if (collision.gameObject.tag == "Upgrade")
        {

            if (SuperGameController.lives >= 1)
            {

                Destroy(collision.gameObject);
                stage2GameControllerInstance.NextScene();

            }
           

        }
    }

}

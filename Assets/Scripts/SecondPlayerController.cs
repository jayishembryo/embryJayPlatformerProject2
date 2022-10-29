using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float jumpforce = 7;
    public Stage2GameController Stage2GameControllerInstance;
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

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            Stage2GameControllerInstance.GetHit();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = crash;
            GetComponent<AudioSource>().Play();

        }

        if (collision.gameObject.tag == "Collectable")
        {

            Stage2GameControllerInstance.CollectableScore();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = collect;
            GetComponent<AudioSource>().Play();

        }
    }

}

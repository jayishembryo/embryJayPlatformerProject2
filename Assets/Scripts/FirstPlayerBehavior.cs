using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerBehavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float jumpforce = 7;
    public ProtoGameController ProtoGameControllerInstance;
    public AudioClip crash;
    public AudioSource sound;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();


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

            ProtoGameControllerInstance.GetHit();
            Destroy(collision.gameObject);
            sound.clip = crash;
            sound.PlayOneShot(crash);

        }
    }

}
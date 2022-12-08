using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerBehavior : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    public float Jumpforce = 40;
    public ProtoGameController ProtoGameControllerInstance;
    public AudioClip Crash;
    public AudioClip Honk;
    public AudioClip Health;
    public Animator CarAnimator;
    //  public Animator Restore1;
    //  public Animator Restore2;

    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            Rb2d.AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            Rb2d.AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);

        }

        if (SuperGameController.Lives == 2)
        {

            CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

        }

        if (SuperGameController.Lives == 1)
        {

            CarAnimator.SetInteger("Lives1", SuperGameController.Lives);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            GetComponent<AudioSource>().clip = Honk;
            GetComponent<AudioSource>().Play();

        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            if (SuperGameController.Lives >= 1)
            {

                ProtoGameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Crash;
                GetComponent<AudioSource>().Play();
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);


            }

        }

        if (collision.gameObject.tag == "Fixt")
        {

            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = Health;
            GetComponent<AudioSource>().Play();

            if (SuperGameController.Lives < 3)
            {

                SuperGameController.Lives += 1;
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

                if (ProtoGameControllerInstance.SweatsActive == true)
                {

                    ProtoGameControllerInstance.Sweats.SetActive(false);
                    ProtoGameControllerInstance.SweatsActive = false;

                }

            }
        }
    }



}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    public float Jumpforce = 40;
    public Stage2GameController Stage2GameControllerInstance;
    public AudioClip Crash;
    public AudioClip Collect;
    public AudioClip Honk;
    public Animator HitOnce;
    public Animator DriveDamaged;
    public Animator HitTwice;
    public Animator DriveDamaged2;
    public Animator Jumping;
    public Animator Jumping2;
    public Animator Jumping3;
    public Animator Return;
    public Animator Return2;
    public Animator Return3;
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

            if (SuperGameController.Lives == 3)
            {

                Jumping.SetTrigger("Woohoo");

            }

            if (SuperGameController.Lives == 2)
            {

                Jumping2.SetTrigger("Woohoo2");

            }

            if (SuperGameController.Lives == 1)
            {

                Jumping2.SetTrigger("Woohoo3");

            }

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            Rb2d.AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);

            if (SuperGameController.Lives == 3)
            {

                Jumping.SetTrigger("Woohoo");

            }

            if (SuperGameController.Lives == 2)
            {

                Jumping2.SetTrigger("Woohoo2");

            }

            if (SuperGameController.Lives == 1)
            {

                Jumping2.SetTrigger("Woohoo3");

            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            if (SuperGameController.Lives == 3)
            {

                Return.SetTrigger("NoWoohoo");

            }

            if (SuperGameController.Lives == 2)
            {

                Return2.SetTrigger("NoWoohoo2");

            }

            if (SuperGameController.Lives == 1)
            {

                Return3.SetTrigger("NoWoohoo3");

            }

        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            if (SuperGameController.Lives == 3)
            {

                Return.SetTrigger("NoWoohoo");

            }

            if (SuperGameController.Lives == 2)
            {

                Return2.SetTrigger("NoWoohoo2");

            }

            if (SuperGameController.Lives == 1)
            {

                Return3.SetTrigger("NoWoohoo3");

            }

        }

        if (SuperGameController.Lives == 2)
        {

            DriveDamaged.SetInteger("Lives2", SuperGameController.Lives);

        }

        if (SuperGameController.Lives == 1)
        {

            DriveDamaged2.SetInteger("Lives1", SuperGameController.Lives);

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

                Stage2GameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Crash;
                GetComponent<AudioSource>().Play();

                 if (SuperGameController.Lives == 2)
                {

                    HitOnce.SetTrigger("IsHit");

                }

                if (SuperGameController.Lives == 1)
                {

                    HitTwice.SetTrigger("IsHit2");

                }

            }

        }

        if (collision.gameObject.tag == "Collectable")
        {

            if (SuperGameController.Lives >= 1)
            {

                Stage2GameControllerInstance.RestoreGas();
                Stage2GameControllerInstance.CollectableScore();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Collect;
                GetComponent<AudioSource>().Play();

            }

            if (Stage2GameControllerInstance.GasText == true)
            {

                Stage2GameControllerInstance.GasInstructions.SetActive(false);
                Stage2GameControllerInstance.GasText = false;

            }

        }

        if (collision.gameObject.tag == "Upgrade")
        {

            if (SuperGameController.Lives >= 1)
            {

                Destroy(collision.gameObject);
                Stage2GameControllerInstance.UpgradeAquired();

            }
           

        }
    }

}

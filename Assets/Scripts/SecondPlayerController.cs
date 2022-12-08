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
    public AudioClip Health;
    public Animator CarAnimator;
   
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

                Stage2GameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Crash;
                GetComponent<AudioSource>().Play();
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);
                // if (SuperGameController.Lives == 2)
                //{

                //    //HitOnce.SetTrigger("IsHit");

                //}

                //if (SuperGameController.Lives == 1)
                //{

                //    //HitTwice.SetTrigger("IsHit2");

                //}
                

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

        if (collision.gameObject.tag == "Fixt")
        {

            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = Health;
            GetComponent<AudioSource>().Play();

            if (SuperGameController.Lives < 3)
            {

                SuperGameController.Lives += 1;
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

                if (Stage2GameControllerInstance.SweatsActive == true)
                {

                    Stage2GameControllerInstance.Sweats.SetActive(false);

                }


            }
            //if (SuperGameController.Lives == 3)
            //{

            //    SuperGameController.Lives += 1;
            //    CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

            //}

            //if (SuperGameController.Lives == 2)
            //{

            //    SuperGameController.Lives += 1;
            //    CarAnimator.SetInteger("Lives2", SuperGameController.Lives);
            //}


        }

    }

}

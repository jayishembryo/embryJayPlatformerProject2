using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D Rb2d;
    public float Jumpforce = 40;
    public GameController GameControllerInstance;
    public Coroutine RamRoutine;
    public Coroutine RamRoutineEnd;
    public AudioClip Crash;
    public AudioClip Collect;
    public AudioClip Kill;
    public AudioClip Honk;
    public AudioClip Health;
    public Animator CarAnimator;
    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();

    }


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(RamRoutine == null)
            {

                RamRoutine = StartCoroutine(RamForward()); 

            }

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
    public IEnumerator RamForward()
    {

        if (SuperGameController.Lives == 3)
        {

            CarAnimator.SetTrigger("Dash1");

        }

        if (SuperGameController.Lives == 2)
        {

            CarAnimator.SetTrigger("Dash2");

        }

        if (SuperGameController.Lives == 1)
        {

            CarAnimator.SetTrigger("Dash3");

        }

        float finalPosition = transform.position.x + 4;
        float startPosition = transform.position.x;

        var dashTimer = 0.5f;
        var dashTimerMax = dashTimer; 

        while (dashTimer>0)
        {
            dashTimer -= Time.deltaTime;
            var xPos = Mathf.Lerp(startPosition, finalPosition, 1- (dashTimer/dashTimerMax));
            transform.position = new Vector2(xPos, transform.position.y);
            yield return null; 

        }

        RamRoutineEnd = StartCoroutine(FallBack());

    }

    public IEnumerator FallBack()
    {
        if (SuperGameController.Lives == 3)
        {

            CarAnimator.SetTrigger("NoDash1");

        }

        if (SuperGameController.Lives == 2)
        {

            CarAnimator.SetTrigger("NoDash2");

        }

        if (SuperGameController.Lives == 1)
        {

            CarAnimator.SetTrigger("NoDash3");

        }

        RamRoutine = null;
        float finalPosition = transform.position.x - 4;
        float startPosition = transform.position.x;

        var dashTimer = 1f;
        var dashTimerMax = dashTimer;

        while (dashTimer > 0)
        {

            dashTimer -= Time.deltaTime;
            var xPos = Mathf.Lerp(startPosition, finalPosition, 1 - (dashTimer / dashTimerMax));
            transform.position = new Vector2(xPos, transform.position.y);
            yield return null;

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            if (SuperGameController.Lives >= 1)
            {

                GameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Crash;
                GetComponent<AudioSource>().Play();
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

            }

        }

        if (collision.gameObject.tag == "Collectable")
        {

            if (SuperGameController.Lives >= 1)
            {

                GameControllerInstance.RestoreGas();
                GameControllerInstance.CollectableScore();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = Collect;
                GetComponent<AudioSource>().Play();

            }
         

        }

        if (collision.gameObject.tag == "Enemy")
        {

            if (SuperGameController.Lives >= 1)
            {

                if (RamRoutine == null)
                {

                    GameControllerInstance.GetHit();
                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().clip = Crash;
                    GetComponent<AudioSource>().Play();

                }

                if (RamRoutine != null)
                {

                    GameControllerInstance.EnemyScore();
                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().clip = Kill;
                    GetComponent<AudioSource>().Play();

                }

            }
            

        }

        if (collision.gameObject.tag == "Fixt")
        {

            Destroy(collision.gameObject);


            if (SuperGameController.Lives < 3)
            {

                SuperGameController.Lives += 1;
                CarAnimator.SetInteger("Lives2", SuperGameController.Lives);

                if (GameControllerInstance.SweatsActive == true)
                {

                    GameControllerInstance.Sweats.SetActive(false);

                }

            }


        }

    }

}







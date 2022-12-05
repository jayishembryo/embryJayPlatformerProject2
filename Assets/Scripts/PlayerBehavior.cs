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
    public Animator Dash1;
    public Animator Dash2;
    public Animator Dash3;
    public Animator NoDash1;
    public Animator NoDash2;
    public Animator NoDash3;
    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();

    }


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(RamRoutine == null)
            {

                RamRoutine = StartCoroutine(RamForward()); 

            }

            if (SuperGameController.Lives == 3)
            {

                Dash1.SetTrigger("Dash1");

            }

            if (SuperGameController.Lives == 2)
            {

                Dash2.SetTrigger("Dash2");

            }

            if (SuperGameController.Lives == 1)
            {

                Dash3.SetTrigger("Dash3");

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
    public IEnumerator RamForward()
    {
        float finalPosition = transform.position.x + 4;
        float goalTime = Time.time + 2;
        float xPos = transform.position.x;
        while (Time.time < goalTime)
        {

            float percentage = Time.time / goalTime;
            xPos = Mathf.Lerp(xPos, finalPosition, percentage);
            transform.position = new Vector2(xPos, transform.position.y);
            yield return null; 

        }

        RamRoutineEnd = StartCoroutine(FallBack());

    }

    public IEnumerator FallBack()
    {
        if (SuperGameController.Lives == 3)
        {

            NoDash1.SetTrigger("NoDash1");

        }

        if (SuperGameController.Lives == 2)
        {

            NoDash2.SetTrigger("NoDash2");

        }

        if (SuperGameController.Lives == 1)
        {

            NoDash3.SetTrigger("NoDash3");

        }
        RamRoutine = null;
        float finalPosition = transform.position.x - 4;
        float goalTime = Time.time + 1;
        float xPos = transform.position.x;
        while (Time.time < goalTime)
        {

            float percentage = Time.time / goalTime;
            xPos = Mathf.Lerp(xPos, finalPosition, percentage);
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

                    if (SuperGameController.Lives == 2)
                    {

                        HitOnce.SetTrigger("IsHit");

                    }

                    if (SuperGameController.Lives == 1)
                    {

                        HitTwice.SetTrigger("IsHit2");

                    }

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

    }

}







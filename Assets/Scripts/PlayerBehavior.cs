using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float jumpforce = 40;
    public GameController gameControllerInstance;
    public Coroutine ramRoutine;
    public Coroutine ramRoutineEnd;
    public AudioClip crash;
    public AudioClip collect;
    public AudioClip kill;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(ramRoutine == null)
            {
                ramRoutine = StartCoroutine(RamForward()); 
            }
           

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

        ramRoutineEnd = StartCoroutine(FallBack());

    }

    public IEnumerator FallBack()
    {

        ramRoutine = null;
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

            if (SuperGameController.lives >= 1)
            {

                gameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = crash;
                GetComponent<AudioSource>().Play();

            }

        }

        if (collision.gameObject.tag == "Collectable")
        {

            if (SuperGameController.lives >= 1)
            {

                gameControllerInstance.CollectableScore();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = collect;
                GetComponent<AudioSource>().Play();

            }
         

        }

        if (collision.gameObject.tag == "Enemy")
        {

            if (SuperGameController.lives >= 1)
            {

                if (ramRoutine == null)
                {

                    gameControllerInstance.GetHit();
                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().clip = crash;
                    GetComponent<AudioSource>().Play();

                }

                if (ramRoutine != null)
                {

                    gameControllerInstance.EnemyScore();
                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().clip = kill;
                    GetComponent<AudioSource>().Play();

                }

            }
            

        }

    }

}







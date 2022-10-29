using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float jumpforce = 7;
    public GameController GameControllerInstance;
    public Coroutine RamRoutine;
    public Coroutine RamRoutineEnd;
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

         if (Input.GetKeyDown(KeyCode.Space))
        {
            if(RamRoutine == null)
            {
                RamRoutine = StartCoroutine(RamForward()); 
            }
           

        }



    }
    public IEnumerator RamForward()
    {
        float finalPosition = transform.position.x + 7;
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

        float finalPosition = transform.position.x - 7;
        float goalTime = Time.time + 1;
        float xPos = transform.position.x;
        while (Time.time < goalTime)
        {

            float percentage = Time.time / goalTime;
            xPos = Mathf.Lerp(xPos, finalPosition, percentage);
            transform.position = new Vector2(xPos, transform.position.y);
            yield return null;

        }

        RamRoutine = null;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            GameControllerInstance.GetHit();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = crash;
            GetComponent<AudioSource>().Play();

        }

        if (collision.gameObject.tag == "Collectable")
        {

            GameControllerInstance.CollectableScore();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().clip = collect;
            GetComponent<AudioSource>().Play();

        }

        if (collision.gameObject.tag == "Enemy")
        {

            if (RamRoutine == null)
            {

                GameControllerInstance.GetHit();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = crash;
                GetComponent<AudioSource>().Play();

            }

            if (RamRoutine != null)
            {

                GameControllerInstance.EnemyScore();
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().clip = kill;
                GetComponent<AudioSource>().Play();

            }

        }

    }

}







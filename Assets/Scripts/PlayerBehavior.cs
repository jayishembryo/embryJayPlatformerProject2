using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float jumpforce = 7;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
       
        //if (Input.GetKeyDown(KeyCode.Space))
        {



        }

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        }


        // if (Input.GetKeyDown(KeyCode.Space))
        {



        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       // if (collision.gameObject.tag == "Platform") 
        {

           // if (Input.GetKeyUp(KeyCode.DownArrow))

            {

                

            }

        }

    }

}

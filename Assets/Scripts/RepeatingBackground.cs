using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float scrollSpeed = 6;
    public const float ScrollWidth = 6;
    void Start()
    {

   

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;

        pos.x -= scrollSpeed * Time.deltaTime;

        transform.position = pos;

    //  if (transform.position.x < -ScrollWidth)
        {


        }


    }


}

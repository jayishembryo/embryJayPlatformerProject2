using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float scrollSpeed = 6;
    public const float ScrollWidth = 5;
    void Start()
    {

   

    }

    // Update is called once per frame
    void Update()
    {


        Vector2 pos = transform.position;

        pos.x -= scrollSpeed * Time.deltaTime;

        transform.position = pos;

      if (transform.position.x < -ScrollWidth)
        {

            Offscreen(ref pos);

        }

        transform.position = pos;

    }

    public virtual void Offscreen(ref Vector2 pos)
    {

        pos.x += 2 * ScrollWidth;

    }


}

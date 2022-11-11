using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float scrollSpeed = 7;
    public const float scrollWidth = 5;
    void Start()
    {

   

    }

    // Update is called once per frame
    void Update()
    {


        Vector2 pos = transform.position;

        pos.x -= scrollSpeed * Time.deltaTime;

        transform.position = pos;

      if (transform.position.x < -scrollWidth)
        {

            Offscreen(ref pos);

        }

        transform.position = pos;

    }

    public virtual void Offscreen(ref Vector2 pos)
    {

        pos.x += 2 * scrollWidth;

    }


}

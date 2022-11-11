using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchMovement : MonoBehaviour
{
    public int scrollSpeed = 5;
    public Rigidbody2D rb2d;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;

        pos.x -= scrollSpeed * Time.deltaTime;

        transform.position = pos;

    }


}

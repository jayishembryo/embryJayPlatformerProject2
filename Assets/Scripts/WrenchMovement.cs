using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchMovement : MonoBehaviour
{
    public int ScrollSpeed = 4;
    public Rigidbody2D Rb2d;
    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;

        pos.x -= ScrollSpeed * Time.deltaTime;

        transform.position = pos;

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformEffector2D platformEffect;
    void Start()
    {

        platformEffect = GetComponent<PlatformEffector2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            platformEffect.transform.rotation = Quaternion.Euler(0, 0, 180);

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            platformEffect.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            platformEffect.transform.rotation = Quaternion.Euler(0, 0, 180);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {

            platformEffect.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}

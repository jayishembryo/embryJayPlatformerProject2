using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformEffector2D PlatformEffect;
    void Start()
    {

        PlatformEffect = GetComponent<PlatformEffector2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            PlatformEffect.transform.rotation = Quaternion.Euler(0, 0, 180);

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            PlatformEffect.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            PlatformEffect.transform.rotation = Quaternion.Euler(0, 0, 180);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {

            PlatformEffect.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGameController : MonoBehaviour
{
    public static SuperGameController Instance;
    public static int score;
    public static int lives = 3;
    void Start()
    {
        
        if (Instance != null)
        {

            Instance = this;

        }
        else
        {

          //  Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

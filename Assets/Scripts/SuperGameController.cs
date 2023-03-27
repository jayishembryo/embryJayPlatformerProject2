using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGameController : MonoBehaviour
{
    public static SuperGameController Instance;
    public static int Score;
    public static int FinalScore;
    public static int Lives = 3;
    public static float GasMax = 100;
    public static float NewGas = 100;

    void Start()
    {

        GetComponent<AudioSource>().Play();
        if (Instance == null)
        {

            Instance = this;

        }
        else
        {

            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {

        if (Lives <= 0)
        {

            GetComponent<AudioSource>().Pause();

        }

    }

}

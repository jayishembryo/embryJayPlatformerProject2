using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProtoGameController : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject EndScreen;
    public GameObject Obstacle;
    public GameObject OhNo;
    public GameObject Player;
    public GameObject Sweats;
    public GameObject Scores;
    public GameObject Honk;
    public GameObject Fixt;
    public int RandomY;
    public float CurrentTimer;
    public TMP_Text ScoreText;
    public TMP_Text FinalScoreText;
    public float Timer = 0.0f;
    public float Timer2 = 0.0f;
    public bool TimerStart;
    public bool SpawnTime;
    public bool SweatsActive;
    public SuperGameController Instance;
    public FirstPlayerBehavior FirstPlayerBehaviorInstance;
    public Animator LevelOneTransition;
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (!TimerStart)
            {

                Instructions.SetActive(false);
                TimerStart = true;
                SpawnTime = true;
                InvokeRepeating("IncreaseScore", 2, 2);
                InvokeRepeating("AddToTimer", 1, 1);

            }

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (!TimerStart)
            {

                Instructions.SetActive(false);
                TimerStart = true;
                SpawnTime = true;
                InvokeRepeating("IncreaseScore", 2, 2);
                InvokeRepeating("AddToTimer", 1, 1);

            }

        }


        if (SpawnTime)
        {
            CurrentTimer -= Time.deltaTime;
            if (CurrentTimer < 0)
            {

                CurrentTimer = 1;

                if (Timer !=30)
                {

                    ObstacleSpawn();

                }

                if(Timer==30)
                {

                    FixtSpawn();

                }

            }

        }


        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);
            SuperGameController.Score = 0;
            SuperGameController.Lives = 3;

        }

        if (Input.GetKey(KeyCode.Escape))
        {

            Application.Quit();

        }


        if (Input.GetKeyDown(KeyCode.X))
        {

            Honk.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.X))
        {

            Honk.SetActive(false);

        }

    }


    public void ObstacleSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        RandomY = Random.Range(1, 4);

        if (RandomY == 1)
        {

            obsPos.y = 4.14f;

        }

        if (RandomY == 2)
        {

            obsPos.y = 2.07f;

        }

        if (RandomY == 3)
        {

            obsPos.y = -0.1316612f;

        }

        Instantiate(Obstacle, obsPos, Quaternion.identity);

    }

    public void FixtSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        RandomY = Random.Range(0, 3);

        if(RandomY==0)
        {

            obsPos.y = 2.76f;

        }

        if(RandomY==1)
        {

            obsPos.y = 5.09f;

        }

        if(RandomY==2)
        {


            obsPos.y = 6.98f;

        }

        Instantiate(Fixt, obsPos, Quaternion.identity);

    }

    public void GetHit()
    {
        if (SuperGameController.Lives >= 1)
        {

            SuperGameController.Lives = SuperGameController.Lives -= 1;
            if (SuperGameController.Lives <= 0)
            {


                TimerStart = false;
                SpawnTime = false;
                Timer = 0.0f;
                GameOver();

            }

        }

        if (SuperGameController.Lives < 2)
        {

            Sweats.SetActive(true);
            SweatsActive = true;

        }

    }

    public void GameOver()
    {

        EndScreen.SetActive(true);
        Scores.SetActive(false);


    }

    public void IncreaseScore()
    {

        if (SuperGameController.Lives >= 1)
        {

            SuperGameController.Score += 5;
            ScoreText.text = SuperGameController.Score.ToString();
            SuperGameController.FinalScore += 5;
            FinalScoreText.text = SuperGameController.Score.ToString();


        }

    }

    public void AddToTimer()
    {

        Timer = Timer += 1;

        if (Timer >= 60)
        {

            if (SuperGameController.Lives >= 1)
            {

                SpawnTime = false;
                OhNo.SetActive(true);
               // AddToTimer2();
                //play animation 
                LevelOneTransition.SetTrigger("Transition");
                if (SweatsActive == false)
                {

                    Sweats.SetActive(true);

                }
                


            }

        }

    }

    public void AddToTimer2()
    {

        Timer2 = Timer2 += 1;

        if (Timer2 >= 5)
        {

            SceneManager.LoadScene(2);

        }

    }

}

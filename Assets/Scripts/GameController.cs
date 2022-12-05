using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject EndScreen;
    public GameObject GasBar;
    public GameObject Obstacle;
    public GameObject Collectable;
    public GameObject RamInstructions;
    public GameObject Sweats;
    public GameObject Scores;
    public GameObject Honk;
    public int RandomY;
    public float CurrentTimer;
    public TMP_Text ScoreText;
    public TMP_Text FinalScoreText;
    public float Timer = 0.0f;
    public bool TimerStart;
    public bool SpawnTime;
    public bool RamText = true;
    public bool SweatsActive = false;
    public GameObject Enemy;
    public int RandomS;
    public PlayerBehavior PlayerBehaviorInstance;
    public Image GasTracker;
  




    void Start()
    {

        ScoreText.text = SuperGameController.Score.ToString();
        TimerStart = true;
        SpawnTime = true;
        InvokeRepeating("IncreaseScore", 2, 2);
        InvokeRepeating("LowerGasLevel", 1, 1);
        GasTracker.fillAmount = Mathf.Clamp01(SuperGameController.NewGas / SuperGameController.GasMax);
        if (SuperGameController.Lives < 2)
        {

            Sweats.SetActive(true);
            SweatsActive = true;

        }

    }

    // Update is called once per frame
    void Update()
    {



        if (SpawnTime)
        {
            CurrentTimer -= Time.deltaTime;
            if (CurrentTimer < 0)
            {

                RandomSpawn();
                CurrentTimer = 1;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (RamText == true)
            {

                RamInstructions.SetActive(false);
                RamText = false;

            }

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

    void RandomSpawn()
    {


        RandomS = Random.Range(0, 10);

        if (RandomS == 0 || RandomS == 1 || RandomS == 2 || RandomS == 3 || RandomS == 4 || RandomS == 5)
        {

            ObstacleSpawn();

        }

        if (RandomS == 9)
        {

            CollectableSpawn();

        }

        if (RandomS == 6 || RandomS == 7 || RandomS == 8)
        {

            EnemySpawn();

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


    void CollectableSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        RandomY = Random.Range(1, 4);

        if (RandomY == 1)
        {

            obsPos.y = 3.82f;

        }

        if (RandomY == 2)
        {

            obsPos.y = 1.75f;

        }

        if (RandomY == 3)
        {

            obsPos.y = -0.4358903f;

        }

        Instantiate(Collectable, obsPos, Quaternion.identity); ;

    }

    void EnemySpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        RandomY = Random.Range(1, 4);

        if (RandomY == 1)
        {

            obsPos.y = 3.92f;

        }

        if (RandomY == 2)
        {

            obsPos.y = 1.8f;

        }

        if (RandomY == 3)
        {

            obsPos.y = -0.3661088f;

        }

        Instantiate(Enemy, obsPos, Quaternion.identity);
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

            if (SweatsActive == false)
            {

                Sweats.SetActive(true);

            }

        }

    }


    public void CollectableScore()
    {

        SuperGameController.Score = SuperGameController.Score += 10;
        ScoreText.text = SuperGameController.Score.ToString();
        SuperGameController.FinalScore += 10;
        FinalScoreText.text = SuperGameController.Score.ToString();

    }

    public void EnemyScore()
    {

        SuperGameController.Score = SuperGameController.Score += 20;
        ScoreText.text = SuperGameController.Score.ToString();
        SuperGameController.FinalScore += 20;
        FinalScoreText.text = SuperGameController.Score.ToString();

    }

    public void GameOver()
    {

        EndScreen.SetActive(true);
        Scores.SetActive(false);
        GasBar.SetActive(false);

        if (RamText == true)
        {

            RamInstructions.SetActive(false);
            RamText = false;

        }


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

    public void LowerGasLevel()
    {

        if (SuperGameController.Lives >= 1)
        {

            GasTracker.fillAmount = Mathf.Clamp01(SuperGameController.NewGas / SuperGameController.GasMax);
            SuperGameController.NewGas -= 1;

            if (SuperGameController.NewGas == 0)
            {

                TimerStart = false;
                SpawnTime = false;
                Timer = 0.0f;
                GameOver();

            }

        }

    }

    public void RestoreGas()
    {

        GasTracker.fillAmount = Mathf.Clamp01(SuperGameController.NewGas / SuperGameController.GasMax);
        SuperGameController.NewGas = 100;

    }
}

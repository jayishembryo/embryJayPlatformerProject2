using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2GameController : MonoBehaviour
{

    public GameObject EndScreen;
    public GameObject GasBar;
    public GameObject Obstacle;
    public GameObject Collectable;
    public GameObject Upgrade;
    public GameObject Player;
    public GameObject GearText;
    public GameObject GasInstructions;
    public GameObject CarUpgraded;
    public GameObject Sweats;
    public GameObject Yippee;
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
    public bool CarUpgradedTrue = false;
    public int RandomS;
    public SuperGameController Instance;
    public SecondPlayerController SecondPlayerControllerInstance;
    public bool WrenchOnscreen;
    public bool GasText = true;
    public bool SweatsActive = false;
    public Image GasTracker;
    void Start()
    {
        ScoreText.text = SuperGameController.Score.ToString();
        SpawnTime = true;
        InvokeRepeating("IncreaseScore", 2, 2);
        InvokeRepeating("AddToTimer", 1, 1);
        WrenchOnscreen = false;
        InvokeRepeating("LowerGasLevel", 1, 1);
        if (SuperGameController.Lives < 2)
        {

            Sweats.SetActive(true);
            SweatsActive = true;

        }

    }

    void Update()
    {


        if (SpawnTime)
        {
            CurrentTimer -= Time.deltaTime;
            if (CurrentTimer < 0)
            {

                CurrentTimer = 1;

                if (Timer != 30)
                {

                    RandomSpawn();

                }

                if (Timer == 30)
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

    void RandomSpawn()
    {


        RandomS = Random.Range(0, 10);

        if (RandomS == 0 || RandomS == 1 || RandomS == 2 || RandomS == 3 || RandomS == 4 || RandomS == 5 || RandomS == 6 || RandomS == 7)
        {

            ObstacleSpawn();

        }

        if (RandomS == 8 || RandomS == 9)
        {

            CollectableSpawn();

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

    public void FixtSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        RandomY = Random.Range(0, 3);

        if (RandomY == 0)
        {

            obsPos.y = 2.76f;

        }

        if (RandomY == 1)
        {

            obsPos.y = 5.09f;

        }

        if (RandomY == 2)
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

    public void GameOver()
    {

        EndScreen.SetActive(true);
        Scores.SetActive(false);
        GasBar.SetActive(false);

        if (GasText == true)
        {

            GasInstructions.SetActive(false);
            GasText = false;

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

    public void AddToTimer()
    {

        Timer = Timer += 1;

        if (Timer >= 60)
        {

            if (GasText == true)
            {

                GasInstructions.SetActive(false);
                GasText = false;

            }

            if (SuperGameController.Lives >= 1)
           {

                SpawnTime = false;
                

                if (CarUpgradedTrue == false)
                {

                    GearText.SetActive(true);

                }

                Vector3 obsPos = new Vector3();

                if (WrenchOnscreen == false)
                {

                    obsPos.x = RepeatingBackground.ScrollWidth;
                    obsPos.y = Player.transform.position.y;
                    Instantiate(Upgrade, obsPos, Quaternion.identity);
                    WrenchOnscreen = true;

                }

            }

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

    public void UpgradeAquired()
    {

        GearText.SetActive(false);
        CarUpgraded.SetActive(true);
        Yippee.SetActive(true);
        CarUpgradedTrue = true;
        //InvokeRepeating("AddToTimer2", 1, 1);

    }

    public void AddToTimer2()
    {

        Timer2 = Timer2 += 1;

        if (Timer2 >= 5)
        {

            SceneManager.LoadScene(3);

        }

    }

}

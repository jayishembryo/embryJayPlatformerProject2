using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject obstacle;
    public GameObject collectable;
    public GameObject ramInstructions;
    public int randomY;
    public float currentTimer;
    public TMP_Text scoreText;
    public TMP_Text tempTxt;
    public float timer = 0.0f;
    public bool timerStart;
    public bool spawnTime;
    public bool ramText = true;
    public GameObject enemy;
    public int randomS;
    public PlayerBehavior playerBehaviorInstance;
  




    void Start()
    {

        scoreText.text = SuperGameController.score.ToString();
        tempTxt.text = SuperGameController.lives.ToString();
        timerStart = true;
        spawnTime = true;
        InvokeRepeating("IncreaseScore", 2, 2);
        InvokeRepeating("AddToTimer", 1, 1);

    }

    // Update is called once per frame
    void Update()
    {



        if (spawnTime)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer < 0)
            {

                RandomSpawn();
                currentTimer = 1;

            }

        }


        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);
            SuperGameController.score = 0;
            SuperGameController.lives = 3;

        }

        if (Input.GetKey(KeyCode.Escape))
        {

            Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (ramText == true)
            {

                ramInstructions.SetActive(false);
                ramText = false;

            }

        }

    }

    void RandomSpawn()
    {


        randomS = Random.Range(0, 10);

        if (randomS == 0 || randomS == 1 || randomS == 2 || randomS == 3 || randomS == 4 || randomS == 5)
        {

            ObstacleSpawn();

        }

        if (randomS == 9)
        {

            CollectableSpawn();

        }

        if (randomS == 6 || randomS == 7 || randomS == 8)
        {

            EnemySpawn();

        }
    }
    public void ObstacleSpawn()
    {

        Debug.Log("spawn Obstacle");
        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.scrollWidth;
        randomY = Random.Range(1, 4);

        if (randomY == 1)
        {

            obsPos.y = 4.6f;

        }

        if (randomY == 2)
        {

            obsPos.y = 2.68f;

        }

        if (randomY == 3)
        {

            obsPos.y = 0.3544002f;

        }

        Instantiate(obstacle, obsPos, Quaternion.identity);

    }


    void CollectableSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.scrollWidth;
        randomY = Random.Range(1, 4);

        if (randomY == 1)
        {

            obsPos.y = 3.98f;

        }

        if (randomY == 2)
        {

            obsPos.y = 2.12f;

        }

        if (randomY == 3)
        {

            obsPos.y = -0.1408f;

        }

        Instantiate(collectable, obsPos, Quaternion.identity); ;

    }

    void EnemySpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.scrollWidth;
        randomY = Random.Range(1, 4);

        if (randomY == 1)
        {

            obsPos.y = 4.1f;

        }

        if (randomY == 2)
        {

            obsPos.y = 2.09f;

        }

        if (randomY == 3)
        {

            obsPos.y = -0.07051057f;

        }

        Instantiate(enemy, obsPos, Quaternion.identity);
    }



    public void GetHit()
    {
        if (SuperGameController.lives >= 1)
        {

            SuperGameController.lives = SuperGameController.lives -= 1;
            tempTxt.text = SuperGameController.lives.ToString(); //this will be indicated by animations rather than text once sprite work and animations begin
            if (SuperGameController.lives <= 0)
            {


                timerStart = false;
                spawnTime = false;
                timer = 0.0f;
                GameOver();

            }

        }

    }


    public void CollectableScore()
    {

        SuperGameController.score = SuperGameController.score += 10;
        scoreText.text = SuperGameController.score.ToString();

    }

    public void EnemyScore()
    {

        SuperGameController.score = SuperGameController.score += 20;
        scoreText.text = SuperGameController.score.ToString();

    }

    public void GameOver()
    {

        endScreen.SetActive(true);

        if (ramText == true)
        {

            ramInstructions.SetActive(false);
            ramText = false;

        }


    }

    public void IncreaseScore()
    {

        if (SuperGameController.lives >= 1)
        {

            SuperGameController.score += 5;
            scoreText.text = SuperGameController.score.ToString();

        }

    }
}

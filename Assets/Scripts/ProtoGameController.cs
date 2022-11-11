using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProtoGameController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject endScreen;
    public GameObject obstacle;
    public int randomY;
    public float currentTimer;
    public TMP_Text scoreText;
    public TMP_Text tempTxt;
    public float timer = 0.0f;
    public bool timerStart;
    public bool spawnTime;
    public SuperGameController instance;
    public FirstPlayerBehavior firstPlayerBehaviorInstance;
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (!timerStart)
            {

                instructions.SetActive(false);
                timerStart = true;
                spawnTime = true;
                InvokeRepeating("IncreaseScore", 2, 2);
                InvokeRepeating("AddToTimer", 1, 1);

            }

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (!timerStart)
            {

                instructions.SetActive(false);
                timerStart = true;
                spawnTime = true;
                InvokeRepeating("IncreaseScore", 2, 2);
                InvokeRepeating("AddToTimer", 1, 1);

            }

        }


        if (spawnTime)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer < 0)
            {

                ObstacleSpawn();
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

    public void GameOver()
    {

        endScreen.SetActive(true);


    }

    public void IncreaseScore()
    {

        if (SuperGameController.lives >= 1)
        {

            SuperGameController.score += 5;
            scoreText.text = SuperGameController.score.ToString();

        }

    }

    public void AddToTimer()
    {

        timer = timer += 1;

        if (timer >= 30)
        {
            if (SuperGameController.lives >= 1)
            {

                SceneManager.LoadScene(2); // transitions can be implimented later on???

            }
                

        }

    }

}

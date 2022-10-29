using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Stage2GameController : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject obstacle;
    public GameObject collectable;
    public int randomY;
    public float currentTimer;
    public TMP_Text ScoreText;
    public TMP_Text TempTxt;
    public float timer = 0.0f;
    public bool timerStart;
    public bool spawnTime;
    public int randomS;
    public SuperGameController Instance;
    public SecondPlayerController SecondPlayerControllerInstance;
    void Start()
    {
        ScoreText.text = SuperGameController.Score.ToString();
        TempTxt.text = SuperGameController.Lives.ToString();
        spawnTime = true;
        InvokeRepeating("IncreaseScore", 2, 2);
        InvokeRepeating("AddToTimer", 1, 1);

    }

    void Update()
    {


        if (spawnTime)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer < 0)
            {

                RandomSpawn();
                currentTimer = 0.7f;

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

    }

    void RandomSpawn()
    {


        randomS = Random.Range(1, 3);

        if (randomS == 1)
        {

            ObstacleSpawn();

        }

        if (randomS == 2)
        {

            CollectableSpawn();

        }

    }

    void ObstacleSpawn()
    {
        Debug.Log("spawn Obstacle");
        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        randomY = Random.Range(1, 4);

        if (randomY == 1)
        {

            obsPos.y = 4;

        }

        if (randomY == 2)
        {

            obsPos.y = 2;

        }

        if (randomY == 3)
        {

            obsPos.y = 0.1f;

        }

        Instantiate(obstacle, obsPos, Quaternion.identity);



    }


    void CollectableSpawn()
    {

        Vector3 obsPos = new Vector3();
        obsPos.x = RepeatingBackground.ScrollWidth;
        randomY = Random.Range(1, 4);

        if (randomY == 1)
        {

            obsPos.y = 4;

        }

        if (randomY == 2)
        {

            obsPos.y = 2;

        }

        if (randomY == 3)
        {

            obsPos.y = 0.1f;

        }

        Instantiate(collectable, obsPos, Quaternion.identity); ;

    }

    public void GetHit()
    {
        if (SuperGameController.Lives >= 1)
        {

            SuperGameController.Lives = SuperGameController.Lives -= 1;
            TempTxt.text = SuperGameController.Lives.ToString(); //this will be indicated by animations rather than text once sprite work and animations begin
            if (SuperGameController.Lives <= 0)
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

        SuperGameController.Score = SuperGameController.Score += 10;
        ScoreText.text = SuperGameController.Score.ToString();

    }

    public void GameOver()
    {

        endScreen.SetActive(true);


    }

    public void IncreaseScore()
    {
        if (SuperGameController.Lives >= 1)
        {

            SuperGameController.Score += 5;
            ScoreText.text = SuperGameController.Score.ToString();

        }

    }

    public void AddToTimer()
    {

        timer = timer += 1;

        if (timer >= 20)
        {
            if (SuperGameController.Lives >= 1)
           {

                SceneManager.LoadScene(3);

            }

        }

    }

}

    

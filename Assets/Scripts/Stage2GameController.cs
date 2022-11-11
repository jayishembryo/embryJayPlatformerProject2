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
    public GameObject upgrade;
    public GameObject player;
    public GameObject gearText;
    public GameObject gasInstructions;
    public int randomY;
    public float currentTimer;
    public TMP_Text scoreText;
    public TMP_Text tempTxt;
    public float timer = 0.0f;
    public bool timerStart;
    public bool spawnTime;
    public int randomS;
    public SuperGameController instance;
    public SecondPlayerController secondPlayerControllerInstance;
    public bool wrenchOnscreen;
    public bool gasText = true;
    void Start()
    {
        scoreText.text = SuperGameController.score.ToString();
        tempTxt.text = SuperGameController.lives.ToString();
        spawnTime = true;
        InvokeRepeating("IncreaseScore", 2, 2);
        InvokeRepeating("AddToTimer", 1, 1);
        wrenchOnscreen = false;

    }

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

    }

    void RandomSpawn()
    {


        randomS = Random.Range(0, 10);

        if (randomS == 0 || randomS == 1 || randomS == 2 || randomS == 3 || randomS == 4 || randomS == 5 || randomS == 6 || randomS == 7)
        {

            ObstacleSpawn();

        }

        if (randomS == 8 || randomS == 9)
        {

            CollectableSpawn();

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

    public void GameOver()
    {

        endScreen.SetActive(true);

        if (gasText == true)
        {

            gasInstructions.SetActive(false);
            gasText = false;

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

    public void AddToTimer()
    {

        timer = timer += 1;

        if (timer >= 60)
        {

            if (gasText == true)
            {

                gasInstructions.SetActive(false);
                gasText = false;

            }

            if (SuperGameController.lives >= 1)
           {

                spawnTime = false;
                gearText.SetActive(true);
                Vector3 obsPos = new Vector3();

                if (wrenchOnscreen == false)
                {

                    obsPos.x = RepeatingBackground.scrollWidth;
                    obsPos.y = player.transform.position.y;
                    Instantiate(upgrade, obsPos, Quaternion.identity);
                    wrenchOnscreen = true;

                }

            }

        }

    }

    public void NextScene()
    {

        SceneManager.LoadScene(3);

    }   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject Instructions;
    public int Condition = 3;
    public GameObject endScreen;
    public GameObject obstacle;
    public GameObject collectable;
    public int randomY;
    public int i;
    public TMP_Text ScoreText;
    public TMP_Text TempTxt;
    public int Score = 0;
    public float timer = 0.0f;
    public bool timerStart;
    public bool spawnTime;
    public GameObject enemy;
    public int randomS;
    public PlayerBehavior PlayerBehaviorInstance;




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

                Instructions.SetActive(false);
                timerStart = true;
                spawnTime = true;
                InvokeRepeating("IncreaseScore", 2, 2);

            }

        }

        
        if (spawnTime)
        {

            if (Time.time > i)
            {

                i += 1;
                randomS = Random.Range(1, 4);

                if (randomS == 1)
                {

                    if (PlayerBehaviorInstance.RamRoutine == null)
                    {

                        ObstacleSpawn();

                    }

                }

                if (randomS == 2)
                {

                    CollectableSpawn();

                }

                if (randomS == 3)
                {

                    EnemySpawn();

                }

            }

        }


        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);

        }

    }

    void ObstacleSpawn()
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

    void EnemySpawn()
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

        Instantiate(enemy, obsPos, Quaternion.identity);
    }



    public void GetHit()
    {

        Condition = Condition -= 1;
        TempTxt.text = Condition.ToString(); //this will be indicated by animations rather than text once sprite work and animations begin
        if (Condition <= 0)
        {

            timerStart = false;
            spawnTime = false;
            GameOver();

        }

    }


    public void CollectableScore()
    {

        Score = Score += 10;
        ScoreText.text = Score.ToString();

    }

    public void EnemyScore()
    {
        
        Score = Score += 20;
        ScoreText.text = Score.ToString();

    }

    public void GameOver()
    {

        endScreen.SetActive(true);


    }

    public void IncreaseScore()
    {

        Score += 5;
        ScoreText.text = Score.ToString();

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    public float backgroundSpeed;


    public GameObject player;
    public GameObject background;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public Text timeText;
    public GameObject[] backgrounds;
    public GameObject jumpButton;
    public GameObject slideButton;
    public GameObject[] dialogue;
    public GameObject[] npc;


    public float clearTime;
    public float timePass;
    float ClearTime { get { return Mathf.Max(clearTime-timePass, 0f); } }
    bool isPaused = false;
    bool isMoving = false;
    bool isTalking = false;
    bool isClear = false;

	void Start ()
    {
        isPaused = false;
        Time.timeScale = 1f;
        foreach (GameObject bg in backgrounds)
        {
            bg.SetActive(false);
        }
        foreach (GameObject dl in dialogue)
        {
            dl.SetActive(false);
        }
        backgrounds[LevelData.MainStage - 1].SetActive(true);
    }

    void Update()
    {

        timePass += Time.deltaTime;
        if (!LevelData.isInfinite)
        {
            timeText.text = "" + (int)ClearTime;
        }
        else
        {
            clearTime = timePass + 10f;
            timeText.text = "" + (int)timePass;
        }
        if (timePass > clearTime)
        {
            GetComponent<ObsMaker>().isTimeRunning = false;
        }
        if(timePass > clearTime + 3f && !isClear)
        {
            StageClear();
            isClear = true;
        }

        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if(isMoving)
        {
           player.transform.Translate(2 * Time.deltaTime, 0, 0);
            Debug.Log("moving");
        }
	}

    public void GameOver()
    {
        if(LevelData.isInfinite)
        {
            if(!PlayerPrefs.HasKey("r1"))
            {
                for(int i = 1; i<=5; i++)
                {
                    PlayerPrefs.SetFloat("r" + i, 0f);
                }
            }
            float[] ranking = new float[5];

            for(int i = 0; i <5; i++)
            {
                ranking[i] = PlayerPrefs.GetFloat("r" + (i + 1));
            }

            for(int i = 0; i < 5; i++)
            {
                if (timePass > ranking[i])
                {
                    if(i == 4)
                    {
                        ranking[i] = timePass;
                        break;
                    }
                    else
                    {
                        for(int j = 3; j >= i;j--)
                        {
                            ranking[j + 1] = ranking[j];
                        }
                        ranking[i] = timePass;
                        break;
                    }
                }
            }

            for(int i =0;i<5;i++)
            {
                PlayerPrefs.SetFloat("r" + (i + 1), ranking[i]);
            }
        }
        gameOverPanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void StageClear()
    {
        if (LevelData.MainStage == 3 && LevelData.Stage == 5)
        {
            jumpButton.SetActive(false);
            slideButton.SetActive(false);
            timeText.enabled = false;
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play("Clear");
            StartCoroutine(AllClear());
        }
        else
        {
            StartCoroutine(Clear());
        }
    }

    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void MoveScene(int index)
    {
        if(LevelData.isInfinite && index == 2)
        {
            SceneManager.LoadScene(4);
            return;
        }
        SceneManager.LoadScene(index);
    }

    IEnumerator Clear()
    {
        jumpButton.SetActive(false);
        slideButton.SetActive(false);
        timeText.enabled = false;
        npc[LevelData.MainStage - 1].SetActive(true);
        isMoving = true;
        yield return new WaitForSeconds(4);
        dialogue[(LevelData.MainStage - 1) * 5 + LevelData.Stage - 1].SetActive(true);
        isTalking = true;
        isMoving = false;
        yield return new WaitForSeconds(3);
        if(LevelData.Stage == 5)
        {
            LevelData.LevelUp();
            SceneManager.LoadScene(1);
        }
        else
        {
            LevelData.LevelUp();
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator AllClear()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(0);
    }
}

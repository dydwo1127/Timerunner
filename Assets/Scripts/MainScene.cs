using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    public GameObject settingPanel;
    public GameObject credit;

    public GameObject musicOn;
    public GameObject musicOff;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(settingPanel.activeInHierarchy || credit.activeInHierarchy)
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    settingPanel.SetActive(false);
                    credit.SetActive(false);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void ToStageSelect()
    {
        LevelData.isInfinite = false;
        SceneManager.LoadScene(1);
    }

    public void ToInfinite()
    {
        LevelData.isInfinite = true;
        SceneManager.LoadScene(4);
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void Credit()
    {
        credit.SetActive(true);
    }

    public void Volume(float value)
    {
        LevelData.volume = value;
        if(value == 0)
        {
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
        else
        {
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteMenu : MonoBehaviour {

    public Text[] rankingText;

    public GameObject rankingPanel;

	void Start ()
    {
		for(int i =0; i<5;i++)
        {
            rankingText[i].text = (i + 1) + ". " + (int)(PlayerPrefs.GetFloat("r" + (i + 1)) / 60) + "M " + Mathf.Floor((PlayerPrefs.GetFloat("r" + (i + 1)) % 60)*100f)/100f + "S";
        }
	}
	
	void Update ()
    {
		if(rankingPanel.activeInHierarchy)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                rankingPanel.SetActive(false);
            }
        }
	}

    public void StartButton()
    {
        SceneManager.LoadScene(3);
    }

    public void RankingButton()
    {
        rankingPanel.SetActive(true);
    }

    public void MoveScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}

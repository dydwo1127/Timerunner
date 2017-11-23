using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStage : MonoBehaviour {

    public GameObject s1;
    public GameObject s2;
    public GameObject s2Block;
    public GameObject s3;
    public GameObject s3Block;

	void Start () {
		if(LevelData.MainStage == 1)
        {
            s2.SetActive(false);
            s2Block.SetActive(true);
            s3.SetActive(false);
            s3Block.SetActive(true);
        }
        else if(LevelData.MainStage == 2)
        {
            s2.SetActive(true);
            s2Block.SetActive(false);
            s3.SetActive(false);
            s3Block.SetActive(true);
        }
        else if(LevelData.MainStage ==3)
        {
            s2.SetActive(true);
            s2Block.SetActive(false);
            s3.SetActive(true);
            s3Block.SetActive(false);
        }
	}
    public void CurrentStage(int index)
    {
        LevelData.currentStage = index;
    }
	
    public void MoveScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}

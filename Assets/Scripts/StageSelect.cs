using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    public GameObject[] blocks;
    public GameObject[] backgrounds;

	void Start () {
        foreach(GameObject block in blocks)
        {
            block.SetActive(true);
        }
        foreach(GameObject bg in backgrounds)
        {
            bg.SetActive(false);
        }

        backgrounds[LevelData.MainStage - 1].SetActive(true);

        if(LevelData.currentStage < LevelData.MainStage)
        {
            foreach (GameObject block in blocks)
            {
                block.SetActive(false);
            }
        }

        else if(LevelData.currentStage == LevelData.MainStage)
        {
            for(int i = 0; i < LevelData.Stage; i++)
            {
                blocks[i].SetActive(false);
            }
        }

        else if(LevelData.currentStage > LevelData.MainStage)
        {
            foreach (GameObject block in blocks)
            {
                block.SetActive(true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}

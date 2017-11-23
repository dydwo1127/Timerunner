using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData
{
    public static void LevelUp()
    {
        if(Stage < 5)
        {
            Stage++;
        }
        else if(Stage == 5 && MainStage<3)
        {
            Stage = 1;
            MainStage++;
        }
        else if(Stage == 5 && MainStage == 3)
        {
            return;
        }
    }
    public static int MainStage
    {
        get
        {
            return PlayerPrefs.GetInt("MainStage", 1);
        }

        set
        {
            PlayerPrefs.SetInt("MainStage", value);
        }
    }
    public static int Stage
    {
        get
        {
            return PlayerPrefs.GetInt("Stage", 1);
        }
        
        set
        {
            PlayerPrefs.SetInt("Stage", value);
        }
    }
    public static float volume;
    public static int currentStage;
}

public class GameData : MonoBehaviour {

    public static GameData instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            LevelData.LevelUp();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    
}

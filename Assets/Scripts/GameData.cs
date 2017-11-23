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
    public static float volume = 0.5f;
    public static int currentStage;

    public static bool isInfinite = false;
}

public class GameData : MonoBehaviour {

    public static GameData instance;

    public AudioSource mainBgm;

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

    void Start()
    {
        mainBgm.volume = LevelData.volume;
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
        if(Input.GetKeyDown(KeyCode.K))
        {
            for(int i = 1; i<=5;i++)
            {
                Debug.Log(PlayerPrefs.GetFloat("r" + i));
            }
        }

        mainBgm.volume = LevelData.volume;
    }

    
}

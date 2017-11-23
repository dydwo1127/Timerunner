using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour {

    public List<GameObject> Obstacles;
    float obsInstanceRate;
    int obsRange;

    public bool isTimeRunning = true;

    float obsInstanceTime = 0;

	void Start ()
    {
		switch(LevelData.MainStage)
        {
            case 1:
                obsInstanceRate = 2f;
                obsRange = 4;
                return;
            case 2:
                obsInstanceRate = 1f;
                obsRange = 7;
                return;
            case 3:
                obsInstanceRate = 0.7f;
                obsRange = 7;
                return;
        }

        if(LevelData.isInfinite)
        {
            obsInstanceRate = 2f;
            obsRange = 4;
        }
	}
	
	void Update ()
    {
        obsInstanceTime += Time.deltaTime;

        if(obsInstanceTime > obsInstanceRate && isTimeRunning)
        {
            Instantiate(Obstacles[Random.Range(0, obsRange)]);
            obsInstanceTime = 0;
        }

        float time = GetComponent<GameController>().timePass;

        if(LevelData.isInfinite)
        {
            if (time > 180)
            {
                obsInstanceRate = 0.5f;
                return;
            }
            else if (time > 120)
            {
                obsInstanceRate = 0.7f;
                return;
            }
            else if (time > 60)
            {
                obsInstanceRate = 1f;
                obsRange = 7;
            }
        }
	}
}

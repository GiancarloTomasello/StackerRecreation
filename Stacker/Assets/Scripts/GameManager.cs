using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //CubeSpawner cubeSpawner;

    public GameObject cubeSpawner;
    private CubeSpawner spawnerScript;

    public int sPrizeHeight;
    public int lPrizeHeight;

    private float waitTime;

    private bool controlsEnabled;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        sPrizeHeight = 6;
        lPrizeHeight = 12;
        waitTime = 0.5f;
        score = 0;

        controlsEnabled = true;


        spawnerScript = cubeSpawner.GetComponent<CubeSpawner>();
        //Start game loop coroutine
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameStarting()
    {
        // Spawn Cube and disable controls
        spawnerScript.SpawnCube(score);
        Debug.Log("Game Start done");
        yield return waitTime;
        
    }

    private IEnumerator GamePlaying()
    {
        //Handle spawning
        while (score < sPrizeHeight)
        {
            
        }
        Debug.Log("Game playing done");
        yield return waitTime;
    }

    private IEnumerator GameEnding()
    {
        //Bring up end screen
        Debug.Log("Game End done");
        yield return null;
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());

        Debug.Log("Game Loop done");

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnerScript.SpawnCube(score);
            score++;
        }
            
    }
}

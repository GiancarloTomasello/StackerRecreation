using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //CubeSpawner cubeSpawner;

    public GameObject cubeSpawner;
    private CubeSpawner spawnerScript;

    public GameObject gameMenuUI;
    public GameObject gameMenuLargeUI;

    public int sPrizeHeight;
    public int lPrizeHeight;
    public int winHeight;

    private float waitTime;

    private bool controlsEnabled;

    public int score;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        sPrizeHeight = 8;
        lPrizeHeight = 12;
        winHeight = sPrizeHeight;
        waitTime = 0.5f;
        score = 0;
        size = 3;

        controlsEnabled = true;

        spawnerScript = cubeSpawner.GetComponent<CubeSpawner>();
        //Start game loop coroutine
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameStarting()
    {
        // Spawn Cube and disable controls
        if(score < 1)
        {
            spawnerScript.SpawnCube(size);
        }
        Debug.Log("Game Start done");
        yield return waitTime;
        
    }

    private IEnumerator GamePlaying()
    {
        //Handle spawning
       
        while (score < winHeight && size > 0)
        {
            Debug.Log("Score: " + score + " winHeight: " + winHeight);
            yield return null;
        }

        controlsEnabled = false;

        Debug.Log("Game playing done");
        yield return waitTime;
    }


    private IEnumerator GameEnding()
    {
        //Bring up end screen
        if (score == sPrizeHeight)
        {
            Debug.Log("Game Won Small Prize");
            gameMenuUI.SetActive(true);
        } else if (score == lPrizeHeight) 
        {
            Debug.Log("Game Won Large Prize");
            gameMenuLargeUI.SetActive(true);
        } else
        {
            Debug.Log("Game Lost");
        }
        Debug.Log("Game End done");
        yield return null;
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());


        gameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        // Debug.Log("Game Loop done");

    }

    public void ContinueGame()
    {
        winHeight = lPrizeHeight;
        controlsEnabled = true;
        gameMenuUI.SetActive(false); 
        Time.timeScale = 1f;

       StartCoroutine(GameLoop());


    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controlsEnabled)
        {

            //Remove any cubed if needed
            size -= spawnerScript.RemoveCubes();
            score++;

            if (size > 0)
            {
                spawnerScript.SpawnCube(size);
            }


        }
        Debug.Log(size);
    }
}

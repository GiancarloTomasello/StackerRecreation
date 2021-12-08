using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public int cubeSize;
    public float spawnOffset;

    [SerializeField]
    private int score;
    private int cubesize;

    [SerializeField]
    private bool firstCheck;

    public GameObject cube_3L;
    public GameObject cube_2L;
    public GameObject cube_1L;

    public GameObject blockChecker;

    private GameObject spawnedObj;
    private GameObject[] blockCheckers;

    [SerializeField]
    public BlockTrigger blockTriggerRef;

    //[SerializeField]
    //private GameObject spawnedObj;

    // Start is called before the first frame update
    void Start()
    {
        blockTriggerRef = gameObject.GetComponent<BlockTrigger>();
        firstCheck = true;
        score = 1;
        cubesize = 3;

    }

    void Awake()
    {
        blockTriggerRef = gameObject.GetComponent<BlockTrigger>();
        firstCheck = true;
        score = 1;
        cubesize = 3;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetSize()
    {
        return cubesize;
    }

    public void SpawnCube(int size)
    {
        GameObject objectToSpawn = cube_3L;
        score++;
        //Don't check for bottom cubes
        if(size == 3)
        {
            objectToSpawn = cube_3L;
        } else if(size == 2)
        {
            objectToSpawn = cube_2L;
            cubesize = 2;
        }
        else if(size == 1)
        {
            objectToSpawn = cube_1L;
            cubesize = 1;
        }

        Vector3 spawnLocation = new Vector3(0, gameObject.transform.position.y, 0);

        spawnedObj = (GameObject) Instantiate(objectToSpawn, spawnLocation, Quaternion.identity) as GameObject;
        blockTriggerRef = spawnedObj.GetComponentInChildren(typeof(BlockTrigger)) as BlockTrigger;

        gameObject.transform.position = new Vector3(0, gameObject.transform.position.y + spawnOffset, 0);

        blockCheckers = new GameObject[size];
        SpawnTriggers(blockCheckers);
        
        return;
    }

    public int CheckCubes()
    {
        return blockTriggerRef.CubesCheck();
    }

    public int RemoveCubes()
    {
        int cubesRemoved = 0;

       // spawnedObj.GetComponent<CubeGridMovement>(). 


        for (int i = 0; i < blockCheckers.Length; i++)
        {

            //Debug.Log("Block Below Check at" + i + " = " + blockCheckers[i].GetComponent<BlockBelowCheck>().getIsBlockBelow());
            Debug.Log("FirstCheck ==" + firstCheck);

            if (firstCheck == false && blockCheckers[i].GetComponent<BlockBelowCheck>().getIsBlockBelow() == false)
            {
                Debug.Log("Remove block at position: " + i);
                Destroy(spawnedObj.transform.GetChild(i).gameObject);
                cubesRemoved++;
            }

            //Destroy(blockCheckers[i]);
        }

        firstCheck = false;
        Debug.Log(cubesRemoved);

        return cubesRemoved;
    }

    private void SpawnTriggers(GameObject[] arr)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            var spawnLocation = new Vector3((spawnedObj.transform.position.x + (i*1.15f)), spawnedObj.transform.position.y - 1, 0);
            //Debug.Log("Spawn location: " + spawnLocation);

            var tempTrigger = (GameObject)Instantiate(blockChecker, spawnLocation, Quaternion.identity) as GameObject;
            tempTrigger.transform.parent = spawnedObj.transform;
            arr[i] = tempTrigger;
            arr[i].GetComponent<BlockBelowCheck>().setBlockNumber(i);
        }

        return;
    }

}

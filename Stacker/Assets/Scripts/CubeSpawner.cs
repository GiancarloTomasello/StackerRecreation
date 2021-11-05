using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public int cubeSize;
    public float spawnOffset;

    [SerializeField]
    private int score;

    public GameObject cube_3L;
    public GameObject cube_2L;
    public GameObject cube_1L;

    public GameObject blockChecker;

    private GameObject spawnedObj;

    public BlockTrigger blockTriggerRef;

    //[SerializeField]
    //private GameObject spawnedObj;

    // Start is called before the first frame update
    void Start()
    {
        blockTriggerRef = gameObject.GetComponent<BlockTrigger>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int SpawnCube(int score)
    {
        if(score >= 0)
        {
            //Don't check for bottom cubes

            Vector3 spawnLocation = new Vector3(0, gameObject.transform.position.y, 0);

            spawnedObj = (GameObject) Instantiate(cube_3L, spawnLocation, Quaternion.identity) as GameObject;
            blockTriggerRef = spawnedObj.GetComponentInChildren(typeof(BlockTrigger)) as BlockTrigger;

           // Debug.Log("Test: " + blockTriggerRef.test);


            //Need to get the component for CHECKCUBES from the children
            //Try this https://docs.unity3d.com/ScriptReference/Component.GetComponentsInChildren.html



            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y + spawnOffset, 0);
        } else
        {
            //Check if any cubes fell
        }

        return score;
    }

    public int CheckCubes()
    {
        return blockTriggerRef.CubesCheck();
    }

    public void RemoveCubes(int size)
    {
        GameObject[] blockCheckers = new GameObject[size];
        Debug.Log("Remove Cubes array size: " + blockCheckers.Length);

        if(blockCheckers.Length == 3)
        {
            for(int i = -1; i < 2; i++)
            {
                var spawnLocation = new Vector3((spawnedObj.transform.position.x + i), spawnedObj.transform.position.y-1, 0);
                Debug.Log("Spawn location: " + spawnLocation);
                blockCheckers[i+1] = (GameObject)Instantiate(blockChecker, spawnLocation, Quaternion.identity) as GameObject;
            }

        Debug.Log("Array Test: " + blockCheckers[1]);
        } else if (blockCheckers.Length == 2)
        {

        } else if (blockCheckers.Length == 1)
        {

        }

        foreach(GameObject objTest in blockCheckers)
        {
            Destroy(objTest);
        }
    }
}

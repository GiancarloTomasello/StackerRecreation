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

            var spawnedObj = (GameObject) Instantiate(cube_3L, spawnLocation, Quaternion.identity) as GameObject;

            //Need to get the component for CHECKCUBES from the children
            //Try this https://docs.unity3d.com/ScriptReference/Component.GetComponentsInChildren.html



            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y + spawnOffset, 0);
        } else
        {
            //Check if any cubes fell
        }

        return score;
    }

    public void CheckCubes()
    {
        Debug.Log("Checking the cubes...");

//        Debug.Log(spawnedObj);



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{

    public CubeSpawner cubeSpawner;

    private int missingCubes;

    public int test;

    // Start is called before the first frame update


    void Awake()
    {
        missingCubes = 3;
        test = 10;
    }


    public int CubesCheck()
    {
        Debug.Log("numOfCubes: " + missingCubes);
        return missingCubes;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Block Trigger Entered!");
        --missingCubes;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Block Collider Exit!");
        ++missingCubes;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{

    public CubeSpawner cubeSpawner;

    private int numOfCubesBelow;

    public int test;

    // Start is called before the first frame update


    void Awake()
    {
        numOfCubesBelow = 0;
        test = 10;
    }


    public int CubesCheck()
    {
        Debug.Log("numOfCubes: " + numOfCubesBelow);
        return numOfCubesBelow;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Block Trigger Entered!");
        ++numOfCubesBelow;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Block Collider Exit!");
        --numOfCubesBelow;
    }


}

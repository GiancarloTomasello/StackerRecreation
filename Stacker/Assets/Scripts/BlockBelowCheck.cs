using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBelowCheck : MonoBehaviour
{

    [SerializeField]
    private bool isBlockBelow;

    [SerializeField]
    private int blockNumber;

    void Awake()
    {
        isBlockBelow = false;
    }

    public void setBlockNumber(int num)
    {
        blockNumber = num;
    }

    public bool getIsBlockBelow()
    {
        return isBlockBelow;
    }

    public int getBlockNumber()
    {
        return blockNumber;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Below Check Entered!");
        isBlockBelow = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Block Check Exit!");
        isBlockBelow = false;
    }

}
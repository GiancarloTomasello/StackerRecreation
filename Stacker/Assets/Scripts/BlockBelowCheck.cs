using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBelowCheck : MonoBehaviour
{

    [SerializeField]
    private bool isBlockBelow;

    void Awake()
    {
        isBlockBelow = false;
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
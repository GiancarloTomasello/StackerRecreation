using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test Collider Entered!");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Test Collider Exit!");
    }
}

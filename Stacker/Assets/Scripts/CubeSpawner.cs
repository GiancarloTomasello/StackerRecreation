using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public int cubeSize;
    public float spawnOffset;

    [SerializeField]
    private int score;

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {

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
            Debug.Log(gameObject.transform.position);

            Vector3 spawnLocation = new Vector3(0, gameObject.transform.position.y, 0);
            GameObject spanwedObj = Instantiate(cube, spawnLocation, Quaternion.identity);
            //Debug.Log("Cube location" + spanwedObj.transform.position);
            //spanwedObj.transform.position = new Vector3(0, gameObject.transform.position.y , 0);

            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y + spawnOffset, 0);
        } else
        {
            //Check if any cubes fell
        }

        return score;
    }
}

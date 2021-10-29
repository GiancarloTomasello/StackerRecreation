using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Transform blocks;

    public float speed;
    private int direction;
    private bool isMoving;

    void onAwake()
    {

    }

    void onEnable()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        direction = 1;
        isMoving = true;

        blocks = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar was placed");
            isMoving = false;
        }

        if (isMoving)
        {
            if (blocks.position.x >= 10f)
            {
                direction = -1;
            }
            else if (
              blocks.position.x <= -10f)
            {
                direction = 1;
            }

            blocks.transform.position = new Vector3(blocks.position.x + (direction * speed * Time.deltaTime), 0, 0);
        } 
        else
        {
            //Turn on gravity.
        }
        
    }
}

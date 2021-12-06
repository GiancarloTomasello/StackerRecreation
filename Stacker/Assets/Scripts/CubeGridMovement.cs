using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGridMovement : MonoBehaviour
{

    public float speed;
    public int size;

    [SerializeField]
    private int direction;
    [SerializeField]
    private bool canMove;
    [SerializeField]
    private float moveOffset;

    public GameObject Spawner;
    public CubeSpawner cubeSpawner;
    // Start is called before the first frame update
    void Start()
    {

        direction = 1;
        canMove = true;
        moveOffset = 1.15f;

        Spawner = GameObject.FindWithTag("Spawner");
        cubeSpawner = Spawner.GetComponent<CubeSpawner>();

        float speedFactor = cubeSpawner.GetScore() * 3;
        float fraction = 1f / 20f;
        speedFactor *= fraction;
       // Debug.Log("SpeedFactor: " + speedFactor);
        speed = (1 - speedFactor);
        if(speed < fraction)
        {
            speed = fraction;
        }
       // Debug.Log("Speed: " + speed);

        size = cubeSpawner.GetSize();




       
        StartCoroutine(MovementCoroutine());
    }


    //The main movement logic will be covered in this functions
    IEnumerator MovementCoroutine()
    {
        Debug.Log("Cube Move");
        if (size == 3 && gameObject.transform.position.x >= 3.6f || size == 2 && gameObject.transform.position.x >= 4.75f || size == 1 && gameObject.transform.position.x >= 5.9f)
        {
            direction = -1;
        }
        else if (
          gameObject.transform.position.x <= -3.6f)
        {
            direction = 1;
        }

        gameObject.transform.Translate(new Vector3(direction * moveOffset, 0, 0), Space.World);

        yield return new WaitForSeconds(speed);
        movement();
    }

    //Wether or not the player can move again will be determined in this function.
    public void movement()
    {
        if (canMove == true)
        {
            StartCoroutine(MovementCoroutine());
        } else
        {
            StopCoroutine(MovementCoroutine());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;
            //cubeSpawner.CheckCubes();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGridMovement : MonoBehaviour
{

    public float speed;

    [SerializeField]
    private int direction;
    [SerializeField]
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        direction = 1;
        canMove = true;

        StartCoroutine(MovementCoroutine());
    }

    //The main movement logic will be covered in this function
    IEnumerator MovementCoroutine()
    {
        Debug.Log("RunCorutine");

        if (gameObject.transform.position.x >= 3f)
        {
            direction = -1;
        }
        else if (
          gameObject.transform.position.x <= -3f)
        {
            direction = 1;
        }

        gameObject.transform.Translate(new Vector3(direction * 1f, 0, 0), Space.World);

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
            Debug.Log("Stop Movement");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;
        }
    }

}

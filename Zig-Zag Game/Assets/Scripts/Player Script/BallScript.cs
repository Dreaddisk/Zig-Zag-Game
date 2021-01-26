using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    #region Variable
    private Rigidbody myBody;

    private bool rollLeft;

    public float speed = 4f;

    #endregion Variable

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        rollLeft = true;
    }

    private void Update()
    {
        CheckInput();
        CheckBallOutOfBounds();
    }

    private void FixedUpdate()
    {
        if(GameplayController.instance.gamePlaying)
        {
            if(rollLeft)
            {
                myBody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(0f, Physics.gravity.y, speed);
            }
        }
    }

    void CheckBallOutOfBounds()
    {
        if (GameplayController.instance.gamePlaying)
        {
            if (transform.position.y < -4)
            {
                GameplayController.instance.gamePlaying = false;
                Destroy(gameObject);
            }
        }
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameplayController.instance.gamePlaying)
            {
                GameplayController.instance.gamePlaying = true;
                GameplayController.instance.ActiveTileSpawner();
            }
        }

        if (GameplayController.instance.gamePlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rollLeft = !rollLeft;
            }
        }

    }


} // Ball Script class
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //rigidbody
    private Rigidbody rigidbody;
    //move?
    private bool isMovingRight = false;
    //bounce
    private bool bounce = true;

    [SerializeField] float speed = 5f;


    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

    }

    void Update()
    {
        //mouse click for movement
        if(Input.GetMouseButton(0) && bounce)
        {
            ChangeBool();
            ChangeDirection();
        }

        //check for collision
        if (Physics.Raycast(this.transform.position, Vector3.down * 2) == false)
        {
            Bounce();
        }
    }

    //to make the ball bounce
    private void Bounce()
    {
        bounce = false;
        //Downward Velocity on Y
        rigidbody.velocity = new Vector3(0f, -4f, 0f);
    }


    private void ChangeBool()
    {
        //change directions
        isMovingRight = !isMovingRight;
    }
    private void ChangeDirection()
    {
      if(isMovingRight)
        {
            //Forward Velocity on X
            rigidbody.velocity = new Vector3(speed, 0f, 0f);

        }
        else
        {
            //Forward Velocity on Z
            rigidbody.velocity = new Vector3(0f, 0f, speed);
        }
    }




}

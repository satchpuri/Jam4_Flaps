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
    public bool bounce = true;

    //[SerializeField] GameObject hud;
    public HUD hud;
    [SerializeField] float speed = 4f;
    [SerializeField] GameObject particle;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        hud = FindObjectOfType(typeof(HUD)) as HUD;

    }

    void Update()
    {
        //mouse click for movement
        if (PauseMenu.isPaused == false)
        {
            if (Input.GetMouseButtonDown(0) && bounce)
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameObject _particle = Instantiate(particle) as GameObject;
            _particle.transform.position = this.transform.position;
            hud.SetCountText();
            Destroy(_particle, 1f);
        }
    }


}

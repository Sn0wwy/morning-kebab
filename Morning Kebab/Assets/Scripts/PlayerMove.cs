using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float runSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rd2D;

    void Start()
    {
        rd2D=GetComponent<Rigidbody2D>();
        // tr2D = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rd2D.velocity = new Vector2(runSpeed, rd2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rd2D.velocity = new Vector2(-runSpeed, rd2D.velocity.y);

        }
        else 
        {
            rd2D.velocity = new Vector2(0, rd2D.velocity.y);
        }

        if (Input.GetKey("space") &&  CheckGround.isGrounded)
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, jumpSpeed);
        }
    }
}

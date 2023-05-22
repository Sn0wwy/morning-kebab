using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakoMove : MonoBehaviour
{



    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public bool betterJump = true;

    Rigidbody2D rd2D;
    SpriteRenderer tr2D;


    public float fallMultipiler = 0.5f;
    public float lowJumpMultipiler = 1f;

    void Start()
    {

        rd2D = GetComponent<Rigidbody2D>();
        tr2D = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            tr2D.flipX = false;
            rd2D.velocity = new Vector2(runSpeed, rd2D.velocity.y);
            GetComponent<WeaponManager>().currentWeapon.GetComponent<SpriteRenderer>().flipX = false;
            if (GetComponent<WeaponManager>().currentWeapon is ShotGun)
            {
                GetComponent<WeaponManager>().currentWeapon.GetComponent<ShotGun>().projectile.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {

            tr2D.flipX = true;
            rd2D.velocity = new Vector2(-runSpeed, rd2D.velocity.y);
            GetComponent<WeaponManager>().currentWeapon.GetComponent<SpriteRenderer>().flipX = true;
            if (GetComponent<WeaponManager>().currentWeapon is ShotGun)
            {
                GetComponent<WeaponManager>().currentWeapon.GetComponent<ShotGun>().projectile.GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        else
        {
            rd2D.velocity = new Vector2(0, rd2D.velocity.y);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, jumpSpeed);
        }


        if (betterJump)
        {
            if (rd2D.velocity.y < 0)
            {
                rd2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipiler) * Time.deltaTime;

            }
            else if (rd2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rd2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipiler) * Time.deltaTime;
            }
        }




    }
}
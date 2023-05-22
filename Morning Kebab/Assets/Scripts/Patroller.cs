using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public float patrolSpeed = 0.8f;
    public float range = 3;
    public bool vertical = true;

    private GameObject player;

    float startingY;
    float startingX;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
        startingX = transform.position.x;
        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if(vertical) {
            transform.Translate(Vector2.up * patrolSpeed * Time.deltaTime * dir);

            if(transform.position.y < startingY || transform.position.y > startingY + range)
                dir *= -1;

        } else {
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime * dir);
            if(transform.position.x < startingX || transform.position.x > startingX + range){
                dir *= -1;
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
            }
        }
    }
 }
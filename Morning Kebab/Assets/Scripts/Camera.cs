using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.position.x;
            position.y = Player.position.y+0.3f;
            transform.position = position;
        }
    }
}

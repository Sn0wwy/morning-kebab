using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaX : MonoBehaviour
{
    [SerializeField] private float parallaxMultipiler;
    private Transform camaraTransform;
    public Transform Player;
    private Vector3 previosCameraPos;
    private float spriteWidth, startPos;

    void Start()
    {
        camaraTransform = Camera.main.transform;
        previosCameraPos = camaraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (camaraTransform.position.x - previosCameraPos.x) * parallaxMultipiler;
        float deltaY = (camaraTransform.position.y - previosCameraPos.y) * parallaxMultipiler;
        float moveAmount = camaraTransform.position.x * (1 - parallaxMultipiler);
        transform.Translate(new Vector3(deltaX, deltaY, 0));
        previosCameraPos = camaraTransform.position;

        if (moveAmount > startPos + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPos += spriteWidth;
        }
        else if (moveAmount < startPos - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPos -= spriteWidth;
        }
    }
}

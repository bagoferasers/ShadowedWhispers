using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScroll : MonoBehaviour
{
    public float scrollSpeed;
    private float canvasHeight;
    private Vector3 startPosition;

    void Start( )
    {
        RectTransform rectTransform = GetComponent< RectTransform >( );
        canvasHeight = rectTransform.rect.height;
        startPosition = rectTransform.position;
    }

    void Update( )
    {
        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        if ( transform.position.y >= startPosition.y + canvasHeight )
        {
            transform.position = startPosition;
        }
    }
}
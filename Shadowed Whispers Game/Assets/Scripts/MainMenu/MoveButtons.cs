using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButtons : MonoBehaviour, IScroll
{
    private Vector3 currentPosition;
    
    [ Header( "Speed of scroll:" ) ]
    public float speed = 1.0f;

    public Vector3 startPosition
    {
        get 
        {
            return this.transform.position;
        }
    }

    void Start( )
    {
        currentPosition = startPosition;
    }

    public void startScrollingButtons( )
    {
        StartCoroutine( buttonScroll( ) );
    }

    public void Scroll( Vector3 currentPosition )
    {
        Vector3 targetPosition = startPosition + speed * Vector3.left;
        currentPosition = Vector3.Lerp( currentPosition, targetPosition, Time.fixedDeltaTime );
        this.transform.position = currentPosition;
    }

    IEnumerator buttonScroll( )
    {
        while( currentPosition.x != 0 )
        {
            Scroll( currentPosition );
            yield return null;
        }
        yield return null;
    }
}
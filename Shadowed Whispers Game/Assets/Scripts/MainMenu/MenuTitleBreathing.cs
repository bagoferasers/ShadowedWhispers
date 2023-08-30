using System.Collections;
using UnityEngine;

public class MenuTitleBreathing : MonoBehaviour
{
    public float speed;
    public float max;
    public float min;
    private Vector3 originalPosition;

    void Start( )
    {
        originalPosition = transform.position;
        breathe( );
    }

    private void breathe( )
    {
        StartCoroutine( breathingNumerator( ) );
    }

    IEnumerator breathingNumerator( )
    {
        while ( true )
        {
            float factor = Mathf.Lerp( min, max, Mathf.PingPong( Time.time * speed, 1.0f ) );
            Vector3 newPosition = new Vector3( originalPosition.x, originalPosition.y + factor, originalPosition.z );
            transform.position = newPosition;
            yield return null;
        }
    }
}
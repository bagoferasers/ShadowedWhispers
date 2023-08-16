using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTitleBreathing : MonoBehaviour
{
    public float size = 2.0f;
    void Start( )
    {
        breathe( );
    }

    private void breathe( )
    {
        StartCoroutine( breathingNumerator( ) );
    }

    IEnumerator breathingNumerator( )
    {
        while (true)
        {
            //this.scale = Mathf.PingPong( 1.0f, size );
        }
    }
}

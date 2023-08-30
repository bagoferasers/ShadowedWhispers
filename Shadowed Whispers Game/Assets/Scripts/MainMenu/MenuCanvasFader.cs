using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasFader : MonoBehaviour, IFadeCanvasGroup
{
    public CanvasGroup Canvas
    {
        get 
        {
            return this.GetComponent< CanvasGroup >( );
        }
    }

    [ Header( "Insert fade time:" ) ]
    public float time = 2.0f;

    void Start()
    {
        showCanvas( time );
    }

    public void showCanvas( float fadeTime )
    {
        StartCoroutine( fadeIn( fadeTime ) );
    }

    public void hideCanvas( float fadeTime )
    {
        StartCoroutine( fadeOut( fadeTime ) );
    }

    IEnumerator fadeIn( float fadeTime )
    {
        while( Canvas.alpha > 0 )
        {
            Canvas.alpha -= fadeTime * ( Time.deltaTime / 2 );
            yield return null;
        }
        Canvas.interactable = false;
        yield return null;
    } 

    IEnumerator fadeOut( float fadeTime )
    {
        while( Canvas.alpha < 1 )
        {
            Canvas.alpha += fadeTime * ( Time.deltaTime / 2 );
            yield return null;
        }
        Canvas.interactable = false;
        yield return null;
    }
}

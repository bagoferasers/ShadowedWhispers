using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour, IFadeCanvasGroup, IScroll
{
    [ Header( "Name of Scene to change to:" ) ]
    public string nameOfScene = "MainMenu";

    [ Header( "Speed of scroll:" ) ]
    public float speed = 1.0f;

    [ Header( "Insert fade time:" ) ]
    public float time = 2.0f;

    private Vector3 currentPosition;

    public CanvasGroup Canvas
    {
        get 
        {
            return GameObject.Find( "CreditsCanvas" ).GetComponent< CanvasGroup >( );
        }
    }

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
        showCanvas( time );
    }

    void Update( )
    {
        if( Canvas.alpha == 0 )
            changeScene( );
        Scroll( currentPosition );
    }

    public void changeScene( )
    {
        SceneManager.LoadScene( nameOfScene );
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.CompareTag( "End" ) )
            hideCanvas( time );
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

    public void Scroll( Vector3 startPosition )
    {
        Vector3 targetPosition = startPosition + speed * Vector3.up;
        currentPosition = Vector3.Lerp( currentPosition, targetPosition, Time.fixedDeltaTime );
        this.transform.position = currentPosition;
    }
}
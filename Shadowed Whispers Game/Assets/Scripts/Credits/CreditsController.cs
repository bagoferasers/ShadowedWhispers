using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour, IFadeCanvasGroup, ISceneChange, IScroll
{
    [ Header( "Name of Scene to change to:" ) ]
    public string nameOfScene = "MainMenu";

    [ Header( "Speed of scroll:" ) ]
    public float speed = 1.0f;

    private Vector3 currentPosition;

    public CanvasGroup canvasGroup
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
        showCanvas( );
    }

    void Update( )
    {
        if( canvasGroup.alpha == 0 )
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
            hideCanvas( );
    }

    public void showCanvas( )
    {
        StartCoroutine( fadeIn( ) );
    }

    public void hideCanvas( )
    {
        StartCoroutine( fadeOut( ) );
    }

    IEnumerator fadeOut( )
    {
        while( canvasGroup.alpha > 0 )
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    } 

    IEnumerator fadeIn( )
    {
        while( canvasGroup.alpha < 1 )
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

    public void Scroll( Vector3 startPosition )
    {
        Vector3 targetPosition = startPosition + speed * Vector3.up;
        currentPosition = Vector3.Lerp( currentPosition, targetPosition, Time.fixedDeltaTime );
        this.transform.position = currentPosition;
    }
}
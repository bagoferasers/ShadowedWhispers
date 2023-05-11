using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GameObject.Find( "darkyboi" ).GetComponent< CanvasGroup >( );
        fadeMeIn( );
    }

    public void fadeMeOut( )
    {
        StartCoroutine( FadeOut( ) );
    }

    public void fadeMeIn( )
    {
        StartCoroutine( FadeIn( ) );
    }

    public void changeSceneToMainMenu( )
    {
        fadeMeOut( );
        StartCoroutine( ChangeScene( ) );
    }

    public IEnumerator ChangeScene( )
    {
        yield return new WaitForSeconds( .1f );
        SceneManager.LoadScene( "MainMenu" );
    }

    IEnumerator FadeOut( )
    {
        while( canvasGroup.alpha < 1 )
        {
            canvasGroup.alpha += Time.deltaTime * 10;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

    IEnumerator FadeIn( )
    {
        while( canvasGroup.alpha > 0 )
        {
            canvasGroup.alpha -= Time.deltaTime * 10;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.gameObject.CompareTag( "EndCredits" ) )
        {
            changeSceneToMainMenu( );
        }
    }
}

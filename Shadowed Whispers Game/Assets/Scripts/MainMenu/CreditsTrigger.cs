using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTrigger : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start( )
    {
        canvasGroup = GameObject.Find( "darkyboi" ).GetComponent< CanvasGroup >( );
    }

    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.CompareTag( "EndCredits" ) )
        {
            StartCoroutine( FadeOut( ) );
        }
    }

    void Update( ) 
    {
        if( canvasGroup.alpha == 1 )
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
}
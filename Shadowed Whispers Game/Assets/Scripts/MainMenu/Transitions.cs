using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public string sceneToChangeTo;
    public float fadeMultiplier;

    void Start( )
    {
        canvasGroup = GameObject.Find( "darkyboi" ).GetComponent< CanvasGroup >( );
        StartCoroutine( FadeIn( ) );
    }

    public void exitMenu( )
    {
        PlayerPrefs.Save( );
        StartCoroutine( goodbye( ) );
    }

    public void resetPrefs( )
    {
        // save volume mixers
        float masterVol = PlayerPrefs.GetFloat( "MasterVolume" );
        float musicVol = PlayerPrefs.GetFloat( "MusicVolume" );
        float sysVol = PlayerPrefs.GetFloat( "SystemVolume" );
        float effVol = PlayerPrefs.GetFloat( "EffectsVolume" );
        float charVol = PlayerPrefs.GetFloat( "CharacterVolume" );

        // reset all prefs 
        PlayerPrefs.DeleteAll( );
        PlayerPrefs.SetInt( "HasStartedGame", 0 );

        // return values of volume mixers
        PlayerPrefs.SetFloat( "MasterVolume", masterVol );
        PlayerPrefs.SetFloat( "MusicVolume", musicVol );
        PlayerPrefs.SetFloat( "SystemVolume", sysVol );
        PlayerPrefs.SetFloat( "EffectsVolume", effVol );
        PlayerPrefs.SetFloat( "CharacterVolume", charVol );
        PlayerPrefs.SetString( "SceneStart", "MainMenu" );
    }

    public void newGame( string sceneToChangeTo )
    {
        if( sceneToChangeTo != null )
            changeScene( sceneToChangeTo );
        else    
            changeScene( PlayerPrefs.GetString( "1.1" ) );
        PlayerPrefs.SetInt( "HasStartedGame", 1 );
    }

    public void continueGame( )
    {
        if( PlayerPrefs.GetString( "SceneStart" ) == "MainMenu" )
            PlayerPrefs.SetString( "SceneStart", "1.1" );
        changeScene( PlayerPrefs.GetString( "SceneStart" ) );
        PlayerPrefs.SetInt( "HasStartedGame", 1 );
    }

    public void changeScene( string thisScene )
    {
        sceneToChangeTo = thisScene;
        StartCoroutine( FadeThenLoad( ) );
    }

    IEnumerator FadeThenLoad( )
    {
        StartCoroutine( FadeOut( ) );
        while( true )
        {
            if( canvasGroup.alpha == 1f )
            {
                SceneManager.LoadScene( sceneToChangeTo );
                break;          
            }
            yield return null;
        }
        yield return null;
    }

    public IEnumerator goodbye( )
    {
        StartCoroutine( FadeOut( ) );
        while( true )
        {
            if( canvasGroup.alpha == 1f )
            {
                Debug.Log( "Exiting Game" );
                Application.Quit( );
                break;    
            }            
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeOut( )
    {
        while( canvasGroup.alpha < 1f )
        {
            canvasGroup.alpha += Time.deltaTime * fadeMultiplier;
            yield return null;
        }
        canvasGroup.alpha = 1f;
        yield return null;
    }

    IEnumerator FadeIn( )
    {
        while( canvasGroup.alpha > 0f )
        {
            canvasGroup.alpha -= Time.deltaTime * fadeMultiplier;
            yield return null;
        }
        canvasGroup.alpha = 0f;
        yield return null;
    }
}

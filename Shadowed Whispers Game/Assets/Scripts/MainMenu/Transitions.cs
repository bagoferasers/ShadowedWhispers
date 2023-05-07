using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{

    private CanvasGroup canvasGroup;
    public string sceneToChangeTo;

    void Start()
    {
        canvasGroup = GameObject.Find( "darkyboi" ).GetComponent< CanvasGroup >( );
    }

    public void FadeThisOnePlease( )
    {
        StartCoroutine( FadeOut( ) );
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
        PlayerPrefs.SetString( "SceneStart", "1.1" );
    }

    public void newGame( string sceneToChangeTo )
    {
        FadeThisOnePlease( );
        if( sceneToChangeTo != null )
            StartCoroutine( ChangeScene( sceneToChangeTo ) );
        else    
            StartCoroutine( ChangeScene( "1.1" ) );
        PlayerPrefs.SetInt( "HasStartedGame", 1 );
    }

    public void continueGame( )
    {
        FadeThisOnePlease( );
        if( PlayerPrefs.GetString( "SceneStart" ) == "MainMenu" )
            PlayerPrefs.SetString( "SceneStart", "1.1" );
        StartCoroutine( ChangeScene( PlayerPrefs.GetString( "SceneStart" ) ) );
        PlayerPrefs.SetInt( "HasStartedGame", 1 );
    }

    public IEnumerator ChangeScene( string sceneToChangeTo )
    {
        yield return new WaitForSeconds( 2 );
        SceneManager.LoadScene( sceneToChangeTo );
    }

    IEnumerator FadeOut( )
    {
        while( canvasGroup.alpha < 1 )
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}

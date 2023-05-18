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

        // settings
        int VibrateToggle = PlayerPrefs.GetInt( "VibrateToggle" );
        int AlertToggle = PlayerPrefs.GetInt( "AlertToggle" );
        int ColorBlindToggle = PlayerPrefs.GetInt( "ColorBlindToggle" );
        int FPSToggle = PlayerPrefs.GetInt( "FPSToggle" );
        int DamageToggle = PlayerPrefs.GetInt( "DamageToggle" );

        // yes no button
        string TextToDisplay = PlayerPrefs.GetString( "textToDisplay" );
        string setYes = PlayerPrefs.GetString( "YesButtonScene" );
        string setNo = PlayerPrefs.GetString( "NoButtonScene" );

        // reset all prefs 
        PlayerPrefs.DeleteAll( );
        PlayerPrefs.SetInt( "HasStartedGame", 0 );

        // yes no button
        PlayerPrefs.SetString( "textToDisplay", TextToDisplay );
        PlayerPrefs.SetString( "YesButtonScene", setYes );
        PlayerPrefs.SetString( "NoButtonScene", setNo );

        // return values of volume mixers
        PlayerPrefs.SetFloat( "MasterVolume", masterVol );
        PlayerPrefs.SetFloat( "MusicVolume", musicVol );
        PlayerPrefs.SetFloat( "SystemVolume", sysVol );
        PlayerPrefs.SetFloat( "EffectsVolume", effVol );
        PlayerPrefs.SetFloat( "CharacterVolume", charVol );
        PlayerPrefs.SetString( "SceneStart", "MainMenu" );

        // settings
        PlayerPrefs.SetInt( "VibrateToggle", VibrateToggle );
        PlayerPrefs.SetInt( "AlertToggle", AlertToggle );
        PlayerPrefs.SetInt( "ColorBlindToggle", ColorBlindToggle );
        PlayerPrefs.SetInt( "FPSToggle", FPSToggle );
        PlayerPrefs.SetInt( "DamageToggle", DamageToggle );
    }

    public void changeScene( string thisScene )
    {
        if( thisScene == "1.3" )
            PlayerPrefs.SetInt( "HasStartedGame", 1 );
        sceneToChangeTo = thisScene;
        StartCoroutine( FadeThenLoad( ) );
    }

    public void changeSceneYes( )
    {
        if( PlayerPrefs.GetInt( "OpeningScene" ) == 1 )
        {
            sceneToChangeTo = "AreYouSure";
            PlayerPrefs.SetString( "YesButtonScene", "1.3" );
            PlayerPrefs.SetString( "NoButtonScene", "1.2" );
            PlayerPrefs.SetString( "textToDisplay", "Do you want to skip the tutorial?" );
            PlayerPrefs.SetInt( "OpeningScene", 0 );
        }
        else if( PlayerPrefs.GetInt( "Tutorial" ) == 1 )
        {
            sceneToChangeTo = "1.3";
            PlayerPrefs.SetInt( "Tutorial", 0 );
        }
        else
            sceneToChangeTo = PlayerPrefs.GetString( "YesButtonScene");
        StartCoroutine( FadeThenLoad( ) );
    }

    public void changeSceneNo( )
    {
        sceneToChangeTo = PlayerPrefs.GetString( "NoButtonScene");
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

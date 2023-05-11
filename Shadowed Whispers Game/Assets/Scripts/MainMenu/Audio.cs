using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [ Header( "Put mixer here:" ) ]
    public AudioMixer mixer;
    public AudioSource[] musicList;

    private int songToPlay = 0;

    private void Awake( )
    {
        Audio[] audioObjects = FindObjectsOfType< Audio >( );
        if ( audioObjects.Length > 1 ) 
        {
            Destroy( gameObject );
            return;
        }
        DontDestroyOnLoad( gameObject );      
        PlayerPrefs.SetInt( "hasEnteredGame", 0 );
    }

    void Start( )
    {        
        songToPlay = Random.Range( 0, musicList.Length );
        musicList[ songToPlay ].Play( );
        if ( PlayerPrefs.GetInt( "hasEnteredGame" ) == 0 )
        {
            StartCoroutine( fadeMusicIn( ) );
            PlayerPrefs.SetInt( "hasEnteredGame", 1 );
        }
    }

    void Update( )
    {
        if ( SceneManager.GetActiveScene( ).name != "MainMenu" && SceneManager.GetActiveScene( ).name != "LoadGame"
            && SceneManager.GetActiveScene( ).name != "Progress" && SceneManager.GetActiveScene( ).name != "Settings"
            && SceneManager.GetActiveScene( ).name != "Credits" )
            Destroy( gameObject );

        if ( !musicList[ songToPlay ].isPlaying )
        {
            songToPlay = Random.Range( 0, musicList.Length );
            musicList[ songToPlay ].Play( );
        }
    }

    public void fadeTheMusic( )
    {
        StartCoroutine( fadeMusicOut( ) ) ;
    }

    IEnumerator fadeMusicIn( )
    {
        float originalVolume = -20f;
        float currentVolume = -40f;
        if ( PlayerPrefs.GetFloat( "MusicVolume" ) != 0 )
            originalVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        mixer.SetFloat( "MusicVolume", currentVolume );
        while ( currentVolume < originalVolume )
        {
            currentVolume += 1.5f * Time.deltaTime;
            mixer.SetFloat( "MusicVolume", currentVolume );
            yield return null;
        }            
    }

    IEnumerator fadeMusicOut( )
    {
        float originalVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        float currentVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        float targetVolume = -26f;
        mixer.SetFloat( "MusicVolume", currentVolume );
        while ( currentVolume > targetVolume )
        {
            currentVolume -= 0.5f * Time.deltaTime;
            mixer.SetFloat( "MusicVolume", currentVolume );
            yield return null;
        }
    }

    void OnDestroy( )
    {
        StopAllCoroutines( );
        foreach ( var music in musicList )
        {
            music.Stop( );
        }
    }
}
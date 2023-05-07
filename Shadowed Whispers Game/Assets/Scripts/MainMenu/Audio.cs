using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [ Header( "Put mixer here:" ) ]
    public AudioMixer mixer;
    public AudioSource[ ] musicList;

    private float random;
    private int songToPlay = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( playMusic( ) );
    }

    void Update( ) 
    {
        if( !musicList[ songToPlay ].isPlaying )
        {
            songToPlay = Random.Range( 0, musicList.Length );
            musicList[ songToPlay ].Play( );
        }
    }

    void fadeTheMusic( )
    {
        StartCoroutine( fadeMusic( ) );
    }

    IEnumerator playMusic( )
    {
        float originalVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        float currentVolume = -26f;
        mixer.SetFloat( "Music", currentVolume );
        while( currentVolume < originalVolume )
        {
            currentVolume += 0.1f;
            mixer.SetFloat( "Music", currentVolume );
            yield return null;
        }
        yield return null;
    }

    IEnumerator fadeMusic( )
    {
        float originalVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        float currentVolume = PlayerPrefs.GetFloat( "MusicVolume" );
        float targetVolume = -26f;
        mixer.SetFloat( "Music", currentVolume );
        while( currentVolume > targetVolume )
        {
            currentVolume -= 0.3f;
            mixer.SetFloat( "Music", currentVolume );
            yield return null;
        }
        yield return null;
    }
}

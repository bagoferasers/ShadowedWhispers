using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDispatch : MonoBehaviour
{
    public TMP_Text textToDisplay;
    public float typingSpeed = 0.1f;
    public AudioClip sound;

    private AudioSource audioSource;
    private string originalTextToDisplay;

    private void Start( )
    {
        audioSource = GetComponent< AudioSource >( );
        originalTextToDisplay = PlayerPrefs.GetString( "textToDisplay" );
        PlayerPrefs.SetString( "textToDisplay", "" );
        StartCoroutine( KeyboardType( ) );
    }

    private IEnumerator KeyboardType( )
    {
        foreach ( char c in originalTextToDisplay )
        {
            textToDisplay.text += c;
            if( c != ' ' )
            {
                audioSource.PlayOneShot( sound );
                yield return new WaitForSeconds( Random.Range( 0f, typingSpeed ) );
            }
            else 
                yield return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Will be used to display discord, twitter, itch.io, GitHub,
    and YouTube contacts. Will display all developers, sponsors, and references 
    to open source resources.
*/
public class credits_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    private CanvasGroup credits_menuCanvas;

    void start( )
    {
        credits_menuCanvas = GameObject.Find( "credits_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Will be used only after confirming new game. 
    Will consist of all character customization options for game. Examples will 
    include name, character sprite, clothing options, sex, and gender. Will not be
    available after game initializes.
*/
public class custom_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    private CanvasGroup custom_menuCanvas;

    void start( )
    {
        custom_menuCanvas = GameObject.Find( "custom_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
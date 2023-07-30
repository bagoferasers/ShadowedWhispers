using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Will be used to adjust settings. Will initialize at
    opening the game for the first time. Volume will be initialized to zero to
    allow for proper player customization to their individual comfort level. 
*/
public class settings_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    private CanvasGroup settings_menuCanvas;

    void start( )
    {
        settings_menuCanvas = GameObject.Find( "settings_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This class will be used for selecting or deleting save slots.
*/
public class loadGame_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    private CanvasGroup loadGame_menuCanvas;

    void start( )
    {
        loadGame_menuCanvas = GameObject.Find( "loadGame_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
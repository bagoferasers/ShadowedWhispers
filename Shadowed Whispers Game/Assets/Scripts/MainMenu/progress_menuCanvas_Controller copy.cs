using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This class will be used for showing progress in game. Will 
    include maps, achievements, acts completed, player stats, and 
    relationships progress.
*/
public class progress_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    private CanvasGroup progress_menuCanvas;

    void start( )
    {
        progress_menuCanvas = GameObject.Find( "progress_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
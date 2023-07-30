using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This class will be used for questions for player verification.
    For example: Are you sure you want to delete the save slot? Are you sure
    you want to override the save slot? Are you sure you want to start a 
    new game? 
*/
public class chatBox_menuCanvas_Controller : MonoBehaviour, fadeCanvasGroup, Transitions
{
    /*
        - credits_menuCanvas   : Will be used to display discord, twitter, itch.io, GitHub,
                and YouTube contacts. Will display all developers, sponsors, and references 
                to open source resources.
    */
    private CanvasGroup chatBox_menuCanvas;

    void start( )
    {
        chatBox_menuCanvas = GameObject.Find( "chatBox_menuCanvas" ).GetComponent< CanvasGroup >( );
    }
}
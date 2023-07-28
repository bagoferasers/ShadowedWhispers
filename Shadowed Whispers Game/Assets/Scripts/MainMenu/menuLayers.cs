using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    The class menuLayers will be used to manage the different overlays within the
    menu scene.
*/
public class menuLayers : MonoBehaviour, fadeCanvasGroup
{
    /*
        Menu CanvasGroups used as overlays for menu scene. Will reduce
        the number of scenes used before starting game.
        -------------------------------------------------------------------------------
        - chatBox_menuCanvas    : Will be used for questions for player verification.
                For example: Are you sure you want to delete the save slot? Are you sure
                you want to override the save slot? Are you sure you want to start a 
                new game? 
        - loadGame_menuCanvas   : Will be used for selecting or deleting save slots.
        - progress_menuCanvas   : Will be used for showing progress in game. Will 
                include maps, achievements, acts completed, player stats, and 
                relationships progress.
        - settings_menuCanvas   : Will be used to adjust settings. Will initialize at
                opening the game for the first time. Volume will be initialized to zero to
                allow for proper player customization to their individual comfort level. 
        - custom_menuCanvas     : Will be used only after confirming new game. 
                Will consist of all character customization options for game. Examples will 
                include name, character sprite, clothing options, sex, and gender. Will not be
                available after game initializes.
        - credits_menuCanvas   : Will be used to display discord, twitter, itch.io, GitHub,
                and YouTube contacts. Will display all developers, sponsors, and references 
                to open source resources.
    */
    private CanvasGroup chatBox_menuCanvas;
    private CanvasGroup loadGame_menuCanvas;
    private CanvasGroup progress_menuCanvas;
    private CanvasGroup settings_menuCanvas;
    private CanvasGroup custom_menuCanvas;
    private CanvasGroup credits_menuCanvas;

    private void showCanvas( CanvasGroup canvasGroup )
    {
        increaseAlpha( canvasGroup );
    }

    private void hideCanvas( CanvasGroup canvasGroup )
    {
        increaseAlpha( canvasGroup.alpha );
    }
}
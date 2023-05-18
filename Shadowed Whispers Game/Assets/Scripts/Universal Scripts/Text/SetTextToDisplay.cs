using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextToDisplay : MonoBehaviour
{
    public string TextToDisplay;
    public string setYes;
    public int setTutorial;
    public int setOpening;
    public string setNo;

    public void setTextToDisplay( )
    {
        PlayerPrefs.SetString( "textToDisplay", TextToDisplay );
        PlayerPrefs.SetString( "YesButtonScene", setYes );
        PlayerPrefs.SetString( "NoButtonScene", setNo );
        PlayerPrefs.SetInt( "Tutorial", setTutorial );
        PlayerPrefs.SetInt( "OpeningScene", setOpening );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    public Toggle t;
    public Image i;
    public Color cOn;
    public Color cOff;
    public string playerPrefsName;

    private void Start( )
    {
        t.onValueChanged.AddListener( changedValue );
        if( PlayerPrefs.GetInt( "HasStartedGame" ) == 0 )
        {
            if( playerPrefsName == "DamageToggle" || playerPrefsName == "AlertToggle" || playerPrefsName == "VibrateToggle" )
            {
                t.isOn = true;
                i.color = cOn;                
            }
            else
            {
                i.color = cOff;
                t.isOn = false;
            }
        }       
        else
        {
            if( PlayerPrefs.GetInt( playerPrefsName ) == 0 )
                t.isOn = false; 
            else
            {
                t.isOn = false;
                i.color = cOff;
            }            
        }
    }

    private void changedValue( bool isOn )
    {
        if( isOn ) 
        {
            PlayerPrefs.SetInt( playerPrefsName, 1 );
            i.color = cOn;
        }
        else
        {
            PlayerPrefs.SetInt( playerPrefsName, 0 );
            i.color = Color.red;
        }
    }

    private void OnDestroy( )
    {
        t.onValueChanged.RemoveListener( changedValue );
    }
}

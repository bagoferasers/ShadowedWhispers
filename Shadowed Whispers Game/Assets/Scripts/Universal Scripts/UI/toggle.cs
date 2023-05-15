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

    // Start is called before the first frame update
    private void Start( )
    {
        t.onValueChanged.AddListener( changedValue );
        if( PlayerPrefs.GetInt( playerPrefsName, 0 ) == 0 )
            t.isOn = false; 
        else
        {
            t.isOn = true;
            i.color = cOn;
        }
    }

    // Update is called once per frame
    private void changedValue( bool isOn )
    {
        if( isOn ) 
        {
            Debug.Log( "t is on" );
            PlayerPrefs.SetInt( playerPrefsName, 1 );
            i.color = cOn;
        }
        else
        {
            Debug.Log( "t is off" );
            PlayerPrefs.SetInt( playerPrefsName, 0 );
            i.color = Color.red;
        }
    }

    private void OnDestroy( )
    {
        t.onValueChanged.RemoveListener( changedValue );
    }
}

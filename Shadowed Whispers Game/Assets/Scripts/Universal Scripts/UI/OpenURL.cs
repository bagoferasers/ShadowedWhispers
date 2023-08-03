using UnityEngine;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour
{
    [ Header( "Full URL:" ) ]
    public string URL;

    public void openURL( )
    {
        Application.OpenURL( URL );
    }
}
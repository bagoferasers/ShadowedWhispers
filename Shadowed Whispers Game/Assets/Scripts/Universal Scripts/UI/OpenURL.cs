using UnityEngine;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour
{
    public string URL;

    public void openURL( )
    {
        Application.OpenURL( URL );
    }
}
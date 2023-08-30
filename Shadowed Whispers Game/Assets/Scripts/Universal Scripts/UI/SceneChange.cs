using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;
    private CanvasGroup Canvas;
    
    public void changeScene( )
    {
        Canvas = GameObject.Find( "blackCanvas" ).GetComponent< CanvasGroup >( );
        StartCoroutine( waitToChange( ) );
        
    }
    IEnumerator waitToChange( )
    {
        while( Canvas.alpha < 1 )
        {
            yield return null;
        }
        SceneManager.LoadScene( scene );
        yield return null;
    }
}
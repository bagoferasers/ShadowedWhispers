using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeCanvasGroup
{
    // read only 
    CanvasGroup Canvas
    {
        get;
    }

    void showCanvas( float fadeTime );
    void hideCanvas( float fadeTime );
}
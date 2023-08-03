using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeCanvasGroup
{
    CanvasGroup canvasGroup{ get; }
    void showCanvas( );
    void hideCanvas( );
}
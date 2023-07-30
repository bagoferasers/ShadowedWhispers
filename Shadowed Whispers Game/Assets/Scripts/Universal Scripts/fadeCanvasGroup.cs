using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    The class fadeCanvasGroup will be used to fade in and out a CanvasGroup object.
*/
public class fadeCanvasGroup : MonoBehaviour
{
    /*
        This helper function will be used to show a CanvasGroup object. It will
        involve fading in the object till it is fully visible. It will also 
        implement the animations.
    */
    public void showCanvas( CanvasGroup canvasGroup )
    {
        StartCoroutine( increaseAlpha( canvasGroup ) );
    }

    /*
        This helper function will be used to hide a CanvasGroup object. It will
        involve fading out the object till it is fully invisible.
    */
    public void hideCanvas( CanvasGroup canvasGroup )
    {
        StartCoroutine( decreaseAlpha( canvasGroup ) );
    }

    /*
        This IEnumberator will be used to increase the transparency of a
        CanvasGroup object until it is visible.
    */
    private IEnumerator increaseAlpha( CanvasGroup canvasGroup )
    {
        while( canvasGroup.alpha < 1 )
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }

    /*
        This IEnumberator will be used to decrease the transparency of a
        CanvasGroup object until it is invisible.
    */
    private IEnumerator decreaseAlpha( CanvasGroup canvasGroup )
    {
        while( canvasGroup.alpha > 0 )
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}
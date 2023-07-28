using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*

*/
public class fadeCanvasGroup : MonoBehaviour
{
    /*

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
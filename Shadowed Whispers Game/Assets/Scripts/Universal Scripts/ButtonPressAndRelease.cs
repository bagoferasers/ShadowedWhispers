using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressAndRelease : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource press;
    public AudioSource release;

    public void OnPointerDown( PointerEventData eventData )
    {
        press.Play( );
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        release.Play( );
    }
}

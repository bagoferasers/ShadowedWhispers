using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float flickerSpeed = 4.0f;
    private float intensity = 0.5f;

    void Start( )
    {
        light2D = this.GetComponent< UnityEngine.Rendering.Universal.Light2D >( );
        //StartCoroutine( FlickerCoroutine( ) );
    }

    // private IEnumerator FlickerCoroutine( )
    // {
    //     while( true ) 
    //     {

    //     }
    //     yield return null;
    // }
}

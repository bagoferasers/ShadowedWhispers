using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float flickerSpeed = 5.0f;
    private float flickerRange = 0.5f;
    private float intensity = 0.5f;
    private WaitForSeconds waitTime;

    void Start( )
    {
        light2D = this.GetComponent< UnityEngine.Rendering.Universal.Light2D >( );
        waitTime = new WaitForSeconds( Random.Range( 0.1f, 10.0f ) );
        StartCoroutine( FlickerCoroutine( ) );
    }

    private IEnumerator FlickerCoroutine( )
    {
        while( true ) 
        {
            yield return waitTime;
            flickerSpeed = 0.1f;
            intensity = 0.5f + Random.Range( 0.0f, 0.4f );
            float elapsedTime = 0.0f;
            while( elapsedTime < flickerSpeed )
            {
                elapsedTime += Time.deltaTime;
                light2D.intensity = Mathf.PingPong( 1.0f, intensity );
                yield return null;
            }
            light2D.intensity = 1.0f;
            waitTime = new WaitForSeconds( Random.Range( 0.1f, 5.0f ) );
        }
    }
}

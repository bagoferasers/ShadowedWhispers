using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float flickerSpeed;
    private float targetIntensity;

    void Start( )
    {
        light2D = this.GetComponent< UnityEngine.Rendering.Universal.Light2D >( );
        StartCoroutine( FlickerCoroutine( ) );
    }

    private IEnumerator FlickerCoroutine( )
    {
        float t = 0;
        while( t < 1 )
        {
            flickerSpeed = Random.Range(0.1f, 0.5f );
            targetIntensity = Random.Range(1f, 3f );
            light2D.intensity = Mathf.Lerp( light2D.intensity, targetIntensity, t );
            t += Time.deltaTime * flickerSpeed;
            Debug.Log( t );
            yield return null;
        }
        light2D.intensity = 3f;
        yield return null;
    }
}

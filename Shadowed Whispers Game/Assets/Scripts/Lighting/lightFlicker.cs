using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D myLight;
    public float minIntensity;
    public float maxIntensity;
    public float maxDuration;
    private float duration;
    public float speed;
    public float delay;
    private float originalDuration;

    void Start( )
    {
        originalDuration = duration;
        StartCoroutine( Flicker( ) );
    }

    private IEnumerator Flicker( )
    {
        while( true )
        {
            
            duration = Random.Range( 0, maxDuration );
            while( duration > 0 )
            {
                float i = Mathf.Lerp( minIntensity, maxIntensity, Mathf.PingPong( Time.time * speed, 1f ) );
                myLight.intensity = i;
                yield return null;
                duration -= Time.deltaTime;
            }
            duration = originalDuration;
            yield return new WaitForSeconds( delay );
        }
    }
}

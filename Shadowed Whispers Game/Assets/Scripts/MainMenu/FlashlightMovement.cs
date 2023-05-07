using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationAngle;

    private bool rotating;
    private Quaternion startRotation;
    private Quaternion newRotation;

    void Start()
    {
        startRotation = transform.rotation;
        rotating = false;
    }

    void Update()
    {
        if( !rotating )
        {
            newRotation = Quaternion.Euler( 0f, 0f, Random.Range( 0f, rotationAngle ) );
            transform.rotation = Quaternion.Lerp( transform.rotation, newRotation, Time.deltaTime * rotationSpeed );
            rotating = true;
            StartCoroutine( goWait( ) );
        }   
    }

    IEnumerator goWait( )
    {
        if( rotating )
        {
            transform.rotation = Quaternion.Lerp( transform.rotation, newRotation, Time.deltaTime * rotationSpeed );
        }
        rotating = false;
        yield return null;
    }
}

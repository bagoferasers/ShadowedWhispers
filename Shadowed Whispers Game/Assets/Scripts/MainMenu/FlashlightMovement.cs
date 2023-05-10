using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationAngle;
    public float waitThisMuch;

    private bool rotating;
    private Quaternion startRotation;
    private Quaternion newRotation;

    void Start()
    {
        startRotation = transform.rotation;
        newRotation = Quaternion.Euler( 0f, 0f, Random.Range( 0f, rotationAngle ) );
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
            StartCoroutine( rotateThisWay( ) );
        }   
    }

    IEnumerator goWait( )
    {
        yield return new WaitForSeconds( waitThisMuch );
        rotating = false;
    }

    IEnumerator rotateThisWay( )
    {
        transform.rotation = Quaternion.Lerp( transform.rotation, newRotation, Time.deltaTime * rotationSpeed );
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimatorController : MonoBehaviour
{
    public float minDelay = 0.0f;
    public float maxDelay = 5.0f;
    private Animator animator;
    private float delay = 0.0f;
    private int animateRatio = 0;

    // Start is called before the first frame update
    void Start( )
    {
        animator = this.GetComponent< Animator >( );
        delay = Random.Range( minDelay, maxDelay );
        animateRatio = Random.Range( 0, 3 );
        if( animateRatio > 1 )
            StartCoroutine( animate( ) );
    }

    IEnumerator animate( )
    {
        yield return new WaitForSeconds( delay );
        animator.enabled = true;
    }
}

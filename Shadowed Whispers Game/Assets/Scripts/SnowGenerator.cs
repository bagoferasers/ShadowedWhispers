using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    private GameObject snowflakePrefab1;
    private GameObject snowflakePrefab2;
    private GameObject snowflakePrefab3;
    private GameObject[] snowflakes;
    private Transform snowflakeParent;
    public float maxRotationSpeed = 30.0f;
    public float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start( )
    {
        snowflakePrefab1 = GameObject.Find( "Snowflake_1" );
        snowflakePrefab2 = GameObject.Find( "Snowflake_2" );
        snowflakePrefab3 = GameObject.Find( "Snowflake_3" );
        snowflakeParent = this.transform;
        snowflakes = new GameObject[] { snowflakePrefab1, snowflakePrefab2, snowflakePrefab3 };
        StartCoroutine( GenerateSnow( ) );
    }

    IEnumerator GenerateSnow( )
    {
        while( true )
        {
            int i = Random.Range( 0, 3 );
            GameObject snowflakePrefab = snowflakes[ i ];

            // position in sky
            Vector3 spawnPosition = new Vector3( Random.Range( -2f, 10f ), 0.5f, 0f );
            
            // create snowflake and add physics
            GameObject snowflake = Instantiate( snowflakePrefab, spawnPosition, Quaternion.identity );
            snowflake.transform.parent = snowflakeParent;
            Rigidbody2D rb = snowflake.AddComponent< Rigidbody2D >( );
            if( rb != null )
            {
                rb.velocity = Vector3.down * Random.Range( 0.01f, 0.1f );
                rb.mass = 0.00001f;
                rb.gravityScale = 0.00001f;              
                rb.angularVelocity = Random.Range(-maxRotationSpeed, maxRotationSpeed);
            }

            Destroy( snowflake, 20.0f );

            yield return new WaitForSeconds( spawnInterval );
        }
    }
}

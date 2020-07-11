using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Physics2D;
//using Collider = UnityEngine.Physics2DModule.Collider2D;
//using Rigidbody = UnityEngine.Physics2DModule.Rigidbody2D;


public class WordBlaster : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider2D colliders;
        ContactFilter2D cf = new ContactFilter2D();
        //Physics2D.OverlapCircle(explosionPos, radius, cf, colliders);
        /* 
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        */
    }
}

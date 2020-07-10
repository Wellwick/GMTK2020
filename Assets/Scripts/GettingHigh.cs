using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHigh : MonoBehaviour
{
    public float jumpTime = 1.0f;
    public float jumpSpeed = 2.0f;
    private float lastContact;
    private bool landed;

    // Update is called once per frame
    void Update()
    {
        /*
        List<Collider2D> collisions = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.NameToLayer("Platforms");
        filter.useLayerMask = true;
        if (this.gameObject.GetComponent<BoxCollider2D>().OverlapCollider(filter, collisions) > 0) {
            lastContact = Time.realtimeSinceStartup;
            Debug.Log("Hey we just touched a thing");
        } else {
            
        }
        if (this.gameObject.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.NameToLayer("Platforms"))) {
            Debug.Log("Touching the platforms");
        } else {
            Debug.Log("Not touching the platforms of which there are " + LayerMask.NameToLayer("Platforms").ToString());
        }
        */
        if (Input.GetKey("space")) {
            if (landed) {
                landed = false;
                lastContact = 0.0f;
            } else {
                lastContact += Time.deltaTime;
                if (lastContact < jumpTime) {
                    Vector2 currentVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVelocity.x, jumpSpeed * lastContact);
                    Debug.Log("Jumping");
                } else {
                    Debug.Log("Can't jump anymore");
                }
            }
        } else {
            lastContact = jumpTime;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GeneralPlatform>()) {
            landed = true;
        } else {
            Debug.Log("You hit a wall");
        }
    }
}

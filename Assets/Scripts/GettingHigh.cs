using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHigh : MonoBehaviour
{
    public float jumpTime = 1.0f;
    public float jumpSpeed = 2.0f;
    private float lastContact;
    private bool landed;
    public float lastYSpeed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        lastYSpeed = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey("space")) {
            if (landed) {
                landed = false;
                lastContact = 0.0f;
                GetComponent<ParticleSystem>().Play();
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
        } else if (Input.GetKey("d")) {
            landed = false;
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

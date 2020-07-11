using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHigh : MonoBehaviour
{
    public float jumpTime = 1.0f;
    public float maxJumpSpeed = 2.0f;
    public AnimationCurve ac;
    private float lastContact;
    private bool landed;
    public float lastYSpeed = 0.0f;

    // Update is called once per frame
    // Jump up if space is pressed, as long as you are on the ground, or it's still in jump time
    // Turn off landed if you press down (can't jump if you decide to fall through a platform)
    // Reset last point of contact otherwise!
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
                    float interp = lastContact / jumpTime;
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVelocity.x, maxJumpSpeed * ac.Evaluate(interp));
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

    // Turn on landed if you hit a GeneralPlatform
    // Needs some extra work so it doesn't count when you hit the bottom or sides
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GeneralPlatform>()) {
            landed = true;
        }
    }

    // Turn off landed when leaving a general platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GeneralPlatform>()) {
            landed = false;
        }
    }
}

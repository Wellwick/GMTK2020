using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallthroughPlatform : MonoBehaviour
{

    public float timeToDisable = 0.4f;
    private float falling = 0.0f;
    private bool movingUp = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            falling = timeToDisable;
        } else if (!movingUp) {
            if (falling <= 0.0f) {
                return;
            }
            falling -= Time.deltaTime;
            if (falling < 0.0f) {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GettingHigh gh = collision.gameObject.GetComponent<GettingHigh>();

        if (gh && gh.lastYSpeed > 0.0f) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, gh.lastYSpeed);
            movingUp = true;
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Debug.Log("You're trying to blast through!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (movingUp && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0f) {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            movingUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        movingUp = false;
    }
}

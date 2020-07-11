using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallthroughPlatform : MonoBehaviour
{
    private GameObject player;
    public float timeToDisable = 0.4f;
    private float falling = 0.0f;
    private bool movingUp = false;


    // Setup the player that we want to be aware of from the start
    private void Start()
    {
        player = Object.FindObjectOfType<MainCharacter>().gameObject;
    }

    // Update is called once per frame
    // Potentially allow falling through the bottom of the platform
    void Update()
    {
        bool ignoreCollision = player.transform.position.y < gameObject.transform.position.y;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), ignoreCollision);
        if (Input.GetKey("s")) {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            falling = timeToDisable;
        } else if (!movingUp) {
            /*if (falling <= 0.0f) {
                return;
            }
            falling -= Time.deltaTime;
            if (falling < 0.0f) {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }*/
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    
    // If a player is colliding with us and moving upwards, let them through!
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

    // If the player is falling down through us, make sure it's registered that
    // they are falling downwards. Imagine jumping up into a platform and falling
    // back down without fully coming up on the other side.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (movingUp && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0f) {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            movingUp = false;
        }
    }

    // Possibly a bit unnecessary, but best to be careful. Turn on full collision again
    // when the (possible) player has passed out of the platform.
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        movingUp = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float maxSpeed = 6.0f;
    public float acceleration = 10.0f;

    // Update is called once per frame
    // Move left and right when you press the right buttons.
    void Update()
    {
        float currentX = this.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float currentY = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey("a") && !Input.GetKey("d")) {
            float xSpeed = currentX - (acceleration * Time.deltaTime);
            if (xSpeed > 0.0f) {
                xSpeed -= acceleration * Time.deltaTime;
            }
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, currentY);
        } else if (Input.GetKey("d") && !Input.GetKey("a")) {
            float xSpeed = currentX + (acceleration * Time.deltaTime);
            if (xSpeed < 0.0f) {
                xSpeed += acceleration * Time.deltaTime;
            }
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, currentY);
        }
    }
}

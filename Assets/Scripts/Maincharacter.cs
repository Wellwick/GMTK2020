using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public float acceleration = 2.0f;

    // Update is called once per frame
    void Update()
    {
        float currentX = this.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float currentY = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey("a") && !Input.GetKey("d")) {
            float xSpeed = currentX - (acceleration * Time.deltaTime);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, currentY);
            Debug.Log("Going left");
        } else if (Input.GetKey("d") && !Input.GetKey("a")) {
            float xSpeed = currentX + (acceleration * Time.deltaTime);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, currentY);
            Debug.Log("Going right");
        }
    }
}

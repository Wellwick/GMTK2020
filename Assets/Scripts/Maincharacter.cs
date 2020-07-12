using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float maxSpeed = 6.0f;
    public float maxSprintSpeed = 12.0f;
    public float regularAcceleration = 10.0f;
    public float shiftAcceleration = 15.0f;
    private float realMaxSpeed;
    private float realAcceleration;

    // Update is called once per frame
    // Move left and right when you press the right buttons.
    void Update()
    {
        if (Input.GetKey("left shift")) {
            realMaxSpeed = maxSprintSpeed;
            realAcceleration = shiftAcceleration;
        } else {
            realMaxSpeed = maxSpeed;
            realAcceleration = regularAcceleration;
        }
        float currentX = this.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float currentY = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey("a") && !Input.GetKey("d")) {
            currentX -= (realAcceleration * Time.deltaTime);
            if (currentX > 0.0f) {
                currentX -= realAcceleration * Time.deltaTime;
            }
        } else if (Input.GetKey("d") && !Input.GetKey("a")) {
            currentX += (realAcceleration * Time.deltaTime);
            if (currentX < 0.0f) {
                currentX += realAcceleration * Time.deltaTime;
            }
        }
        if (Mathf.Abs(currentX) > realMaxSpeed) {
            currentX *= 0.9f;
            if (currentX < -realMaxSpeed) {
                currentX = -realMaxSpeed;
            } else if (currentX > realMaxSpeed) {
                currentX = realMaxSpeed;
            }
        }

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentX, currentY);

    }
}

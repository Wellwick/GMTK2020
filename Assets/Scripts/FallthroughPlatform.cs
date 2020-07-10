using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallthroughPlatform : MonoBehaviour
{

    public float timeToDisable = 0.4f;
    private float falling = 0.0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            falling = timeToDisable;
        } else {
            if (falling <= 0.0f) {
                return;
            }
            falling -= Time.deltaTime;
            if (falling < 0.0f) {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}

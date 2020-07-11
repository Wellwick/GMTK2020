using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject hookPrefab;
    public float range = 8.0f;
    public float fireSpeed = 14.0f;
    public float reelSpeed = 2.0f;
    private bool firing = false;
    private bool reeling = false;
    private float firedDistance;

    private Vector3 direction;
    private Vector3 reelDest;
    private Hook hook;

    // Update is called once per frame
    // Fire a grapple if you haven't already, when hitting E
    // Move grapple along if it is still firing
    // If grapple has landed, reel in the player
    // Destroy the hook and refire if needed
    void Update()
    {
        if (Input.GetKey("e") && !firing) {
            if (hook) {
                GameObject.Destroy(hook.gameObject);
                reeling = false;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = ray.GetPoint(0.0f);
            pos.z = 0.0f;
            direction = pos - transform.position;
            Debug.Log("Direction to grapple is (" + direction.x + ", " + direction.y + ")");
            firing = true;
            firedDistance = 0.0f;
            hook = GameObject.Instantiate(
                hookPrefab, 
                transform.position, 
                Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg*Mathf.Atan2(direction.y,direction.x)+-90.0f)
            ).GetComponent<Hook>();
            reeling = false;
            gameObject.GetComponent<LineRenderer>().enabled = true;
        } else if (reeling) {

        }

        if (firing) {
            Vector3 movement = direction.normalized * fireSpeed * Time.deltaTime;
            if (movement.magnitude + firedDistance > range) {
                firing = false;
                GameObject.Destroy(hook.gameObject);
                gameObject.GetComponent<LineRenderer>().enabled = false;
            } else {
                hook.transform.position += movement;
                firedDistance += movement.magnitude;
            }
        }

        if (hook) {
            Vector3 hookPos = hook.gameObject.transform.position;
            Vector3 ourPos = transform.position;
            LineRenderer lr = gameObject.GetComponent<LineRenderer>();
            lr.SetPosition(0, ourPos);
            lr.SetPosition(1, hookPos);
        }

    }

    // Draw a white line in scene view to show that the grapple direction is working
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + (direction.normalized * range));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject hookPrefab;
    public float range = 10.0f;
    public float fireSpeed = 8.0f;
    public float reelSpeed = 2.0f;
    private bool firing = false;
    private bool reeling = false;
    private float firedDistance;

    private Vector3 direction;
    private Vector3 reelDest;
    private Hook hook;

    // Update is called once per frame
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
            hook = GameObject.Instantiate(hookPrefab, transform.position, Quaternion.LookRotation(direction)).GetComponent<Hook>();
            reeling = false;
        } else if (reeling) {

        }

        if (firing) {

        }

        if (hook) {
            Vector3 hookPos = hook.gameObject.transform.position;
            Vector3 ourPos = transform.position;
            LineRenderer lr = gameObject.GetComponent<LineRenderer>();
            lr.SetPosition(0, ourPos);
            lr.SetPosition(1, hookPos);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + (direction.normalized * range));
    }
}

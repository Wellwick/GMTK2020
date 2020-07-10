using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlatform : MonoBehaviour
{
    // This class does nothing
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.transform.position += new Vector3(0.0f, 0.002f);
    }
}

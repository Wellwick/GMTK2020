using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralPlatform : MonoBehaviour
{
    // This class does nothing
    private bool grappleable = true;
    
    // Push the player up a bit!
    private void OnCollisionStay2D(Collision2D collision)
    {
        MainCharacter mc = collision.gameObject.GetComponent<MainCharacter>();
        if (mc) {
            mc.transform.position += new Vector3(0.0f, 0.002f);
        }
    }

    // 
    public void DestroyingTime()
    {
        // Don't destroy the object, just disable collisions and make it invisible
        GetComponent<BoxCollider2D>().enabled = false;
        Text text = GetComponent<Text>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (text) {
            text.enabled = false;
        }
        if (sr) {
            sr.enabled = false;
        }
    }

    public void SetGrappleable(bool p_grappleable)
    {
        grappleable = p_grappleable;
    }

    public bool IsGrappleable()
    {
        return grappleable;
    }
}

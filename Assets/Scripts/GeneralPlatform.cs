using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlatform : MonoBehaviour
{
    // This class does nothing
    
    // Push the player up a bit!
    private void OnCollisionStay2D(Collision2D collision)
    {
        MainCharacter mc = collision.gameObject.GetComponent<MainCharacter>();
        if (mc) {
            mc.transform.position += new Vector3(0.0f, 0.002f);
        }
    }

    // Destroy the object, maybe do more if you fancy, like trigger a particle effect!
    public void DestroyingTime()
    {
        GameObject.Destroy(this.gameObject);
    }
}

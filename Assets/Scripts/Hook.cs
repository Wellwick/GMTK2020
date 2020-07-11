using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Grapple grappler;

    // Make sure you can get back to the class which is doing the real work
    public void SetGrappler(Grapple p_grappler)
    {
        grappler = p_grappler;
    }

    // Start is called before the first frame update
    // Make sure we ignore collisions with the player
    void Start()
    {
        MainCharacter mc = FindObjectOfType<MainCharacter>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), mc.gameObject.GetComponent<BoxCollider2D>(), true);
    }

    // If we hit a platform, get reeeeeeeling.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GeneralPlatform gp = collision.gameObject.GetComponent<GeneralPlatform>();
        Debug.Log("Time to something something");
    }
}

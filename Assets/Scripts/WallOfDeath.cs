using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeath : MonoBehaviour
{
    public GameObject player;
    float risingSpeed = 1.0f;

    // Update is called once per frame
    // Stay beneath the player!
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(player.transform.position.x, pos.y + risingSpeed * Time.deltaTime);
    }

    // Destroy general platforms when we encounter them!
    // End the game if we catch the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Have a trigger collision!");
        GeneralPlatform gp = collision.gameObject.GetComponent<GeneralPlatform>();
        if (gp) {
            gp.DestroyingTime();
        }
        MainCharacter mc = collision.gameObject.GetComponent<MainCharacter>();
        if (mc) {
            SceneManager.LoadScene("Game Over");
        }
    }
}

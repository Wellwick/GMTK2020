using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeath : MonoBehaviour
{
    float risingSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0.0f, risingSpeed * Time.deltaTime);
    }

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

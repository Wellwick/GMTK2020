using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainCharacter mc = collision.gameObject.GetComponent<MainCharacter>();
        if (mc) {
            SceneManager.LoadScene("Escape");
        }
    }
}

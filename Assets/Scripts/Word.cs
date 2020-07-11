using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public string word;
    private bool touched = false;

    // Start is called before the first frame update
    void Awake()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = word;
        Debug.Log("The preferred width of " + text.text + " is " + text.preferredWidth);
    }

    private void Start()
    {
        Text text = gameObject.GetComponent<Text>();
        RectTransform rt = GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight);
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(text.preferredWidth, text.preferredHeight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!touched) {
            MainCharacter player = collision.gameObject.GetComponent<MainCharacter>();
            if (player) {
                touched = true;
                Text text = GetComponent<Text>();
                text.color -= new Color(40.0f, 40.0f, 40.0f);
            }
        }
    }
}

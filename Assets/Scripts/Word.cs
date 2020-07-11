using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public string word;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}

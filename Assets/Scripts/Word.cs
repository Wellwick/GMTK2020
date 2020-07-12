using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public string word;
    private bool touched = false;

    // Start is called before the first frame update
    // Set the text via a variable
    void Awake()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = word;
        //Debug.Log("The preferred width of " + text.text + " is " + text.preferredWidth);
    }

    // Change up the rectangular transform and box collider based on the word
    // set during the awake stage!
    private void Start()
    {
        Text text = gameObject.GetComponent<Text>();
        RectTransform rt = GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight);
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(text.preferredWidth, text.preferredHeight);
    }

    void Update() {
        if (Input.GetKey("i") && false) {
            Vector3 playerPos = FindObjectOfType<MainCharacter>().gameObject.transform.position;
            BlastIt(playerPos, 50.0f);
        }
    }

    // Slightly darken the colour of this word when the player touches it for the first time
    // This is so they can track which words they have touched
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!touched) {
            MainCharacter player = collision.gameObject.GetComponent<MainCharacter>();
            if (player) {
                touched = true;
                Text text = GetComponent<Text>();
                text.color *= 0.8f;
            }
        }
    }

    // Getter function for if this word has been touched
    public bool HasBeenTouched()
    {
        return touched;
    }

    public void BlastIt(Vector3 source, float strength) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce((transform.position - source).normalized * strength);

    }

}

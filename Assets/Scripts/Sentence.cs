using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sentence : MonoBehaviour
{
    public string sentence;
    public float maxHeightDifference = 3.0f;
    public float maxJumpRange = 3.0f;
    public GameObject word; // Prefab word
    private GameObject[] wordObjects;
    private float horizontalDistance = 0.0f;
    private float verticalDistance = 0.0f;
    private bool wecare = true;

    // Start is called before the first frame update
    // Take the sentence we have, split it up, and make individual word blocks
    // Decide on a colour for the words based on who we think is speaking in 
    // the current sentence
    // Place the blocks randomly-ish
    // Keep track of how far along we are
    void Awake()
    {
        horizontalDistance = 0.0f;
        string[] words = sentence.Split(' ');
        int startIndex = 0;
        Color textColor;
        if (words[0].Contains(":")) {
            textColor = Sentence.GetColor(words[0].Replace(":", ""));
            startIndex = 1;
            wordObjects = new GameObject[words.Length-1];
        } else {
            textColor = Sentence.GetColor("");
            wordObjects = new GameObject[words.Length];
        }
        for (int i = 0; i < wordObjects.Length; ++i) {
            word.GetComponent<Word>().word = words[i+startIndex];
            word.GetComponent<Text>().color = textColor;
            wordObjects[i] = GameObject.Instantiate(word, gameObject.transform);
            float width = wordObjects[i].GetComponent<Text>().preferredWidth;
            horizontalDistance += (width / 2) / 100;
            float heightChange = maxHeightDifference / 2.0f;
            verticalDistance = Random.Range(i*heightChange, i* heightChange + heightChange);
            wordObjects[i].GetComponent<RectTransform>().localPosition = new Vector3(horizontalDistance, verticalDistance);
            horizontalDistance += (width / 2) / 100 + Random.Range(0.6f, maxJumpRange);
            //Debug.Log("Horizontal Distance is now " + horizontalDistance);
        }
    }

    // Update is called once per frame
    // Declare when all our words have been touched
    void Update()
    {
        if (AllTouched() && wecare) {
            Debug.Log("All Words have been touched completely for '" + sentence + "'");
            wecare = false;
        }
    }

    // Kind of a dictionary of names to colours, this is really bad practice
    private static Color GetColor(string speaker)
    {
        Debug.Log("Speaker is " + speaker);
        switch (speaker) {
            case "":
                return Color.black;
            case "ME":
                return new Color(238.0f/255.0f, 130.0f/255.0f, 238.0f/255.0f); // Violet
            case "Knight":
                return Color.red;
            default:
                return new Color(40.0f / 255.0f, 40.0f / 255.0f, 40.0f / 255.0f); //Greyish
        }
    }

    // Calculate what the maximum height of this sentence could be, if the lowest 
    // value was chosen at the final interval
    // I don't know why it's divided by 2.0f!
    public float LowestMaxHeight()
    {
        return verticalDistance;
    }

    // Getter function for horizontalDistance
    public float HorizontalDistance()
    {
        return horizontalDistance;
    }

    // Tells you whether all the words have been touched
    public bool AllTouched()
    {
        bool touched = true;
        for (int i=0; i < wordObjects.Length; ++i) {
            touched &= wordObjects[i].GetComponent<Word>().HasBeenTouched();
        }
        return touched;
    }
}

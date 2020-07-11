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

    // Start is called before the first frame update
    void Awake()
    {
        horizontalDistance = 0.0f;
        string[] words = sentence.Split(' ');
        wordObjects = new GameObject[words.Length];
        int startIndex = 0;
        Color textColor;
        if (words[0].Contains(":")) {
            textColor = Sentence.GetColor(words[0].Replace(":", ""));
            startIndex = 1;
        } else {
            textColor = Sentence.GetColor("");
        }
        for (int i = startIndex; i < words.Length; ++i) {
            word.GetComponent<Word>().word = words[i];
            word.GetComponent<Text>().color = textColor;
            wordObjects[i] = GameObject.Instantiate(word, gameObject.transform);
            float width = wordObjects[i].GetComponent<Text>().preferredWidth;
            horizontalDistance += (width / 2) / 100;
            float heightChange = maxHeightDifference / 2.0f;
            float y = Random.Range(i*heightChange, i* heightChange + heightChange);
            wordObjects[i].GetComponent<RectTransform>().localPosition = new Vector3(horizontalDistance, y);
            horizontalDistance += (width / 2) / 100 + Random.Range(0.6f, maxJumpRange);
            Debug.Log("Horizontal Distance is now " + horizontalDistance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static Color GetColor(string speaker)
    {
        Debug.Log("Speaker is " + speaker);
        switch (speaker) {
            case "":
                return Color.black;
            case "ME":
                return new Color(238/255, 130/255, 238/255); // Violet, comes out white for some reason
            case "Knight":
                return Color.red;
            default:
                return new Color(40/255, 40/255, 40/255); //Greyish
        }
    }

    public float LowestMaxHeight()
    {
        return wordObjects.Length * maxHeightDifference/2.0f;
    }

    public float HorizontalDistance()
    {
        return horizontalDistance;
    }
}

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

    // Start is called before the first frame update
    void Start()
    {
        float x = 0;
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; ++i) {
            word.GetComponent<Word>().word = words[i];
            GameObject go = GameObject.Instantiate(word, gameObject.transform);
            float width = go.GetComponent<Text>().preferredWidth;
            x += (width / 2) / 100;
            float heightChange = maxHeightDifference / 2.0f;
            float y = Random.Range(i*heightChange, i* heightChange + heightChange);
            go.GetComponent<RectTransform>().localPosition = new Vector3(x, y);
            x += (width / 2) / 100 + Random.Range(0.6f, maxJumpRange);
            Debug.Log("x is now " + x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

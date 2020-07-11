using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset dialogue;
    public GameObject sentence;
    private GameObject[] sentences;
    private float height = 0.0f;
    private float width = 0.0f;
    private bool wecare = true;

    // When the Dialogue Object first gets created when I hit play
    // It creates the sentences from the dialogue text file
    void Awake()
    {
        Debug.Log(dialogue.name);
        string[] lines = dialogue.text.Split('\n');
        for (int i = 0; i < lines.Length; ++i) {
            Debug.Log(lines[i]);
        }
        sentences = new GameObject[lines.Length];
        for (int i = 0; i < lines.Length; ++i) {
            sentence.GetComponent<Sentence>().sentence = lines[i];
            sentences[i] = GameObject.Instantiate(sentence, gameObject.transform);
            sentences[i].transform.position += new Vector3(width, height);
            Sentence currentSentence = sentences[i].GetComponent<Sentence>();
            height += currentSentence.LowestMaxHeight();
            width += currentSentence.HorizontalDistance();
            Debug.Log("New Height " + height + ", New Width " + width);
        }
    }

    // Update is called once per frame
    // Checks whether everything has been touched so we can notify (atm)
    void Update()
    {
        if (AllTouched() && wecare) {
            Debug.Log("All Sentences have been touched completely");
            wecare = false;
        }
    }

    // Provides the worst case endpoint for the sequence of sentences in the dialogue
    public Vector3 EndPoint()
    {
        return new Vector3(width, height);
    }

    // Checks all the sentences, to see whether all of their words have been landed on
    public bool AllTouched()
    {
        bool touched = true;
        for (int i = 0; i < sentences.Length; ++i) {
            touched &= sentences[i].GetComponent<Sentence>().AllTouched();
        }
        return touched;
    }
}

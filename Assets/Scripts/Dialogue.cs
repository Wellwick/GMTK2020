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

    // Start is called before the first frame update
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
    void Update()
    {
        
    }

    public bool AllTouched()
    {
        bool touched = true;
        for (int i = 0; i < sentences.Length; ++i) {
            touched &= sentences[i].GetComponent<Sentence>().AllTouched();
        }
        return touched;
    }
}

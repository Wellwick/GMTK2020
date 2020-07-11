using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset dialogue;
    public Sentence sentence;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(dialogue.name);
        string[] lines = dialogue.text.Split('\n');
        for (int i = 0; i < lines.Length; ++i) {
            Debug.Log(lines[i]);
        }
        sentence.sentence = lines[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

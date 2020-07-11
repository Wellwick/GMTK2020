using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset dialogue;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dialogue.name);
        string[] lines = DialogueImporter.ReadFile("Assets/Dialogue/"+dialogue.name+".txt");
        for (int i = 0; i < lines.Length; ++i) {
            Debug.Log(lines[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

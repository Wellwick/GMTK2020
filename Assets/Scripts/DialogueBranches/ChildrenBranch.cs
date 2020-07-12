using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenBranch : DialogueChoice
{
    public Dialogue pastDialogue;
    public GameObject wordPrefab;
    public GameObject towerPrefab;
    public GameObject glassPrefab;
    private bool anyTouched = false;

    private void Start()
    {
        choices = new Word[2];
        Vector3 startPoint = pastDialogue.EndPoint();
        DialogueChoice dc = new DialogueChoice();
        wordPrefab.GetComponent<Word>().word = "Yes!";
        choices[0] = GameObject.Instantiate(wordPrefab, transform).GetComponent<Word>();
        wordPrefab.GetComponent<Word>().word = "No!";
        choices[1] = GameObject.Instantiate(wordPrefab, transform).GetComponent<Word>();
        choices[0].transform.position = startPoint + new Vector3(2.0f, 1.5f);
        choices[1].transform.position = startPoint + new Vector3(2.0f, 0.0f);
        transform.position = pastDialogue.transform.position;
    }

    // This function must use if statements!
    private void Update()
    {
        if (true) {
            base.Update();
        }
        if (!anyTouched) {
            if (choices[0].HasBeenTouched()) {
                anyTouched = true;
                //Load extra dialogue, TODO
            }
            if (choices[1].HasBeenTouched()) {
                anyTouched = true;
                //Load a tower!
                Vector3 startPos = choices[1].transform.position;
                startPos.y += 2.0f;
                GameObject tower = GameObject.Instantiate(towerPrefab);
                tower.transform.position = startPos;
                GameObject glass = GameObject.Instantiate(glassPrefab);
                glass.transform.position = startPos + new Vector3(0.0f, tower.GetComponent<Tower>().height + 2.0f);
            }
        }
    }
}

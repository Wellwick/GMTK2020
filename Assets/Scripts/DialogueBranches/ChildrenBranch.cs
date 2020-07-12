using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildrenBranch : DialogueChoice
{
    public Dialogue pastDialogue;
    public GameObject wordPrefab;
    public GameObject towerPrefab;
    public GameObject glassPrefab;
    public GameObject choice1;
    public GameObject choice2;
    private bool anyTouched = false;

    private void Start()
    {
        choices = new Word[2];
        Vector3 startPoint = pastDialogue.EndPoint();
        DialogueChoice dc = new DialogueChoice();
        wordPrefab.GetComponent<Word>().word = "Who are you?";
        choices[0] = GameObject.Instantiate(wordPrefab, transform).GetComponent<Word>();
        wordPrefab.GetComponent<Word>().word = "How did I get here?";
        choices[1] = GameObject.Instantiate(wordPrefab, transform).GetComponent<Word>();
        choices[0].transform.position = startPoint + new Vector3(2.0f, 3.5f);
        choices[0].GetComponent<Text>().color = new Color(0.2f, 0.6f, 0.2f);
        choices[1].transform.position = startPoint + new Vector3(4.5f, -1.0f);
        choices[1].GetComponent<Text>().color = new Color(0.2f, 0.6f, 0.2f);
        transform.position = pastDialogue.transform.position;
    }

    // This function must use if statements!
    private void Update()
    {
        if (true) {
            base.Update();
        }
        if (!anyTouched) {
            Vector3 spawnTowerPos = new Vector3();
            if (choices[0].HasBeenTouched()) {
                anyTouched = true;
                choice1.transform.position = choices[0].transform.position + new Vector3(2.0f, 2.0f);
                spawnTowerPos = choice1.GetComponent<Dialogue>().EndPoint() + choice1.transform.position + new Vector3(-3.0f, 3.0f);
            }
            if (choices[1].HasBeenTouched()) {
                anyTouched = true;
                choice2.transform.position = choices[0].transform.position + new Vector3(2.0f, 2.0f);
                spawnTowerPos = choice2.GetComponent<Dialogue>().EndPoint() + choice2.transform.position + new Vector3(-1.0f, 1.0f);
            }
            if (anyTouched) {
                GameObject tower = GameObject.Instantiate(towerPrefab);
                tower.transform.position = spawnTowerPos;
                GameObject glass = GameObject.Instantiate(glassPrefab);
                glass.transform.position = spawnTowerPos + new Vector3(0.0f, tower.GetComponent<Tower>().height + 4.0f);
            }
        }
    }
}

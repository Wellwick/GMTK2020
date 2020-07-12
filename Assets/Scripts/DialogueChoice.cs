using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    public Word[] choices;
    public float blastPower;
    private Word chosen;

    // Update is called once per frame
    protected void Update()
    {
        if (!chosen) {
            foreach (Word word in choices) {
                if (word.HasBeenTouched()) {
                    chosen = word;
                    break;
                }
            }
            if (chosen) {
                foreach (Word word in choices) {
                    if (chosen == word) {
                        continue;
                    }
                    Rigidbody2D rb = word.gameObject.GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.AddTorque(blastPower);
                    Vector3 direction = word.gameObject.transform.position - chosen.gameObject.transform.position;
                    rb.AddForce(direction.normalized * blastPower);
                    word.GetComponent<GeneralPlatform>().SetGrappleable(false);
                }
            }
        }
    }
}

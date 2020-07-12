using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float width;
    public float height;
    public float minPlatformDistance;
    public float maxPlatformDistance;
    public GameObject platformPrefab;
    public GameObject wallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject leftWall = GameObject.Instantiate(wallPrefab, transform);
        leftWall.transform.position = new Vector3(-width / 2, height/2);
        leftWall.transform.localScale = new Vector3(10.0f, height * 5);
        GameObject rightWall = GameObject.Instantiate(wallPrefab, transform);
        rightWall.transform.position = new Vector3(width / 2, height/2);
        rightWall.transform.localScale = new Vector3(10.0f, height * 5);

        Vector3 lastPlatform = new Vector3();
        float safetyWidth = 
            width - platformPrefab.GetComponent<BoxCollider2D>().size.x - 
            wallPrefab.GetComponent<BoxCollider2D>().size.x * wallPrefab.transform.localScale.x;
        float yPos = 0.0f;
        while (yPos < height) {
            float dist = Random.RandomRange(minPlatformDistance, maxPlatformDistance);
            float leftAngle = Mathf.PI/6;
            float rightAngle = leftAngle*5;
            float defaultAngleMultiplier = Mathf.Cos(leftAngle);
            if (lastPlatform.x - (defaultAngleMultiplier * dist) < -safetyWidth/2) {
                leftAngle = Mathf.Acos((safetyWidth/2+lastPlatform.x)/dist);
            }
            if (lastPlatform.x + (defaultAngleMultiplier * dist) > safetyWidth/2) {
                rightAngle = Mathf.PI - Mathf.Acos((safetyWidth/2-lastPlatform.x)/dist);
            }
            float angle = Random.RandomRange(leftAngle, rightAngle);
            float xPos = lastPlatform.x - (Mathf.Cos(angle) * dist);
            yPos = Mathf.Sin(angle)*dist + lastPlatform.y;
            GameObject platform = GameObject.Instantiate(platformPrefab, transform);
            lastPlatform = new Vector3(xPos, yPos);
            //Debug.Log("Made new platform at " + lastPlatform);
            platform.transform.position = lastPlatform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        leftWall.transform.position = new Vector3(-width / 2, 0.0f);
        GameObject rightWall = GameObject.Instantiate(wallPrefab, transform);
        rightWall.transform.position = new Vector3(width / 2, 0.0f);
        Vector3 lastPlatform = new Vector3();
        float safetyWidth = width - platformPrefab.GetComponent<BoxCollider2D>().size.x;
        float yPos = 0.0f;
        while (yPos < height) {
            float dist = Random.RandomRange(minPlatformDistance, maxPlatformDistance);
            float leftAngle = Mathf.Deg2Rad*-60.0f;
            float rightAngle = Mathf.Deg2Rad*60.0f;
            if (lastPlatform.x + dist > safetyWidth/2) {
                leftAngle = Mathf.Acos((safetyWidth-lastPlatform.x)/dist);
            }
            //float angle = Random.RandomRange();
            //yPos += Mathf.Sqrt(dist * dist - xDiff * xDiff);
            //GameObject platform = GameObject.Instantiate(platformPrefab, transform);
            //lastPlatform = new Vector3(xPos, yPos);
            //platform.transform.position = lastPlatform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

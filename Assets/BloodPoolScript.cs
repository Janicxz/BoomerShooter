using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
    Vector3 beginTransform, endTransform;
    public GameObject bloodPool;
    float timeElapsed;
    float lerpDuration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        beginTransform = new Vector3(0.01f, 0.1f, 0.1f);
        endTransform = new Vector3(0.01f, Random.Range(0.8f,2f), Random.Range(0.8f, 2f));

    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed <= lerpDuration)
        {
            bloodPool.transform.localScale = Vector3.Lerp(beginTransform, endTransform, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            this.enabled = false;
        }
    }
}

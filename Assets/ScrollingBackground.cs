using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float speed; //scroll speed for background
    public float clamppos; // clamping position
    public Vector3 StartingPositioon; // get background start pos
    // Start is called before the first frame update
    void Start()
    {
        StartingPositioon = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newPos = Mathf.Repeat(Time.time * speed, clamppos);
        transform.position = StartingPositioon + -Vector3.up * newPos;
    }
}

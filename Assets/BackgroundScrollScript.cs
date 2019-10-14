using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newZ = Mathf.Repeat(Time.time * speed, 100);
        transform.position = startPosition + Vector3.back * newZ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    // Start is called before the first frame update
    public float degreesPerSecond = 0f;
    private float amplitude = +1.3f;
    public float frequency = 1f;
    public bool rotate = true;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 originalPos = new Vector3();
    Vector3 tempPos = new Vector3();
    

    // Use this for initialization
    void Start()
    {
        // Store the starting position of the object
        posOffset = transform.localPosition;
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 startPos = new Vector3();
        if (rotate)
        {
            startPos = transform.localPosition;
            // Float up/down with a Sin()
            tempPos = posOffset;
            ////tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            tempPos.y += Mathf.PingPong(Time.time * frequency, amplitude);

            transform.localPosition = tempPos;
            

        }
        if (startPos != null && !rotate)
        {
            transform.localPosition = startPos;
        }
       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarPared : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

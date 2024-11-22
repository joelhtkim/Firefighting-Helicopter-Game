using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterjet : MonoBehaviour
{
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(0, 0, -10f);
        body.velocity += vec;
    }

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log(collision);
        Destroy(body);
    }
}

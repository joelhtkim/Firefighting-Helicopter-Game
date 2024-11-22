using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fix throttle controlls and add drag

// Controls:
// w/s - pitch
// a/d - roll
// q/e - yaw
// space - thrust

public class PlayerController : MonoBehaviour
{
    public GameObject WaterPrefab;

    public float maxRollAngle = 45f;
    public float maxPitchAngle = 45f;
    public float rollSpeed = 5f;
    public float pitchSpeed = 5f;
    public float yawSpeed = 5f;
    public float maxThrottle = 5f;
    public float throttleSpeed = 1f;
    public float rotationDamping = 2f;

    public float PitchRange = 90f;
    public float RollRange = 90f;

    public float currentThrottle = 0f;
    private Rigidbody rb;

    public float roll;
    public float pitch;
    public float yaw;

    public Transform rotorT;
    public Transform backRotorT;


    private float firecap = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 5f; // Limit the maximum angular velocity
    }

    void Update()
    {
        HandleInputs();

        rotorT.Rotate(Vector3.up * currentThrottle);
        backRotorT.Rotate(Vector3.right * roll);
    }

    private void FixedUpdate()
    {
        // CHANGE TO DIFFERENT?
        float modpitch = Input.GetAxis("Pitch") * PitchRange;
        float modroll = -Input.GetAxis("Roll") * RollRange;

        roll = Mathf.Lerp(roll, modroll, 0.01f);
        pitch = Mathf.Lerp(pitch, modpitch, 0.01f);
        yaw -= roll * 5f * Time.fixedDeltaTime;


        Quaternion Rot = Quaternion.Euler(pitch, yaw, roll);

        rb.MoveRotation(Rot);


        rb.AddForce(transform.up * currentThrottle, ForceMode.Impulse);

        if (firecap >= 3)
        {
            MaybeFire();
            firecap = 0;
        } else
        {
            firecap = firecap + 1;
        }
    }

    void MaybeFire()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
                FireWater();
        }
    }

    private void FireWater()
    {
        Vector3 spawnPosn = transform.position + transform.forward;

        GameObject jet = Instantiate(WaterPrefab, spawnPosn, Quaternion.identity);

        Rigidbody jetRigidbody = jet.GetComponent<Rigidbody>();
        jetRigidbody.velocity = transform.forward * 60f;
    }


    private void HandleInputs()
    {
        // Get input values

        // Throttle control
        if (Input.GetKey(KeyCode.Space))
        {
            currentThrottle += throttleSpeed * Time.deltaTime;
        }
        else
        {
            currentThrottle = 0;
        }

        currentThrottle = Mathf.Clamp(currentThrottle, 0f, maxThrottle);
    }
}

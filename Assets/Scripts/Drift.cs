using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    private Vector3 MoveForce;

    public float moveSpeed = 50;
    public float maxSpeed = 15;
    public float Drag = 0.98f;
    public float steerAngle = 20;
    public float Traction = 1;

    // Update is called once per frame
    void Update()
    {
        MoveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, maxSpeed);

        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float runningSpeed;
    public float walkingSpeed;
    public float rotateSpeed;

    private Vector3 m_Direction;
    private bool m_IsRunning;

    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        m_Direction = direction;
    }

    public void SetRunMode(bool isRunning)
    {
        m_IsRunning = isRunning;
    }

    private void FixedUpdate()
    {
        if (m_Direction.magnitude >= 0.01f)
        {
            UpdatePosition();
            UpdateRotation();
        }
    }

    private void UpdatePosition()
    {
        float moveSpeed = m_IsRunning ? runningSpeed : walkingSpeed;
        Vector3 nextPosition = transform.position + (m_Direction * moveSpeed * Time.fixedDeltaTime);
        m_Rigidbody.MovePosition(nextPosition);
    }

    private void UpdateRotation()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(m_Direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotateSpeed * Time.fixedDeltaTime);
    }
}

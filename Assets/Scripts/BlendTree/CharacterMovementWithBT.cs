using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementWithBT : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private Vector3 m_Direction;

    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        m_Direction = direction;
    }

    private void FixedUpdate()
    {
        if (m_Direction.magnitude >= 0.01f)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        Vector3 nextPosition = transform.position + (m_Direction * moveSpeed * Time.fixedDeltaTime);
        m_Rigidbody.MovePosition(nextPosition);
    }
}

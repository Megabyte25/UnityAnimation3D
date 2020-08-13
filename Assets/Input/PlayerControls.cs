using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// PlayerControls class is an abstraction layer that reads the user input
// and informs the player controller what is happening
public class PlayerControls : MonoBehaviour
{
    private Controls m_Controls;

    private PlayerControllerWithBT m_PlayerController;
    void Awake()
    {
        m_Controls = new Controls();
        m_PlayerController = GetComponent<PlayerControllerWithBT>();

        // Action Type: Action Asset
        m_Controls.Player.Jump.performed += OnJump;
        m_Controls.Player.Run.started += OnRunStarted;   // Run key or button is pressed
        m_Controls.Player.Run.canceled += OnRunCanceled; // Run key or button is released
    }

    void OnEnable()
    {
        m_Controls.Enable();
    }

    void OnDisable()
    {
        m_Controls.Disable();
    }
    
    void Update()
    {
        // Action Type: Value
        Vector2 inputDirection = m_Controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        // Set the direction vector in player controller
        m_PlayerController.Move(direction);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_PlayerController.Jump();
    }

    private void OnRunStarted(InputAction.CallbackContext context)
    {
        m_PlayerController.SetRun(true);
    }

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        m_PlayerController.SetRun(false);
    }
}

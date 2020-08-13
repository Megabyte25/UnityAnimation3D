using UnityEngine;

// The PlayerController class gets input from the PlayerControls
// and communicates that information to the animator to drive animations
// and to CharacterMovement to move the character model
public class PlayerControllerWithBT : MonoBehaviour
{
    private Animator animator;
    private CharacterMovementWithBT charMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        charMovement = GetComponent<CharacterMovementWithBT>();
    }

    public void Move(Vector3 direction)
    {
        animator.SetFloat("blendX", direction.x);
        animator.SetFloat("blendY", direction.z);

        charMovement.SetMoveDirection(direction);
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }

    public void SetRun(bool running)
    {
        // No longer relevant for Blend Tree
        //animator.SetBool("isRunMode", running);
        //charMovement.SetRunMode(running);
    }
}

using UnityEngine;

// The PlayerController class gets input from the PlayerControls
// and communicates that information to the animator to drive animations
// and to CharacterMovement to move the character model
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement charMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        charMovement = GetComponent<CharacterMovement>();
    }

    public void Move(Vector3 direction)
    {
        bool isMoving = direction.magnitude > 0.01f;
        animator.SetBool("isMoving", isMoving);

        charMovement.SetMoveDirection(direction);
    }

    public void Jump()
    {
        animator.SetTrigger("jump");

    }

    public void SetRun(bool running)
    {
        animator.SetBool("isRunMode", running);
        charMovement.SetRunMode(running);
    }
}

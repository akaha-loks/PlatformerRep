using UnityEngine;

[RequireComponent(typeof(MovementPlayer))]

public class InputPlayer : MonoBehaviour
{
    private MovementPlayer playerMovement;
    private Animator anim;

    private void Awake()
    {
        playerMovement = GetComponent<MovementPlayer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}

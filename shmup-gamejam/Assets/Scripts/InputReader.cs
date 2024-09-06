using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        //NOTE: MAKE SURE TO SET PLAYER INPUT COMPONENT TO C# EVENTS
        PlayerInput playerInput;
        InputAction moveAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }
    }
}
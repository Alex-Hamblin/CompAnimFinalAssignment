using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls controls;

    public static void Init(Player player)
    {
        controls = new Controls();

        controls.Walking.Enable();
        controls.Walking.Movement.performed += _ =>
        {
            player.SetMoveDirection(_.ReadValue<Vector3>());
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    private float _horizontalValue = 0;

    void FixedUpdate()
    {
        _horizontalValue = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _horizontalValue = Input.GetAxis("Horizontal");
            _player.Movement.Move(new Vector2(_horizontalValue, 0));
        }

        _player.Anim.SetBool("Move", _horizontalValue != 0);

        if (Input.GetMouseButton(0))
            _player.Attack.TryShoot();
    }
}

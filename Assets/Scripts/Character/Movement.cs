using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed = 10f;

    public void Move(Vector2 direction)
    {
        _rb.MovePosition(_rb.position + direction.normalized * _speed * Time.fixedDeltaTime);

        Flip(direction.x);
    }

    private void Flip(float horizontalValue)
    {
        if (horizontalValue > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}

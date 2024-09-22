using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth _health;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyAttack _attack;

    private void FixedUpdate()
    {
        if (Vector2.Distance(Player.Instance.transform.position, transform.position) > 1f)
            _movement.Move(Player.Instance.transform.position - transform.position);
    }
}

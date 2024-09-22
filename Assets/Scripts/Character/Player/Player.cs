using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player Instance { get; private set; }

    public Movement Movement;
    public Health Health;
    public Animator Anim;
    public PlayerInventory Inventory;
    public PlayerAttack Attack;

    public void Init()
    {
        Instance = this;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Drop")
        {
            if (collision.gameObject.TryGetComponent(out Drop drop))
            {
                Inventory.AddBullets(drop.GetValue());
                drop.Collect();
            }
        }
    }
}

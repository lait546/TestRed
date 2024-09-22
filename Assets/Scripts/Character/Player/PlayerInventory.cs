using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action<int> OnChangeCountBullets;
    public event Action OnOutAmmo;

    [SerializeField] private int _startCountBullets;
    
    public int GetCountBullets() => _startCountBullets;

    public void Start()
    {
        OnChangeCountBullets?.Invoke(_startCountBullets);
    }

    public void RemoveBullet()
    {
        if (_startCountBullets > 0)
        {
            _startCountBullets--;
            OnChangeCountBullets(_startCountBullets);

            if (_startCountBullets <= 0)
                OnOutAmmo?.Invoke();
        }
    }

    public void AddBullets(int value)
    {
        _startCountBullets += value;
        OnChangeCountBullets(_startCountBullets);
    }
}

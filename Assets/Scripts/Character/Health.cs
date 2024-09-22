using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDied;
    [SerializeField] protected float _maxHealth = 100;
    [SerializeField] protected AudioClip _audioClip;
    [SerializeField] protected AudioSource _audioSource;
    protected float _curHealth;

    public void Awake()
    {
        _curHealth = _maxHealth;
    }

    public virtual void GetDamage(float value)
    {
        _audioSource.PlayOneShot(_audioClip);
        OnDied?.Invoke();
    }

    public float GetHP()
    {
        return _curHealth;
    }
}

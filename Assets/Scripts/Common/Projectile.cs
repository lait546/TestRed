using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject
{
    [SerializeField] private float _speed = 25, _time = 2f, _damage = 20f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    private Vector2 _dir;

    public ObjectPooler.ObjectInfo.ObjectType Type { get; } = ObjectPooler.ObjectInfo.ObjectType.Bullet;

    public void FixedUpdate()
    {
        Move();
    }

    public void SetDir(Vector2 dir)
    {
        _dir = dir;
        transform.localScale = new Vector3(MathF.Sign(dir.x) * MathF.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        ObjectPooler.Instance.DestroyObject(gameObject, _time);
    }

    public void Move()
    {
        _rb.transform.Translate(_dir.normalized * _speed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.TryGetComponent(out Health enemy))
            {
                enemy.GetDamage(_damage);
                GameAssets.Instance.CreateAudioPref(_audioClip, transform.position);
                ObjectPooler.Instance.DestroyObject(gameObject);
            }
        }
    }
}

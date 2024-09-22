using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _pointProj;
    [SerializeField] private float _attackDelay;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    private float _lastTime;

    public void TryShoot()
    {
        if (_player.Inventory.GetCountBullets() > 0)
        {
            if ((_lastTime += Time.deltaTime) > _attackDelay)
            {
                GameObject go = ObjectPooler.Instance.GetObject(ObjectPooler.ObjectInfo.ObjectType.Bullet);
                Projectile proj = go.GetComponent<Projectile>();

                proj.transform.position = _pointProj.position;
                proj.transform.TransformDirection(new Vector3(Mathf.Sign(transform.localScale.x), 0, 0));
                proj.SetDir(new Vector3(Mathf.Sign(transform.localScale.x), 0, 0));

                _player.Inventory.RemoveBullet();
                _lastTime = 0;

                _player.Anim.SetTrigger("Shoot");
                _audioSource.PlayOneShot(_audioClip);
            }
        }
    }
}

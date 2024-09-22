using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public HealthUI _hpPanel;

    public override void GetDamage(float value)
    {
        _curHealth -= value;
        _hpPanel.SetProgress(_curHealth, _maxHealth);

        if (_curHealth <= 0)
        {
            GameAssets.Instance.CreateAudioPref(_audioClip, transform.position);
            Instantiate(GameAssets.Instance.Bullets, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

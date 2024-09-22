using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private AudioClip _audioClip;

    public int GetValue()
    {
        return _value;
    }

    public void Collect()
    {
        GameAssets.Instance.CreateAudioPref(_audioClip, transform.position);
        Destroy(gameObject);
    }
}

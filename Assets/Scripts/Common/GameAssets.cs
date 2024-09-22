using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets Instance
    {
        get {
            if (_instance == null) _instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _instance; 
        } 
    }

    public void Awake()
    {
        InitObjectPooler();
    }

    public ObjectPooler ObjectPoolerPref;
    public Projectile BulletPref;
    public AudioSource AudioPref;
    public Drop Bullets;

    private ObjectPooler _pooler;

    public void InitObjectPooler()
    {
        if (_pooler == null)
        {
            _pooler = Instantiate(ObjectPoolerPref);

            _pooler.objectsInfo.Add(new ObjectPooler.ObjectInfo(ObjectPooler.ObjectInfo.ObjectType.Bullet, BulletPref.gameObject, 30));

            _pooler.Init();
        }
    }

    public void CreateAudioPref(AudioClip audioClip, Vector2 pos)
    {
        AudioSource audioSource = Instantiate(AudioPref, pos, Quaternion.identity);
        audioSource.PlayOneShot(audioClip);
        Destroy(audioSource.gameObject, audioClip.length);
    }
}

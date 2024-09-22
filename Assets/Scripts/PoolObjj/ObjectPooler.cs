using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [System.Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        { 
            Bullet
        }

        public ObjectType Type;
        public GameObject Prefab;
        public int StartCount;

        public ObjectInfo(ObjectType _type, GameObject _prefab, int _startCount)
        {
            Type = _type;
            Prefab = _prefab;
            StartCount = _startCount;
        }
    }

    public List<ObjectInfo> objectsInfo = new List<ObjectInfo>();
    private Dictionary<ObjectInfo.ObjectType, Pool> pools;

    // Start is called before the first frame update
    public void Init()
    {
        if (Instance == null)
            Instance = this;

        InitPool();
    }

    // Update is called once per frame
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

        var emptyGO = new GameObject();

        foreach(var obj in objectsInfo)
        {
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.Type.ToString();

            pools[obj.Type] = new Pool(container.transform);

            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObject(obj.Type, container.transform);
                pools[obj.Type].Objects.Enqueue(go);
            }
        }

        Destroy(emptyGO);
    }

    private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
    {
        var go = Instantiate(objectsInfo.Find(x => x.Type == type).Prefab, parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);

        return obj;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type, Vector3 pos, Quaternion rotation)
    {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);
        obj.transform.position = pos;
        obj.transform.rotation = rotation;

        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }

    public void DestroyObject(GameObject obj, float time)
    {
        StartCoroutine(IDestroyObject(obj, time));

    }

    private IEnumerator IDestroyObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }
}

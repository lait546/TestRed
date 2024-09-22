using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private Enemy _enemy1, _enemy2, _enemy3, _enemy4, _enemy5;

    public static Enemy Get(EnemyType type, Vector3 pos)
    {
        Enemy enemy = Instantiate(GetPrefabByType(type), pos, Quaternion.identity);
        return enemy;
    }

    private static Enemy GetPrefabByType(EnemyType type)
    {
        EnemyFactory factory = Resources.Load<EnemyFactory>("Enemies");
        Enemy enemy = factory._enemy1;

        switch (type)
        {
            case EnemyType.Enemy1:
                enemy = factory._enemy1;
                break;
            case EnemyType.Enemy2:
                enemy = factory._enemy2;
                break;
            case EnemyType.Enemy3:
                enemy = factory._enemy3;
                break;
            case EnemyType.Enemy4:
                enemy = factory._enemy4;
                break;
            case EnemyType.Enemy5:
                enemy = factory._enemy5;
                break;
        }
        return enemy;
    }
}

public enum EnemyType
{ 
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    Enemy5
}
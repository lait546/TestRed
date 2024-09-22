using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PanelInformation _panelInformation;

    //Главная точка входа приложения
    private void Awake()
    {
        _player.Init();
        _panelInformation.Init();
    }
}

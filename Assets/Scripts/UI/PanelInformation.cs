using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelInformation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Bullets;

    public void Init()
    {
        Player.Instance.Inventory.OnChangeCountBullets += SetBullets;
    }

    public void SetBullets(int bullets)
    {
        _Bullets.text = bullets.ToString();
    }

    public void OnDestroy()
    {
        Player.Instance.Inventory.OnChangeCountBullets -= SetBullets;
    }
}

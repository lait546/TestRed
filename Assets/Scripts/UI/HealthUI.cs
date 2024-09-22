using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _progress;
    public Canvas _c;

    public void SetProgress(float value, float maxValue)
    {
        _progress.fillAmount = value / maxValue;
    }
}

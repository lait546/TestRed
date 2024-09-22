using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Open();
        }
    }

    public void Open()
    {
        _window.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        _window.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

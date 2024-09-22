using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    void Start()
    {
        Player.Instance.Health.OnDied += EndGame;
        Player.Instance.Inventory.OnOutAmmo += EndGame;
    }

    public void OnDestroy()
    {
        Player.Instance.Health.OnDied -= EndGame;
        Player.Instance.Inventory.OnOutAmmo -= EndGame;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _window.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

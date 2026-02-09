using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject winPanel;
    public GameObject lossPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        winPanel.SetActive(false);
        lossPanel.SetActive(false);
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowLoss()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ← FIXED (SceneManager not SceneManagement)
    }
}
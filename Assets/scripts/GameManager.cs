using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //now using events for handling win/loss
    public delegate void GameEvent();
    public static event GameEvent OnWin;
    public static event GameEvent OnLoss;

    public GameObject winPanel;
    public GameObject lossPanel;

    public static void TriggerWin() => OnWin?.Invoke();
    public static void TriggerLoss() => OnLoss?.Invoke();

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

    //subscribe on start
    void OnEnable()
    {
        OnWin += ShowWin;
        OnLoss += ShowLoss;
    }

    //unsubscribe upon player death
    void OnDisable()
    {
        OnWin -= ShowWin;
        OnLoss -= ShowLoss;
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
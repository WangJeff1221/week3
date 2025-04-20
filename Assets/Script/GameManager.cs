using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverUI;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateCoinUI();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();

        if (coinCount == 15)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)  // Prevent NullReferenceException
        {
            coinText.text = "Coin: " + coinCount + "/15";
        }
        else
        {
            Debug.LogError("not assigned");
        }
    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("LossScene");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
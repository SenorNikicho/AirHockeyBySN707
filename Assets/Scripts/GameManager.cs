using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // если используешь TextMeshPro, иначе using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TMP_Text winnerText;   // или обычный Text
    public TMP_Text scoreRedText;
    public TMP_Text scoreBlueText;

    [Header("Settings")]
    public int maxScore = 7;

    private int scoreRed = 0;
    private int scoreBlue = 0;
    private bool gameEnded = false;

    private void Awake()
    {
        // Простейший синглтон для доступа из триггеров
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoalScored(string teamColor)
    {
        Debug.Log($"GoalScored вызван с teamColor = {teamColor}");

        if (gameEnded) return;

        if (teamColor == "Red")
            scoreRed++;
        else if (teamColor == "Blue")
            scoreBlue++;

        UpdateScoreUI();

        if (scoreRed >= maxScore)
            EndGame("Красные");
        else if (scoreBlue >= maxScore)
            EndGame("Синие");
        else
            ResetPuck();
        Debug.Log($"Счёт: Красные {scoreRed} - Синие {scoreBlue}"); // ← временный лог
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        Debug.Log($"UI: Красные {scoreRed}, Синие {scoreBlue}");
        scoreRedText.text = scoreRed.ToString();
        scoreBlueText.text = scoreBlue.ToString();
    }

    void EndGame(string winner)
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
        winnerText.text = $"{winner} победили!";
        Time.timeScale = 0f; // пауза
    }

    void ResetPuck()
    {
        GameObject puck = GameObject.FindGameObjectWithTag("Puck");
        if (puck != null)
        {
            Rigidbody rb = puck.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;   // вместо velocity
            rb.angularVelocity = Vector3.zero;  // осталось без изменений
            puck.transform.position = new Vector3(0, 0.2f, 0);
        }
    }

    // Вызывается кнопками UI
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
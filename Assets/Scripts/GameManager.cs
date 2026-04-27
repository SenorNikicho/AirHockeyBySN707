using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // если используешь TextMeshPro, иначе using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int dfg = 0;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TMP_Text winnerText;   // или обычный Text
    public TMP_Text scoreRedText;
    public TMP_Text scoreBlueText;
    public GameObject puck2;
    public GameObject PlayerB;
    public GameObject PlayerR;

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
        if (gameEnded) return;

        if (teamColor == "Red")
            scoreRed++;
        else if (teamColor == "Blue")
            scoreBlue++;

        UpdateScoreUI();
        Debug.Log($"Счёт: Красные {scoreRed} – Синие {scoreBlue}");

        if (scoreRed >= maxScore)
            EndGame("Красные");
        else if (scoreBlue >= maxScore)
            EndGame("Синие");
        else
            ResetPuck();
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

    public void ResetPuck()
    {
        if (puck2 != null)
        {
            Rigidbody rb = puck2.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            puck2.transform.position = new Vector3(0, 0.14f, 0);
        }
        if (PlayerB != null)
        {
            Rigidbody pb = PlayerB.GetComponent<Rigidbody>();
            pb.linearVelocity = Vector3.zero;
            pb.angularVelocity = Vector3.zero;
            PlayerB.transform.position = new Vector3(-5, 0.3f, 0);
        }
        if (PlayerR != null)
        {
            Rigidbody pr = PlayerR.GetComponent<Rigidbody>();
            pr.linearVelocity = Vector3.zero;
            pr.angularVelocity = Vector3.zero;
            PlayerR.transform.position = new Vector3(5, 0.3f, 0);
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
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public string teamColor = "Red"; // ← обязательно должно быть это поле!

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Что-то вошло в ворота {teamColor}: {other.name} (тег: {other.tag})");

        if (other.CompareTag("Puck"))
        {
            Debug.Log($"ГОЛ! Шайба в воротах {teamColor}");
            GameManager.Instance.GoalScored(teamColor);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"Симуляция гола в ворота {teamColor}");
            GameManager.Instance.GoalScored(teamColor);
        }
    }
}
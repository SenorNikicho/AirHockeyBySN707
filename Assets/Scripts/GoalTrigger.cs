using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public string teamColor = "Red";
    private bool goalScored = false;   // флаг, чтобы не засчитывать повторно

    private void OnTriggerEnter(Collider other)
    {
        // Реагируем только на шайбу, и только если гол ещё не был засчитан
        if (!goalScored && other.CompareTag("Puck"))
        {
            //goalScored = true;
            Debug.Log($"ГОЛ! Шайба в воротах {teamColor}");
            GameManager.Instance.GoalScored(teamColor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Когда шайба полностью покидает ворота, разрешаем засчитывать новый гол
        if (other.CompareTag("Puck"))
        {
            goalScored = false;
        }
    }
}
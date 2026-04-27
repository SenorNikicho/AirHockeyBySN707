using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.TextCore;

public class GoalTrigger : MonoBehaviour
{
    //public string teamColor = "Red"; // ← обязательно должно быть это поле!
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("RED_GATES"))
        {
            Debug.Log($"ГОЛ! Шайба в воротах red");
            GameManager.Instance.GoalScored("Red");
        }
        else if (other.CompareTag("BLUE_GATES"))
        {
            Debug.Log($"ГОЛ! Шайба в воротах blue");
            GameManager.Instance.GoalScored("Blue");
        }
        else
        {
            GameManager.Instance.dfg = 0;
        }
        
    }
}
/*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"Симуляция гола в ворота {teamColor}");
            GameManager.Instance.GoalScored(teamColor);
        }
    }
}
*/
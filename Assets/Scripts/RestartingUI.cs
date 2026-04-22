using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartGameUI : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
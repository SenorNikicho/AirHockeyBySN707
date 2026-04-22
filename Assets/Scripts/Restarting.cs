using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartGame : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
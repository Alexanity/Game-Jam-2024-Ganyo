using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject startSceneTransition;
    [SerializeField] private GameObject endSceneTransition;
    [SerializeField] private string SceneName;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            startSceneTransition.SetActive(true);
            Invoke("DisableStartingSceneTransition", 1.5f);

        }
    }
    private void DisableStartingSceneTransition()
    {
        startSceneTransition.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the start transition
            endSceneTransition.SetActive(true);
            Invoke("LoadNextScene", 1.5f);
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
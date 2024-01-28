using UnityEngine;

public class PersistentCanvasManager : MonoBehaviour
{
    // Singleton pattern
    private static PersistentCanvasManager instance;

    public static PersistentCanvasManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PersistentCanvasManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("PersistentCanvasManager");
                    instance = go.AddComponent<PersistentCanvasManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

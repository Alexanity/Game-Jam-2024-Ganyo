using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int points = 0;
    private PointsDisplay pointsDisplay;

    // Singleton pattern
    private static PointsManager instance;

    public static PointsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PointsManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("PointsManager");
                    instance = go.AddComponent<PointsManager>();
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

            // Create a child GameObject with PointsDisplay script
            GameObject pointsDisplayGO = new GameObject("PointsDisplay");
            pointsDisplay = pointsDisplayGO.AddComponent<PointsDisplay>();
            pointsDisplayGO.transform.SetParent(transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        if (pointsDisplay != null)
        {
            pointsDisplay.UpdatePoints(points);
        }
    }
}

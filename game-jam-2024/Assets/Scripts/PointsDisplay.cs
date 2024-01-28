using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour
{
    public Text pointsText;

    public void UpdatePoints(int points)
    {
        if (pointsText != null)
        {
            pointsText.text = points.ToString();
        }
    }
}

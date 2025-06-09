using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;

    public void IncrementScore()
    {
        score++;
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}

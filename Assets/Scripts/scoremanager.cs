using TMPro;
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] gamemanager gamer;
    int score = 0;
    public void incrementscore(int amount)
    {
        if (gamer.gameoverr) return;
        score += amount;
        text.text = score.ToString();
    }
    public void resetscore()
    {
        score = 0;
        text.text = score.ToString();
    }
}

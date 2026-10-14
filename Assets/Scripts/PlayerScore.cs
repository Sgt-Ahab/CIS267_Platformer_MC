using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //Attach to Game Manager
    //Drag Connection for GUIScore
    //When we get a collectable call this script to increment/set score
    private int playerScore;
    public TMP_Text guiScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = 0;
    }
    public int getScore()
    {
        return playerScore;
    }
    public void setPlayerScore(int val)
    {
        playerScore += val;
        setGUIPlayerScore();
    }
    public void setGUIPlayerScore()
    {
        guiScore.text = "Score: ";
        guiScore.text += playerScore.ToString();
    }
}

using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text finalScore;
    private PlayerScore playerScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = gameObject.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        Time.timeScale = 0f;
        showScore();
    }
    public void showScore()
    {
        //High score
        if(playerScore.getScore() > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", playerScore.getScore());
            Debug.Log("New Highscore saved");
        }
        finalScore.text = "Final Score: " + playerScore.getScore().ToString();
    }
}

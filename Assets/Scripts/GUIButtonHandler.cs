using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    //Make a reference to itself
    public GameObject menu;
    //Bools check if scene is loaded, and if game is paused
    private bool sceneLoaded = false;
    private bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        showPauseMenu();
    }
    public void loadGame()
    {
        //Need a way to ensure that this menu does not get destroyed between scene loads
        DontDestroyOnLoad(this.gameObject);
        //State scene is loaded
        sceneLoaded = true;
        menu.SetActive(false);
        //Load level one
        SceneManager.LoadScene("SampleScene");
    }   
    public void exitGame()
    {
        //This only works on a full build
        Application.Quit();
        //This is for the editor
        Debug.Log("Exit Application. . .");
    }   
    public void showPauseMenu()
    {
        //Check if user paused the game
        if(Input.GetKeyDown(KeyCode.P) && sceneLoaded)
        {
            if(!gamePaused)
            {
                menu.SetActive(true);
                //actually pause the game
                Time.timeScale = 0;
                gamePaused = true;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                gamePaused = false;
            }
        }
    }
}

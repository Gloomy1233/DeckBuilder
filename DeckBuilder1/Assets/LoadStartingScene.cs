using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartingScene : MonoBehaviour
{
    public Texture2D cursorTex;
    public void Start()
    {
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void DeckBuild()
    {
        SceneManager.LoadScene("DeckBuilder", LoadSceneMode.Additive);
      
    }
    public void About()
    {

        SceneManager.LoadScene("About", LoadSceneMode.Additive);
       

    }
    public void StartScreen()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Additive);
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void startgame()
    {
       
        SceneManager.LoadScene(1);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
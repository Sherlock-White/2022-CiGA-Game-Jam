using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript: MonoBehaviour
{
    public static void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public static void ToCredit()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public static void ToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

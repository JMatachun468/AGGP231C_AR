using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    public void Game1()
    {
        SceneManager.LoadScene(1);
    }

    public void Game2()
    {
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int Level;

    public void OnPress()
    {
        SceneManager.LoadScene(Level);
    }
}

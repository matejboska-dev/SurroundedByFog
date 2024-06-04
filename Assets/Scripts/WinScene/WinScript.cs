using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public AudioSource soundEffect; 

    void Start()
    {
        soundEffect.Play(); 
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

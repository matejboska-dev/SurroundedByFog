using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");   
        }

        
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}

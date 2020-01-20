using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Newgame : MonoBehaviour {
    SoundManager s;
    public void New()
    {
        PlayerPrefs.SetFloat("CamSize", 8);
        PlayerPrefs.SetInt("Deaths",0);
        PlayerPrefs.SetInt("RocketEnabled", 0);
        PlayerPrefs.SetInt("BombsEnabled", 0);
        PlayerPrefs.SetInt("GrappleEnabled", 0);
        PlayerPrefs.SetInt("TimestopEnabled", 0);
        PlayerPrefs.SetInt("TeleportEnabled", 1);
        PlayerPrefs.SetInt("Jumplim", 0);
        PlayerPrefs.SetFloat("Time", 0f);
        PlayerPrefs.SetString("Checkpoint", "CheckPoint(27)");
        PlayerPrefs.SetInt("Newgame", 1);
        PlayerPrefs.SetInt("Track", 0);
        SceneManager.LoadScene("Game Demo");
        PlayerPrefs.SetInt("Fresh", 1);
      

    }
    public void Continue() {
        if (PlayerPrefs.GetInt("Fresh") != 1)
        {
            New();
        }
        else
        {
            SceneManager.LoadScene("Game Demo");
          
        }
    }
    public void Quit(){
        Application.Quit();
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public AudioSource buttonSound;

    int Saved_scene;
    int Scene_index;

    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void new_game()
    {
        buttonSound.Play();
        SceneManager.LoadSceneAsync(1);
        Debug.Log("NEW GAME");
    }

    public void Load_Saved_Scene()
    {
        Saved_scene = PlayerPrefs.GetInt("Saved");

        if (Saved_scene != 0)
            SceneManager.LoadSceneAsync(Saved_scene);
        else
            return;
    }

    public void Save_and_Exit()
    {
        Debug.Log("GAME SAVED");
        Scene_index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved", Scene_index);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(0);
    }

    public void Next_Scene()
    {
        buttonSound.Play();
        Scene_index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(Scene_index);
    }

    //Switch Scene
    public void SwitchScene(string sceneName)
    {
        buttonSound.Play();
        SceneManager.LoadScene(sceneName);
        
    }

    public void QuitBtn()
    {
        buttonSound.Play();
        Debug.Log("Gumagana Quit");
        Application.Quit();
    } 

}

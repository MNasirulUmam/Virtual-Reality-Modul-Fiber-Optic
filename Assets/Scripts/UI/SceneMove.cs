using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public AudioSource ButtonSound;
    public string nameScene;

    public void MoveScene()
    {
        AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        buttonSound.PlayOneShot(buttonSound.clip);

        Scene sceneThis = SceneManager.GetActiveScene();
        if (sceneThis.name != nameScene)
        {
            SceneManager.LoadSceneAsync(nameScene);
        }
    }
}

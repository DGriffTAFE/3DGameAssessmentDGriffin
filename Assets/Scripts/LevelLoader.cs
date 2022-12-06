using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Takes Player input to switch to next scene. Which is in this case, switching from the main menu to the game level
        {
            LoadNextLevel(); //Subroutine which switches the scenes
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); //Uses the scene manger to switch from Main Menu (0 in the scene manager), to Level (1 in the scene manager)

    }

    IEnumerator LoadLevel(int LevelIndex) //Using a coroutine, delays the transitioning between scenes.
    {
        transition.SetTrigger("Start"); //Play animation

        yield return new WaitForSeconds(transitionTime); //Wait

        SceneManager.LoadScene(LevelIndex);//Load Scene
    }

}

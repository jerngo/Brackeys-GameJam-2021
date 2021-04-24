using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCont : MonoBehaviour
{


    public void gotoMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}

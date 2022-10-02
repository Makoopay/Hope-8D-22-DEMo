using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongAnswerButton : MonoBehaviour
{
    public void loadEndScreen(string level)
    {
        SceneManager.LoadScene(level);

    }
}

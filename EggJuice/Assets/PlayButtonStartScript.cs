using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonStartScript : MonoBehaviour
{
    public void Play()
    {
        // switch scenes
        SceneManager.LoadScene("Spencer scene");
    }
}

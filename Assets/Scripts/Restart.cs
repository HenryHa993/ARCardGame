using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Restart : MonoBehaviour
{
    public ARSession ARBattleSession;

    public void RestartSession()
    {
        ARBattleSession.Reset();
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}

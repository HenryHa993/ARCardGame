using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Nav : MonoBehaviour
{
    public void UINav(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}

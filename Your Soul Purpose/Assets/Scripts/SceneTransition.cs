using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnEnable()
    {
        //Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single Mode
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}

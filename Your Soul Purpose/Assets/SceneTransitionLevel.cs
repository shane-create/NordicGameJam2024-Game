using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionLevel : MonoBehaviour
{
    private void Ontrigger()
    {
        //Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single Mode
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}

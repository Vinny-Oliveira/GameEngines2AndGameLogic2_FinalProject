using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    /// <summary>
    /// Load a scene
    /// </summary>
    public void LoadScene(Object objScene) {
        SceneManager.LoadScene(objScene.name);
    }

}

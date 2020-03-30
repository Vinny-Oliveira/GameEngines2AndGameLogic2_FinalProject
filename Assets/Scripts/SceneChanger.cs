using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public SceneField nextScene;

    /// <summary>
    /// Load a scene
    /// </summary>
    public void LoadScene() {
        SceneManager.LoadScene(nextScene);
    }

}

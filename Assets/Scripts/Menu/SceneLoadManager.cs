using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private int basicMapSceneIndex;
    [SerializeField] private int editorSceneIndex;

    public void LoadBasicMap()
    {
        SceneManager.LoadScene(basicMapSceneIndex);
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene(editorSceneIndex);
    }
}

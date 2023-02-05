using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance { get; private set; }

    public List<Scene> GameScenes;
    public int currentScene = 1;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadNextLevel()
    {

        UnloadGameLevel(currentScene);
        currentScene++;
        LoadGameLevel(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameLevel(int index)
    {
        SceneManager.LoadSceneAsync(GameScenes[index].name, LoadSceneMode.Additive);
    }
    public void UnloadGameLevel(int index)
    {
        SceneManager.UnloadSceneAsync(GameScenes[index]);
    }



}

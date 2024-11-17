using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Netcode;

public static class SceneLoader
{
    // Enum for scene names
    public enum Scene
    {
        LoadingScene,
        LobbyScene,
        GameScene,
        CharacterSelect,
        MainMenu
    }

    // Store the target scene to load after the loading screen
    private static Scene targetScene;

    // Method to load a scene directly
    public static void LoadScene(Scene scene)
    {
        // Load the target scene directly
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoaderCallBack()
    {
        // Start the coroutine to load the target scene
        SceneManager.LoadScene(targetScene.ToString());
    }

    // Method to load the target scene after loading screen
    public static IEnumerator LoadTargetScene()
    {
        // Load the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneLoader.targetScene.ToString());
        asyncLoad.allowSceneActivation = false;

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                // Activate the scene when loading completes
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Method to load a scene asynchronously without loading screen
    public static void LoadSceneAsync(Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }

    // Method to unload a scene
    public static void UnloadScene(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene.ToString());
    }

    //networked
    public static void LoadNetwork(Scene targetScene)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Single);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSceneLoader : MonoBehaviour
{

    private static string[] PHASE1_SCENES = {"Enterance", "Living room", "Kitchen", "Bedroom", "Children room", "Item hall"};
    private static string[] PHASE2_SCENES = {"P2ItemHall", "ChildrenRoom", "P2Bedroom"};

    // Start is called before the first frame update
    void Start()
    {
        LoadPhase1();
    }

    
    static public void LoadPhase1()
    {
        Scene[] loadedScenes = GetLoadedScenes();        
        foreach(string sceneName in PHASE1_SCENES)
        {
            if (!IsSceneLoaded(sceneName, loadedScenes))
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                Debug.Log("Loading: " + sceneName);
            }
        }
    }

    static private void UnloadPhase1()
    {
        Scene[] loadedScenes = GetLoadedScenes();        
        foreach(string sceneName in PHASE1_SCENES)
        {
            if (IsSceneLoaded(sceneName, loadedScenes))
            {
                SceneManager.UnloadSceneAsync(sceneName);
                Debug.Log("Unloading: " + sceneName);
            }
        }
    }

    static public void LoadPhase2()
    {
        Scene[] loadedScenes = GetLoadedScenes();        
        foreach(string sceneName in PHASE2_SCENES)
        {
            if (!IsSceneLoaded(sceneName, loadedScenes))
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                Debug.Log("Loading: " + sceneName);
            }
        }
        UnloadPhase1();
    }

    static private bool IsSceneLoaded(string sceneName, Scene[] loadedScenes)
    {
        foreach(Scene scene in loadedScenes)
        {
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    static private Scene[] GetLoadedScenes()
    {
        Scene[] loaded = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; ++i) 
        {
            loaded[i] = SceneManager.GetSceneAt(i);
        }
        return loaded;
    }
}

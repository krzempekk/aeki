using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSceneLoader : MonoBehaviour
{

    private string[] PHASE1_SCENES = {"Enterance", "Living room", "Kitchen", "Bedroom", "Children room", "Item hall"};

    private bool isPhase1Loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadPhase1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void LoadPhase1()
    {
        Scene[] loadedScenes = GetLoadedScenes();        
        foreach(string sceneName in PHASE1_SCENES)
        {
            Debug.Log(sceneName);
            if (!IsSceneLoaded(sceneName, loadedScenes))
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                Debug.Log("Loading: " + sceneName);
            }
        }
    }

    private bool IsSceneLoaded(string sceneName, Scene[] loadedScenes)
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

    private Scene[] GetLoadedScenes()
    {
        Scene[] loaded = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; ++i) 
        {
            loaded[i] = SceneManager.GetSceneAt(i);
        }
        return loaded;
    }
}

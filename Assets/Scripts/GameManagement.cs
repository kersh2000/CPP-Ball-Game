using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement manager;

    private int sceneNumber;
    private int scenesLength = 2;

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        } else if (manager != this)
            {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneNumber = 0;
    }

    void Update()
    {
        
    }

    public void NextScene()
    {
        sceneNumber++;
        if (sceneNumber > scenesLength - 1)
        {
            sceneNumber = 0;
        }
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadScene(string givenSceneName)
    {
        SceneManager.LoadScene(givenSceneName);
        sceneNumber = SceneUtility.GetBuildIndexByScenePath(givenSceneName);
        DebugLog("Changed to scene '" + givenSceneName + "' of index: " + sceneNumber.ToString());
    }

    void DebugLog(string msg)
    {
        // Output ball's velocity
        Debug.Log(msg);
    }
}

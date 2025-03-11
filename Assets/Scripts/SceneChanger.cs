using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName = "")
    {
        if (sceneName == "")
        {
            GameManagement.manager.NextScene();
        } else
        {
            GameManagement.manager.LoadScene(sceneName);
        }
            
    }

    public void QuitApplication()
    {
        // Close application (on quit)
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
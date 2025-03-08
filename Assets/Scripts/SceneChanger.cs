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
}
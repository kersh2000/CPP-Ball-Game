using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement manager;
    public int lives;

    public int numOfPickups { get; private set; }
    public int numOfLives { get; private set; }
    public int score { get; private set; }

    private int sceneNumber;
    private int scenesLength;

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
        scenesLength = SceneManager.sceneCountInBuildSettings;
    }

    private void Start()
    {
        sceneNumber = 0;
        ResetStats();
    }

    public void NextScene()
    {
        sceneNumber++;
        if (sceneNumber > scenesLength - 1)
        {
            sceneNumber = 0;
            ResetStats();
        }
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadScene(string givenSceneName)
    {
        SceneManager.LoadScene(givenSceneName);
        sceneNumber = SceneUtility.GetBuildIndexByScenePath(givenSceneName);
        if (givenSceneName == "Main Scene")
        {
            ResetStats();
        }
    }

    public void ResetStats()
    {
        numOfPickups = 0;
        score = 0;
        numOfLives = 3;
    }

    public void IncreasePickup()
    {
        numOfPickups++;
        score += 10;
        if (numOfPickups == 10)
        {
            numOfPickups = 0;
            numOfLives++;
        }
    }

    public void DecreaseLife()
    {
        numOfLives--;
        score = (score >= 30) ? score - 30 : 0;
    }

    private void DebugLog(string msg)
    {
        // Output ball's velocity
        Debug.Log(msg);
    }
}

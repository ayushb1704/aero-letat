using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverUILogicScript : MonoBehaviour
{   
    private AudioSource audiosource;
    [SerializeField] private GameObject canvas;
    public AudioClip buttonClickSound;
    private BirdSceneScript birdSceneScript;
    [SerializeField] private GameObject highScoreText;

    void Start()
    {
        audiosource = canvas.GetComponent<AudioSource>();
        birdSceneScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<BirdSceneScript>();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;
    }
    void Update()
    {
        highScoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + BirdSceneScript.highScore.ToString();
    }

    public void RestartGame()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Invoke("DelayedRestart", 0.2f);
    }
    public void DelayedRestart()
    {
        SceneManager.LoadScene("Choose Char UI");
    }
    public void QuitGame()
    {
        audiosource.PlayOneShot(buttonClickSound);  
        Application.Quit();
    }   
}

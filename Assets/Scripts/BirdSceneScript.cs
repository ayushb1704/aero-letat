using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BirdSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject touchToStartScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    private AudioSource audiosource;
    [SerializeField] public AudioClip buttonClickSound;
    [SerializeField] private GameObject canvas;
    public int score;
    public static int highScore;
    void Start()
    {   
        Time.timeScale = 0;
        touchToStartScreen.SetActive(true);
        player.SetActive(false);
        audiosource = canvas.GetComponent<AudioSource>();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) == true) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            touchToStartScreen.SetActive(false);
            Time.timeScale = 1;
            player.SetActive(true);
            scoreText.SetActive(true);
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
        if(score > highScore)
        {
            highScore = score;
        }

    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
    public void PauseGame()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Time.timeScale = 0;
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ResumeGame()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;
using TMPro;

public class StartUILogicScript : MonoBehaviour
{
    [SerializeField] public GameObject startScreen;
    [SerializeField] public GameObject canvas;
    private AudioSource audiosource;
    public AudioClip buttonClickSound;
    private BirdSceneScript birdSceneScript;
    [SerializeField] private GameObject highScoreText;
    private void Start() 
    {   
        audiosource = canvas.GetComponent<AudioSource>();
        startScreen.SetActive(true);
        birdSceneScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<BirdSceneScript>();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;
    }
    private void Update() 
    {
        highScoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + BirdSceneScript.highScore.ToString();
    }
    public void StartGame()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Invoke("DelayedStartGame", 0.2f);
        
    }
    public void DelayedStartGame()
    {
        SceneManager.LoadScene("Choose Char UI");
    }
    public void QuitGame()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Application.Quit();
    }
}

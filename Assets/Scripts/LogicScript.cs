using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject player;
    public GameObject chooseCharScreen;
    public GameObject pressToStartScreen;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject canvas;
    public SpriteResolver resolver;
    public AudioClip scoreSound;
    public AudioClip milestoneSound;
    public AudioClip clickSound;
    public AudioClip crashSound;
    public AudioSource canvasaudioSource; // audio source on canvas
    public AudioSource playeraudioSource; // audio source on player
    private bool isCrashed = false;

    void Start()
    {
        startScreen.SetActive(true); //start screen dikhegi
        Time.timeScale = 0; //time stop rahega
        player.SetActive(false); //player deactive rahega
        canvasaudioSource = canvas.GetComponent<AudioSource>();
        playeraudioSource = player.GetComponent<AudioSource>();

        highScore = PlayerPrefs.GetInt("HighScore", 0); //retrieve previously stored highscore at the start of the game from the PlayerPrefs
        highScoreText.text = "High Score: " + highScore.ToString(); //stores the high score in string form in the highscoretext
        highScoreText.gameObject.SetActive(true); //displays the highscoretext on start screen
        resolver = player.GetComponent<SpriteResolver>();
    }

    void Update()
    {
        if(pressToStartScreen.activeSelf == true)
        {
            AfterPressToStart();
        }
    }
    public void AddScore(int scoreToAdd)
    {   
        
        playerScore += scoreToAdd; //playerscore update hoga usme scoreToAdd (jo bhi diya hoga) add karke 
        scoreText.text = playerScore.ToString(); //score ka text updated player score ke equal ho jayega
        if(playerScore%10 == 0)
        {
            playeraudioSource.PlayOneShot(milestoneSound);
        }
        else
        {
            playeraudioSource.PlayOneShot(scoreSound);    
        }
    }

    
    public void RestartGame()
    {   
        canvasaudioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {   
        if(!isCrashed)
        {
            canvasaudioSource.PlayOneShot(crashSound);
            isCrashed = true;
        }
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);

        if (playerScore > highScore) // agar player ka score high score se jayda hoga toh
        {
            highScore = playerScore; // naya highscore player ka score ho jayega 
            PlayerPrefs.SetInt("HighScore", highScore); //naya high score player prefs me store ho jayega 
            highScoreText.text = "High Score:" + highScore.ToString(); //naya highscore string form me highscoretext me store ho jayega
        }
        highScoreText.gameObject.SetActive(true); //highscoretext display hoga if ke bahar isiliye likha kyuki always display hona chahiye
    }
    public void AfterStartGame()
    {
        startScreen.SetActive(false); //start screen gayab
        chooseCharScreen.SetActive(true); //character choose screen dikhegi
        highScoreText.gameObject.SetActive(false); //highscoretext gayab
        canvasaudioSource.PlayOneShot(clickSound);
    }

    public void Bird()
    {
        resolver.SetCategoryAndLabel("Player", "Bird");
        AfterCharacterChoosen();
        canvasaudioSource.PlayOneShot(clickSound);
    }

    public void Dragon()
    {
        resolver.SetCategoryAndLabel("Player", "Dragon");
        AfterCharacterChoosen();
        canvasaudioSource.PlayOneShot(clickSound);
    }

    public void AfterCharacterChoosen()
    {
        chooseCharScreen.SetActive(false); //character choose screen gayab
        pressToStartScreen.SetActive(true); //press to start screen dikhegi
        canvasaudioSource.PlayOneShot(clickSound);
    }

    public void AfterPressToStart()
    {
        if ((Input.GetKeyDown(KeyCode.Space) == true) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            pressToStartScreen.SetActive(false); //press to start screen gayab
            Time.timeScale = 1; //time chalne lagega
            player.SetActive(true); //player active ho jayega
            pauseButton.SetActive(true); //pause button dikhega
        }
    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        canvasaudioSource.PlayOneShot(clickSound);
    }
    public void ResumeButtonClick()
    {
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        canvasaudioSource.PlayOneShot(clickSound);
    }


    public void AfterQuitGame()
    {   
        canvasaudioSource.PlayOneShot(clickSound);
        Application.Quit();
    }




}

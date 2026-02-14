using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharUILogicScript : MonoBehaviour
{
    [SerializeField] public GameObject chooseCharScreen;
    [SerializeField] public GameObject canvas;
    public AudioSource audiosource;
    public AudioClip buttonClickSound;
    [SerializeField] private Toggle hardModeToggle;

    void Start()
    {
        audiosource = canvas.GetComponent<AudioSource>();
        chooseCharScreen.SetActive(true);
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;
    }
    void Update()
    {
        if(hardModeToggle.isOn)
        {
            PipeSpawnerScript.spawnRate = 1f;
            PipeSpawnerScript.heightOffset = 4f;
        }
        else
        {
            PipeSpawnerScript.spawnRate = 1.5f;
            PipeSpawnerScript.heightOffset = 3.5f;
        }
    }
    public void Bird()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Invoke("DelayedBird", 0.2f);
        
    }
    public void DelayedBird()
    {
        SceneManager.LoadScene("Bird");
    }
    public void Dragon()
    {   
        audiosource.PlayOneShot(buttonClickSound);
        Invoke("DelayedDragon", 0.2f);
    }
    public void DelayedDragon()
    {
        SceneManager.LoadScene("Dragon");
    }
}

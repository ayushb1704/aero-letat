using UnityEngine;
using UnityEngine.SceneManagement;


public class SuyashScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;
    public AudioSource audioSource;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip crashSound;
    
    private bool isCrashed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = canvas.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.Space) == true) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && birdIsAlive == true)
        {   
            audioSource.PlayOneShot(flapSound);
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isCrashed == false)
        {
            audioSource.PlayOneShot(crashSound);
            isCrashed = true;
        }
        birdIsAlive = false;     
        Invoke("LoadScene", 1f);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Game Over UI");
    }
}
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public LineRenderer circleRenderer;
    public static GameManager Instance { get; private set; }


    public float bubblePushForce = 0.7f;
    public float maxBubbleVelocity = 3f;
    public GameObject target;

    [Header("CAMERA")]
    public GameObject mainCamera;

    [Header("UI RELATED")]
    // UI RELATED
    public GameObject GameOverPanel;
    public GameObject TimeTextObject;
    private int elapsedSeconds = 0; // Tracks seconds passed
    private float timer = 0f; // Internal timer to track time
    public bool isGameRunning = true;
    public TextMeshProUGUI highScoreText;

    [Header("SCREEN SHAKE")]
    public float duration;
    public float magnitude;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        isGameRunning = true;

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        isGameRunning = false;
        GameOverPanel.SetActive(true);
        int highscore = PlayerPrefs.GetInt("highscore");

        if (elapsedSeconds > highscore)
        {
            PlayerPrefs.SetInt("highscore", elapsedSeconds);
            highscore =  elapsedSeconds;
        }

        highScoreText.text = $"Highscore: {highscore}";

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
           
            UpdateTimerUI();

            timer += Time.deltaTime; // Add frame time to timer
            if (timer >= 1f)
            {
                elapsedSeconds++; // Increment elapsed seconds
                timer -= 1f; // Reset the timer for the next second
                UpdateTimerUI();
            }
        }
    }


    // UI FUNCTIONS

    void UpdateTimerUI()
    {
        TimeTextObject.GetComponent<TextMeshProUGUI>().text = "Time: " + $"{elapsedSeconds}";
    }

    public void retry_clicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void shake_screen()
    {
     
        var camera_shake = mainCamera.GetComponent<CameraShake>();
        camera_shake.StartCoroutine(camera_shake.Shake(duration, magnitude));
    }

}

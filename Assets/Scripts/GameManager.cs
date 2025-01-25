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

    [Header("UI RELATED")]
    // UI RELATED
    public GameObject GameOverPanel;
    public GameObject TimeTextObject;
    private int elapsedSeconds = 0; // Tracks seconds passed
    private float timer = 0f; // Internal timer to track time
    private bool isRunning = true;
    public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        Time.timeScale = 1f;

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void BubbleHit()
    {
        Debug.Log("Game over");
        GameOver();
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
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
        if (isRunning)
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

}

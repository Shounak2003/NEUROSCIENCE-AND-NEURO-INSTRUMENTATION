using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timerDuration = 30f; // Duration of the timer in seconds
    private float timer; // Remaining time on the timer
    public Text timerText; // Reference to the Text component for displaying the timer

    void Start()
    {
        timer = timerDuration; // Initialize the timer with the specified duration
    }

    void Update()
    {
        timer -= Time.deltaTime; // Decrease the timer by the time passed since the last frame

        if (timer <= 0f)
        {
            // Timer has expired, move to the next scene
            SceneManager.LoadScene(28); // Change the index to the index of your next scene
        }

        // Update the timer display text
        timerText.text =  Mathf.CeilToInt(timer).ToString() + "s"; // Round up the timer value and display as seconds
    }
}

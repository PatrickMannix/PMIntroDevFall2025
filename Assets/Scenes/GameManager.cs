using UnityEngine;
using TMPro; // Use this for TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    // The total time in seconds for the timer.
    public float totalTime = 60f;

    // A reference to the TextMeshPro component to display the time.
    public TextMeshProUGUI timerText;

    // A flag to check if the timer is running.
    private bool isTimerRunning = false;

    // Use this for initialization
    void Start()
    {
        // Start the timer when the game begins.
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            if (totalTime > 0)
            {
                // Subtract the time since the last frame.
                totalTime -= Time.deltaTime;

                // Update the UI text with the formatted time.
                // The 'F1' formats the float to one decimal place.
                timerText.text = totalTime.ToString("F1");
            }
            else
            {
                // Stop the timer and set the time to 0.
                isTimerRunning = false;
                totalTime = 0;
                timerText.text = "0.0";

                // You can add an event here for when the timer ends.
                Debug.Log("Time's up!");
            }
        }
    }
}
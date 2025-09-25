using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLimit = 60f;
    public float timeModifier = 5f; // Time added/subtracted per action
    private float currentTime;

    void Start()
    {
        currentTime = timeLimit;
        UpdateTimerDisplay();
    }

    public TextMeshProUGUI cooldownText;

    void Update()
    {
        // ... (existing input checks) ...
        int lastSpecialAttackTime = 0, specialAttackCooldown = 0;
        // Update cooldown display
        float remainingCooldown = lastSpecialAttackTime + specialAttackCooldown - Time.time;
        if (remainingCooldown > 0)
        {
            cooldownText.text = "Cooldown: " + remainingCooldown.ToString("F1");
        }
        else
        {
            cooldownText.text = "Ready!";
        }
    }


    public void ModifyTime(bool increase)
    {
        if (increase)
        {
            currentTime += timeModifier;
        }
        else
        {
            currentTime -= timeModifier;
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}



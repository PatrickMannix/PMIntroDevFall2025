using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public float comboTimer;
    public TextMeshProUGUI myText;
    public GameObject myPlayer;
    public WASDcontroller2D playerController;


    private bool comboActive = false;
    private float lastHitTime;
    public float comboResetTime = 2.0f;
    private int lastAttackTime;
    private int comboTimeWindow;



    public TextMeshProUGUI timerText;
    public TextMeshProUGUI cooldownText;
    private float currentTime;


    void Start()
    {
        comboTimer = 0f;
        myText.text = "0.00";


        currentTime = 0f;
        UpdateTimerDisplay();
    }


    void Update()
    {

        if (comboActive)
        {
            comboTimer += Time.deltaTime;
            myText.text = comboTimer.ToString("F2");


            if (Time.time - lastHitTime > comboResetTime)
            {
                EndCombo();
            }
        }


        currentTime += Time.deltaTime;
        UpdateTimerDisplay();



        int lastSpecialAttackTime = 0, specialAttackCooldown = 0;
        float remainingCooldown = lastSpecialAttackTime + specialAttackCooldown - Time.time;

        if (cooldownText != null)
        {
            if (remainingCooldown > 0)
            {
                cooldownText.text = "Cooldown: " + remainingCooldown.ToString("F1");
            }
            else
            {
                cooldownText.text = "Ready!";
            }
        }
    }


    void Attack()
    {
        if (Time.time > lastAttackTime + comboTimeWindow)
        {

        }



        float time = Time.time;
        lastAttackTime = (int)time;
    }




    public void StartCombo()
    {
        if (!comboActive)
        {
            comboActive = true;
            comboTimer = 0f;
            Debug.Log("Combo Started!");
        }
        lastHitTime = Time.time;
    }


    private void EndCombo()
    {
        comboActive = false;
        Debug.Log("Combo Ended!");
        comboTimer = 0f;
        myText.text = "0.00";
    }


    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

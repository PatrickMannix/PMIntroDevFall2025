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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comboTimer = 0f;
        myText.text = "0.00";
    }

    // Update is called once per frame
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
    }

    void Attack()
    {
        if (Time.time > lastAttackTime + comboTimeWindow)
        {
            comboCount = 0;
        }

        comboCount++;
        float time = Time.time;
        lastAttackTime = (int)time;

        // Call your damage function here
        // ...
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
}

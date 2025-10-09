using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;


    public float comboWindowTime = 1.0f; // Time (in seconds) the player has for the next hit
    private float comboTimer;
    private int comboCount = 0;


    public TMPro.TextMeshProUGUI comboText;
    public float bounceForce = 40f; // Force applied on wall impact
    public float damagePerHit = 10f; // Damage to be taken on hit

    void Start()
    {
        currentHealth = maxHealth;
        comboTimer = 0f;
        UpdateComboDisplay();
    }

    void Update()
    {

        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
        else if (comboCount > 0)
        {

            comboCount = 0;
            UpdateComboDisplay();
        }
    }


    public void GetHit(float attackForce, Vector2 attackDirection)
    {

        TakeDamage((int)damagePerHit);


        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {

            rb.AddForce(attackDirection * attackForce, ForceMode2D.Impulse);
        }


        comboCount++;
        comboTimer = comboWindowTime; 
        UpdateComboDisplay();
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            Vector2 reboundDirection = collision.contacts[0].normal;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {

                rb.velocity = new Vector2(0, rb.velocity.y);


                rb.AddForce(reboundDirection * bounceForce, ForceMode2D.Impulse);
                Debug.Log("Dummy bounced off the wall!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Dummy took " + damage + " damage! Current Health: " + currentHealth);

    }

    private void UpdateComboDisplay()
    {
        if (comboText != null)
        {
            if (comboCount > 0)
            {
                comboText.text = "Combo: " + comboCount + "\nWindow: " + comboTimer.ToString("F2");
            }
            else
            {
                comboText.text = ""; 
            }
        }
    }



    [System.Obsolete]
    public void Launch(float launchForce)
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
        }
    }
}


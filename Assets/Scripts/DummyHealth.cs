using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private object dummy;
    private object attackDamage;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Dummy took " + damage + " damage! Current Health: " + currentHealth);
    }

    [System.Obsolete]
    public void Launch(float launchForce)
    {
        // Ensure the dummy has a Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Reset vertical velocity to ensure consistent launch
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

        }
    }

}

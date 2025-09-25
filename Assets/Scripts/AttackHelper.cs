using UnityEngine;

public class AttackHelper : MonoBehaviour
{

    public bool isAttacking;
    public float attackForce = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(isAttacking)
        {
            Attack(collision.gameObject);
        }
    }

    void Attack(GameObject other)
    {
        //code goes here
        Vector2 attackDirection = (other.transform.position - this.transform.position).normalized;
        Rigidbody2D targetRB = other.GetComponent<Rigidbody2D>();
        targetRB.AddForce(attackDirection * attackForce, ForceMode2D.Impulse);
        Debug.Log("Attacked dummy!");
    }
}

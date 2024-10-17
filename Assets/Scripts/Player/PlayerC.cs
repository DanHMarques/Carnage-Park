using UnityEngine;

public class PlayerC : MonoBehaviour
{
	[Header("Move")]
	public float moveSpeed;
	public Rigidbody2D rb;
	Vector2 movement;

    void FixedUpdate()
	{
		Move();
	}
    void Move()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement.normalized * moveSpeed;

        transform.eulerAngles = movement.x > 0 ? Vector3.zero : movement.x < transform.position.x ? Vector3.up * 180 : transform.eulerAngles;
		
    }
}
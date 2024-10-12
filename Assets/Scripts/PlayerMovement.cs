using UnityEngine;

// Скрипт для: Передвижения игрока
// Поместить на: GameObject Игрока


public class PlayerMovement : MonoBehaviour 
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Transform pos;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update() 
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));     
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
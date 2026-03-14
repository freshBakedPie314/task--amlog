using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Background : MonoBehaviour
{
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = -speed;
    }

    private void Update()
    {
        if(transform.position.y <= lowerLimit)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = upperLimit;
            transform.position = newPosition;
        }
    }
}

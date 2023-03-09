using UnityEngine;

public class ShipMover : MonoBehaviour
{
    [SerializeField] private UIdata _score;
    [SerializeField] private float _shipSpeed;
    [SerializeField] private float _rotatingSpeed;

    private Rigidbody2D _rb;
    private float _rotationAngle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _score.Reset();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddRelativeForce(Vector2.up * _shipSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _rotationAngle = -Input.GetAxis("Horizontal") * (_rotatingSpeed * Time.deltaTime);
            transform.Rotate(transform.rotation.x, transform.rotation.y, _rotationAngle);
        }
    }
}
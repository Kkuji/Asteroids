using UnityEngine;

public class MeteoriteMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _directionDeviation;
    [SerializeField] private float _defaultDirectionMultiplier;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = -RandomDirection(transform).normalized * _speed;
    }

    private Vector2 RandomDirection(Transform transform)
    {
        float directionMultiplier = Random.Range(_defaultDirectionMultiplier - _directionDeviation,
                                                 _defaultDirectionMultiplier + _directionDeviation);
        int coordinateToMultiply = Random.Range(0, 2);

        if (coordinateToMultiply == 1)
            return new Vector2(transform.position.x * directionMultiplier, transform.position.y);
        else
            return new Vector2(transform.position.x, transform.position.y * directionMultiplier);
    }
}

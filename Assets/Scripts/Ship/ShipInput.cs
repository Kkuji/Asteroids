using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private UIdata _score;
    [SerializeField] private GameObject _laser;
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _shipSpeed;
    [SerializeField] private float _rotatingSpeed;
    [SerializeField] private float _laserShootVolume;

    private AudioSource _source;
    private Rigidbody2D _rb;
    private float _rotationAngle;
    private bool _laserShooted = false;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _score.Reset();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            _laserShooted = true;
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

        if (_laserShooted)
        {
            CreateLaser();
        }
    }

    private void CreateLaser()
    {
        GameObject currentLaser = Instantiate(_laser, transform.position, transform.rotation);
        Rigidbody2D laserRidgidbody = currentLaser.GetComponent<Rigidbody2D>();
        laserRidgidbody.AddRelativeForce(Vector2.up * _laserSpeed);
        laserRidgidbody.GetComponent<Laser>().score = _score;
        laserRidgidbody.GetComponent<Laser>().source = _source;
        _source.PlayOneShot(_shootAudio, _laserShootVolume);
        _laserShooted = false;
    }
}


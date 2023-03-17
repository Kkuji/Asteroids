using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShipShooter : MonoBehaviour
{
    [SerializeField] private UIdata _score;
    [SerializeField] private GameObject _laser;
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private AudioSource _indestructibleSource;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _laserShootVolume;

    private AudioSource _source;
    private bool _laserShooted = false;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _laserShooted = true;
        }
    }

    private void FixedUpdate()
    {
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
        currentLaser.GetComponent<Laser>().score = _score;
        currentLaser.GetComponent<Laser>().source = _indestructibleSource;
        _source.PlayOneShot(_shootAudio, _laserShootVolume);
        _laserShooted = false;
    }
}
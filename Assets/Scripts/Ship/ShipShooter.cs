using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShipShooter : ObjectPool
{
    [SerializeField] private UIdata _score;
    [SerializeField] private GameObject _laser;
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private AudioSource _indestructibleSource;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _laserShootVolume;

    private AudioSource _source;

    private void Start()
    {
        Initialize(_laser);
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateLaser();
        }
    }

    private void CreateLaser()
    {
        if (TryGetObject(out GameObject laser))
        {
            SetLaser(laser);
        }
    }

    private void SetLaser(GameObject laser)
    {
        laser.SetActive(true);

        laser.transform.SetPositionAndRotation(transform.position, transform.rotation);
        laser.GetComponent<Rigidbody2D>().AddForce(transform.up * _laserSpeed);

        laser.GetComponent<Laser>().score = _score;
        laser.GetComponent<Laser>().source = _indestructibleSource;

        _source.PlayOneShot(_shootAudio, _laserShootVolume);
    }
}
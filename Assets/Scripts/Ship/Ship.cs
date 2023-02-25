using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    [SerializeField] private UIdata _score;
    [SerializeField] private AudioClip _hitAudio;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ShipTeleportation _teleporter;
    [SerializeField] private float _hitMeteoriteVolume;

    public event Action<GameObject> OnShipCollidedBorderAction;

    private void Start()
    {
        _teleporter.SetShip(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TeleportationBorder>() != null)
        {
            OnShipCollidedBorderAction?.Invoke(other.gameObject);
        }

        if (other.gameObject.GetComponent<Meteorite>() != null)
        {
            if (_score.health > 1)
            {
                MeteoriteCollides(other, other.transform);
            }
            else
            {
                MeteoriteCollides(other, transform);
                Destroy(gameObject);
            }
        }
    }

    private void MeteoriteCollides(Collider2D objectToDestroy, Transform explosionTransform)
    {
        Instantiate(_explosion, explosionTransform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_hitAudio, transform.position, _hitMeteoriteVolume);
        Destroy(objectToDestroy.gameObject);
        _score.LoseHealth();
    }
}

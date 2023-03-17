using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    [SerializeField] private UIdata _score;
    [SerializeField] private AudioClip _hitAudio;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ShipTeleporter _teleporter;
    [SerializeField] private float _hitMeteoriteVolume;

    public event Action<GameObject> OnShipCollidedBorderAction;

    private void Start()
    {
        _teleporter.AssignAction(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TeleportationBorder>() != null)
        {
            OnShipCollidedBorderAction?.Invoke(other.gameObject);
        }

        if (other.gameObject.GetComponent<Meteorite>() != null)
        {
            MeteoriteCollides();

            if (_score.health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void MeteoriteCollides()
    {
        AudioSource.PlayClipAtPoint(_hitAudio, transform.position, _hitMeteoriteVolume);
        _score.LoseHealth();
    }

    private void OnDestroy()
    {
        _teleporter.UnassignAction(this);
    }
}
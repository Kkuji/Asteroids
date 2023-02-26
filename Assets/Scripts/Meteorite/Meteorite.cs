using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TeleportationBorder>() != null)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<Laser>() != null ||
            other.gameObject.GetComponent<Ship>() != null)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private AudioClip _explosionAudio;
    [SerializeField] private float _explosionAudioVolume;

    [HideInInspector] public UIdata score;
    [HideInInspector] public AudioSource source;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Meteorite"))
        {
            source.PlayOneShot(_explosionAudio, _explosionAudioVolume);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
            score.Increment();
        }
    }
}
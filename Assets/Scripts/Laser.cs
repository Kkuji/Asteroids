using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionAudio;
    [SerializeField] private float _explosionAudioVolume;

    [HideInInspector] public UIdata score;
    [HideInInspector] public AudioSource source;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TeleportationBorder>() != null)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<Meteorite>() != null)
        {
            source.PlayOneShot(_explosionAudio, _explosionAudioVolume);
            Destroy(gameObject);
            score.Increment();
        }
    }
}

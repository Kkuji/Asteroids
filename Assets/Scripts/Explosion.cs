using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem explosion = GetComponent<ParticleSystem>();
        Destroy(gameObject, explosion.main.duration);
    }
}

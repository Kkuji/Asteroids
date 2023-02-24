using UnityEngine;
using System.Collections;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private float _differenceInScale;
    [SerializeField] private float _minTimeSpawnMeteorite;
    [SerializeField] private float _maxTimeSpawnMeteorite;
    [SerializeField] private GameObject _meteorite;
    [SerializeField] private PolygonCollider2D _wholeBordersCollider;

    private bool _spawnPosible = true;

    private void Update()
    {
        if (_spawnPosible)
        {
            StartCoroutine(Spawn());
            _spawnPosible = false;
        }
    }

    IEnumerator Spawn()
    {
        float angle = Random.Range(0, 360);
        float scaleMultiplier = Random.Range(1 - _differenceInScale, 1 + _differenceInScale);
        float spawnTime = Random.Range(_minTimeSpawnMeteorite, _maxTimeSpawnMeteorite);

        Vector2 meteoritePosition = RandomPointInBounds(_wholeBordersCollider);
        Quaternion meteoriteRotation = Quaternion.Euler(0f, 0f, angle);
        GameObject scaledMeteorite = Instantiate(_meteorite, meteoritePosition, meteoriteRotation);
        scaledMeteorite.GetComponent<Meteorite>().wholeBorderCollider = _wholeBordersCollider;
        scaledMeteorite.transform.localScale = new Vector3(scaledMeteorite.transform.localScale.x * scaleMultiplier,
                                                           scaledMeteorite.transform.localScale.y * scaleMultiplier,
                                                           scaledMeteorite.transform.localScale.z);
        yield return new WaitForSeconds(spawnTime);
        _spawnPosible = true;
    }

    private Vector2 RandomPointInBounds(PolygonCollider2D Collider)
    {
        Vector2 randomPoint = new(Random.Range(Collider.bounds.min.x, Collider.bounds.max.x),
                                  Random.Range(Collider.bounds.min.y, Collider.bounds.max.y));
        return (Vector2)Collider.ClosestPoint(new Vector2(randomPoint.x, randomPoint.y));
    }
}

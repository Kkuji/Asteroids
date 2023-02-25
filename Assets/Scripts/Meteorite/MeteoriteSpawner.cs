using UnityEngine;
using System.Collections;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private float _endAngle;
    [SerializeField] private float _startAngle;
    [SerializeField] private float _differenceInScale;
    [SerializeField] private float _baseScaleMultiplier;
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
        float spawnTime = Random.Range(_minTimeSpawnMeteorite, _maxTimeSpawnMeteorite);
        GameObject instantiatedMeteorite = InstantiateRandomMeteorite();
        instantiatedMeteorite.GetComponent<Meteorite>().wholeBorderCollider = _wholeBordersCollider;

        yield return new WaitForSeconds(spawnTime);
        _spawnPosible = true;
    }

    private GameObject InstantiateRandomMeteorite()
    {
        float angle = Random.Range(_startAngle, _endAngle);
        float scaleMultiplier = Random.Range(_baseScaleMultiplier - _differenceInScale, _baseScaleMultiplier + _differenceInScale);

        Vector2 meteoritePosition = RandomPointInBounds(_wholeBordersCollider);
        Quaternion meteoriteRotation = Quaternion.Euler(0f, 0f, angle);
        GameObject scaledMeteorite = Instantiate(_meteorite, meteoritePosition, meteoriteRotation);
        scaledMeteorite.transform.localScale = new Vector2(scaledMeteorite.transform.localScale.x * scaleMultiplier,
                                                           scaledMeteorite.transform.localScale.y * scaleMultiplier);
        return scaledMeteorite;
    }

    private Vector2 RandomPointInBounds(PolygonCollider2D Collider)
    {
        Vector2 randomPoint = new(Random.Range(Collider.bounds.min.x, Collider.bounds.max.x),
                                  Random.Range(Collider.bounds.min.y, Collider.bounds.max.y));
        return (Vector2)Collider.ClosestPoint(new Vector2(randomPoint.x, randomPoint.y));
    }
}

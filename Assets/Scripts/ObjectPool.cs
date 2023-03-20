using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _placeToSpawn;
    [SerializeField] private int _amount;

    private List<GameObject> _pool = new();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _amount; i++)
        {
            GameObject spawned = Instantiate(prefab, _placeToSpawn.transform.position, Quaternion.identity);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);

        return result != null;
    }
}
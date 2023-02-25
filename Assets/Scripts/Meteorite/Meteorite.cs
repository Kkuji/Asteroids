using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [HideInInspector] public PolygonCollider2D wholeBorderCollider;

    private void Update()
    {
        if (wholeBorderCollider.OverlapPoint(transform.position))
            Destroy(gameObject);
    }
}

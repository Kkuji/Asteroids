using UnityEngine;
using System;

[Serializable]
public class ShipTeleportation
{
    [SerializeField] private GameObject _leftBorder;
    [SerializeField] private GameObject _rightBorder;
    [SerializeField] private GameObject _botBorder;
    [SerializeField] private GameObject _topBorder;

    private Ship _playerShip;
    private Transform _shipTransform;

    public void SetShip(Ship _playerShip)
    {
        this._playerShip = _playerShip;
        _shipTransform = _playerShip.GetComponent<Transform>();
        this._playerShip.OnShipCollidedBorderAction += OnShipCollidedBorder;
    }

    private void OnShipCollidedBorder(GameObject border)
    {
        if (border == _leftBorder)
            TeleportShip(_rightBorder.transform.position.x, _shipTransform.position.y);

        if (border == _rightBorder)
            TeleportShip(_leftBorder.transform.position.x, _shipTransform.position.y);

        if (border == _topBorder)
            TeleportShip(_shipTransform.position.x, _botBorder.transform.position.y);

        if (border == _botBorder)
            TeleportShip(_shipTransform.position.x, _topBorder.transform.position.y);
    }

    private void TeleportShip(float CoordinateX, float CoordinateY)
    {
        _shipTransform.position = new Vector2(CoordinateX, CoordinateY);
    }
}

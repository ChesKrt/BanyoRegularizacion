using UnityEngine;

public class Collection
{
    private string _name;
    private int _cost;
    private GameObject _gameObject;

    public Collection(string name, int cost, GameObject gameObject)
    {
        this._name = name;
        this._cost = cost;
        _gameObject = gameObject;
    }

    public void SpawnObject(Vector2Int position)
    {
        GameObject.Instantiate(_gameObject, new Vector3 (position.x, position.y, 0), Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private bool _isSpawning;
    [SerializeField] private float _delay;

    private List<Transform> _points;
    private int _currentPoint;

    private void Start()
    {
        GetPointsSpawn();
        StartCoroutine(Spawn(_delay));
    }

    private void GetPointsSpawn()
    {
        _points = new List<Transform>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
            _points.Add(gameObject.transform.GetChild(i));
    }

    private IEnumerator Spawn(float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (_isSpawning)
        {
            for (_currentPoint = 0; _currentPoint < _points.Count; _currentPoint++)
            {
                Instantiate(_spawnObject, _points[_currentPoint]);
                yield return waitForSeconds;
            }
            _currentPoint = 0;
        }
        StopCoroutine(Spawn(_delay));
    }
}

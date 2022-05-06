using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private bool _isSpawning;
    [SerializeField] private float _delay;

    private List<Transform> _points;
    private int _currentPoint;

    private void Start()
    {
        CreatePointsSpawn();
        StartCoroutine(Spawn(_delay));
    }

    private void CreatePointsSpawn()
    {
        _points = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
            _points.Add(gameObject.transform.GetChild(i));
    }

    private IEnumerator Spawn(float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (_isSpawning)
        {
            for (_currentPoint = 0; _currentPoint < _points.Count; _currentPoint++)
            {
                Instantiate(_prefab, _points[_currentPoint]);
                yield return waitForSeconds;
            }
            _currentPoint = 0;
        }
    }
}

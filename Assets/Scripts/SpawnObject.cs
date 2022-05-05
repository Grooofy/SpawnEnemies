using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    private List<Transform> _points;
    private int _spawnPoint;

    private void Start()
    {
        GetPointsSpawn();
    }

    
    private void Update()
    {
        
    }

    private void GetPointsSpawn()
    {
        _points = new List<Transform>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
            _points.Add(gameObject.transform.GetChild(i));
    }

   
}

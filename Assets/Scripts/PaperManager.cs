using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour
{
    [SerializeField] private GameObject _paperPrefab;
    [SerializeField] private GameObject _tableTop;
    private MeshCollider _spawnSurface;

    void Awake()
    {
        _spawnSurface = _tableTop.GetComponent<MeshCollider>();
    }

    void Start()
    {
        SpawnPaper(_paperPrefab);
    }

    public void SpawnPaper(GameObject paper)
    {
        float screenX, screenY;
        Vector2 spawnPosition;
        screenX = Random.Range(_spawnSurface.bounds.min.x, _spawnSurface.bounds.max.x);
        screenY = Random.Range(_spawnSurface.bounds.min.y, _spawnSurface.bounds.max.y);
        spawnPosition = new Vector2(screenX, screenY);
        Instantiate(paper, spawnPosition, _paperPrefab.transform.rotation);
    }
}

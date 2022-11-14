using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour
{
    [SerializeField] private GameObject _paperPrefab;
    [SerializeField] private GameObject tableTop;
    private MeshCollider spawnSurface;

    public void Awake()
    {
        spawnSurface = tableTop.GetComponent<MeshCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPaper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPaper()
    {
        float screenX, screenY;
        Vector2 spawnPosition;
        screenX = Random.Range(spawnSurface.bounds.min.x, spawnSurface.bounds.max.x);
        screenY = Random.Range(spawnSurface.bounds.min.y, spawnSurface.bounds.max.y);
        spawnPosition = new Vector2(screenX, screenY);
        Instantiate(_paperPrefab, spawnPosition, _paperPrefab.transform.rotation);
    }
}

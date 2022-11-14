using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour
{
    private GameObject _paperPrefab;
    [SerializeField] private GameObject Quad;

    public void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPaper()
    {
        float screenX, screenY;
        screenX = Random.Range();
        screenY = Random.Range();
    }
}

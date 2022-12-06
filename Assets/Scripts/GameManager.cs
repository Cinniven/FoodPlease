using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager DontDestroy
    public static GameManager Instance;

    //Paper & Spawning
    [SerializeField] private GameObject _paperPrefab;
    private MeshCollider _spawnSurface;
    [SerializeField] private List<TextAsset> _paperTexts;

    //Score
    [SerializeField] private int _karma, _unstampedPapers, _papersDeliveredToday;

    //Days
    [SerializeField] private int _day = 1;
    public int Day {get {return _day;}}

    //Fade
    private Animator _fade; 

    void Awake()
    {
        //This makes it so that our that our GameManager stays when we load new scenes and that is dosnt duplicate
        if(Instance != null)
        {
            Instance.NewDay();
            Destroy(this.gameObject);
        }
        else Instance = this;
        DontDestroyOnLoad(this.gameObject);
        if(Instance == this) NewDay();
    }

    public void NewDay()
    {
        //Finds the surface area where we spawn papers
        _spawnSurface = GameObject.Find("TablePaperArea").GetComponent<MeshCollider>();
        _fade = GameObject.Find("Fade").GetComponent<Animator>();
        _papersDeliveredToday = 0;
        if (_day % 5 == 0) SpawnItem(_paperPrefab, true);
        else SpawnItem(_paperPrefab, false);
    }

    public void PaperDelivered(int points, bool stamped, bool special)
    {
        if(!stamped) _unstampedPapers++;
        if(!special) _papersDeliveredToday++;
        _karma += points;

        if(_papersDeliveredToday == 2) EndDay();
        else SpawnItem(_paperPrefab, false);
    }

    public void SpawnItem(GameObject item, bool special)
    {
        float screenX, screenY;
        Vector3 spawnPosition;
        screenX = Random.Range(_spawnSurface.bounds.min.x, _spawnSurface.bounds.max.x);
        screenY = Random.Range(_spawnSurface.bounds.min.y, _spawnSurface.bounds.max.y);
        spawnPosition = new Vector3(screenX, screenY, -1);
        GameObject spawnedItem = Instantiate(item, spawnPosition, _paperPrefab.transform.rotation);
        
        if(spawnedItem.layer == 6)
        {
            spawnedItem.GetComponent<Paper>().SetPaper(WhatPaperToSpawn(), special);
        }
    }

    private TextAsset WhatPaperToSpawn()
    {
        TextAsset paperToSpawn = _paperTexts[Random.Range(0, _paperTexts.Count)];
        _paperTexts.Remove(paperToSpawn);
        return(paperToSpawn);
    }

    private void EndDay()
    {
        _day++;
        _fade.SetTrigger("FadeOut");
    }
}

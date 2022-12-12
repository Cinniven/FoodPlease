using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _paperPrefab;
    private MeshCollider _spawnSurface;
    [SerializeField] private List<TextAsset> _paperTexts;
    private List<string> _dialog = new List<string>();
    public List<string> Dialog {get {return _dialog;}}
    [SerializeField] private int _papersPerDay = 2;
    [SerializeField] private int _karma, _unstampedPapers, _papersDeliveredToday, _day = 1, _specialDays = 3;

    public int Karma {get {return _karma;}}
    public int UnstampedPapers {get {return _unstampedPapers;}}
    public int Day {get {return _day;}}
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
        if (_day % _specialDays == 0) SpawnItem(_paperPrefab, true);
        else SpawnItem(_paperPrefab, false);
        _dialog = new List<string>();
        _dialog.Add("So about the choices you took yesterday, I do have some thoughts I wanna share.");
    }

    public void PaperDelivered(int points, bool stamped, bool special, string dialog)
    {
        Debug.Log(points);
        Debug.Log(stamped);
        Debug.Log(special);
        Debug.Log(dialog);

        if(!stamped) _unstampedPapers++;
        if(!special) _papersDeliveredToday++;
        _karma += points;
        _dialog.Add(dialog);

        if(_papersDeliveredToday == _papersPerDay) EndDay();
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

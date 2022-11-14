using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    PaperManager _paperManager;
    void Awake()
    {
        _paperManager = GetComponentInParent<PaperManager>();
    }
    public void Yes()
    {
        Debug.Log("YES!");
        _paperManager.SpawnPaper();
        Destroy(this.gameObject);
    }

    public void No()
    {
        Debug.Log("NO!");
        _paperManager.SpawnPaper();
        Destroy(this.gameObject);
    }
}

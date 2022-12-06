using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamp : MonoBehaviour
{
    public UnityEvent StampPaper;
    [SerializeField] private GameObject _stampPrefabYes, _stampPrefabNo;
    private GameObject _paperTarget;
    private bool _paper;
    [SerializeField] private bool _isYes;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Stamping();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _paperTarget = other.gameObject;
            _paper = true;
            
            if (_isYes) StampPaper.AddListener(other.GetComponentInParent<Paper>().Yes);
            else StampPaper.AddListener(other.GetComponentInParent<Paper>().No);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer != 3) return;
        _paperTarget = null;
        _paper = false;

        if (_isYes) StampPaper.RemoveListener(other.GetComponentInParent<Paper>().Yes);
        else StampPaper.RemoveListener(other.GetComponentInParent<Paper>().No);
    }

    void Stamping()
    {
        if(!_paper) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (targetObject != this.transform.GetChild(0).GetComponent<BoxCollider2D>()) return;
        
        StampPaper.Invoke();
        if(_isYes) Instantiate(_stampPrefabYes, transform.position, Quaternion.identity, _paperTarget.transform);
        else Instantiate(_stampPrefabNo, transform.position, Quaternion.identity, _paperTarget.transform);
    }
}

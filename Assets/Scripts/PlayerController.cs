using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple drag and drop code from GameDev Beginner
public class PlayerController : MonoBehaviour
{
    private GameObject _selectedObject;
    Vector3 _offset;
    [SerializeField] private AudioClip _pickUp, _letGo;
    private AudioSource _audio;
    
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if(!targetObject) return;
            if (targetObject.CompareTag("Grabable"))
            {
                Debug.Log(targetObject);
                _audio.PlayOneShot(_pickUp);
                _selectedObject = targetObject.transform.parent.gameObject;
                _offset = _selectedObject.transform.position - mousePosition;
            }
        }

        if (_selectedObject)
        {
            _selectedObject.transform.position = mousePosition + _offset;
        }
        
        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {
            _audio.PlayOneShot(_letGo);
            _selectedObject = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject _selectedObject;
    Vector3 _offset;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                _selectedObject = targetObject.transform.gameObject;
                _offset = _selectedObject.transform.position - mousePosition;
            }
        }
        if (_selectedObject)
        {
            _selectedObject.transform.position = mousePosition + _offset;
        }
        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {
            _selectedObject = null;
        }
    }
}

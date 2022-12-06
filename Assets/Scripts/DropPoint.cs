using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropPoint : MonoBehaviour
{
    private Collider2D _isPaper;
    public UnityEvent PaperDelivery;
    [SerializeField] private bool _isDelivered;

    private void Update()
    {
        if(!_isPaper) return;
        if(_isDelivered) return;

        if (Input.GetMouseButtonUp(0) && _isPaper.IsTouching(this.gameObject.GetComponent<Collider2D>()))
        {
            PaperDelivery.Invoke();
            _isDelivered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isDelivered = false;
            _isPaper = other;
            PaperDelivery.AddListener(other.gameObject.GetComponent<Paper>().Deliver);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isPaper = null;
            PaperDelivery.RemoveListener(other.gameObject.GetComponent<Paper>().Deliver);
        }
    }
}

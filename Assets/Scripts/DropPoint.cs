using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropPoint : MonoBehaviour
{
    // The collider attached to the paper object
    private Collider2D _isPaper;

    // An event that is invoked when the paper is delivered
    public UnityEvent PaperDelivery;

    // A flag that indicates whether the paper has been delivered or not
    [SerializeField] private bool _isDelivered;

    private void Update()
    {
        // If there is no paper or the paper has already been delivered, return
        if(!_isPaper || _isDelivered) return;

        // If the mouse button is released and the paper is touching the drop point,
        // invoke the PaperDelivery event and set the isDelivered flag to true
        if (Input.GetMouseButtonUp(0) && _isPaper.IsTouching(this.gameObject.GetComponent<Collider2D>()))
        {
            PaperDelivery.Invoke();
            _isDelivered = true;
        }
    }

    // This function is called whenever another collider enters the drop point's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other collider is on layer 6 (which is the layer the paper is on),
        // set the isDelivered flag to false, set the isPaper collider to the other collider
        // and add a listener to the PaperDelivery event that invokes the Deliver function on the Paper component attached to the other game object
        if(other.gameObject.layer == 6)
        {
            _isDelivered = false;
            _isPaper = other;
            PaperDelivery.AddListener(other.gameObject.GetComponent<Paper>().Deliver);
        }
    }

    // This function is called whenever another collider exits the drop point's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        // If the other collider is on layer 6 (which is the layer the paper is on),
        // set the isPaper collider to null and remove the listener from the PaperDelivery event that invokes the Deliver function on the Paper component attached to the other game object
        if(other.gameObject.layer == 6)
        {
            _isPaper = null;
            PaperDelivery.RemoveListener(other.gameObject.GetComponent<Paper>().Deliver);
        }
    }
}
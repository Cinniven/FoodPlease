using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit?" + collision);
        if(collision.gameObject.CompareTag("Swapable"))
        {
            collision.gameObject.GetComponent<SpriteSwap>().Swap();
        }
        else
        {
            Debug.Log("Not a grabable object hit border wall: " + collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Hit?" + collision);
        if(collision.gameObject.CompareTag("Swapable"))
        {
            collision.gameObject.GetComponent<SpriteSwap>().Swap();
        }
        else
        {
            Debug.Log("Not a grabable object hit border wall: " + collision);
        }
    }
}

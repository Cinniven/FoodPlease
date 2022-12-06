using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{
    [SerializeField] private bool _big = false;
    // Start is called before the first frame update

    public void Swap()
    {
        Debug.Log("Yes");
        if(_big == false)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            _big = true;
        }
        else if(_big == true)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            _big = false;
        }
    }
}

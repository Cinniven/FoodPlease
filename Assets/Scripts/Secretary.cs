using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretary : MonoBehaviour
{
    public void PutPaperAway()
    {
        gameObject.GetComponent<Animator>().SetTrigger("PutPaperAway");
    }
}

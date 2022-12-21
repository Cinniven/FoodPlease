using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    void Start()
    {
        if(GameManager.Instance.Day == 1)
        {
            this.gameObject.SetActive(true);
        }
        else Destroy(this.gameObject);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            GetComponent<Animator>().SetTrigger("TutorialDone");
        }
    }
}

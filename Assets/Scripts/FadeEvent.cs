using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEvent : MonoBehaviour
{
    public void EndDay()
    {
        SceneManager.LoadScene("EndOfDay");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackToGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _dayCount;

    // Start is called before the first frame update
    void Start()
    {
        _dayCount.text = FindDay();
        GetComponent<Animator>().SetTrigger("PlayDay");
    }

    public void NewDay()
    {
        if (FindDay() == "2") SceneManager.LoadScene("Ending");
        else SceneManager.LoadScene("StartOfDay");
    }

    private string FindDay()
    {
        if(FindObjectOfType<GameManager>())
        {
            return FindObjectOfType<GameManager>().Day.ToString();
        }
        else return("1");
    }
}

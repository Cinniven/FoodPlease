using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfDay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _dayCount;
    private int _endingDay = 4;


    // Start is called before the first frame update
    void Start()
    {
        _dayCount.text = FindDay();
        GetComponent<Animator>().SetTrigger("PlayDay");
    }

    public void NewDay()
    {
        if(!GameManager.Instance) SceneManager.LoadScene("StartOfDay");
        if (GameManager.Instance.Day == _endingDay) SceneManager.LoadScene("Ending");
        else if (GameManager.Instance.UnstampedPapers >= 3) SceneManager.LoadScene("Ending");
        else SceneManager.LoadScene("StartOfDay");
    }

    private string FindDay()
    {
        if(FindObjectOfType<GameManager>())
        {
            return GameManager.Instance.Day.ToString();
        }
        else return("1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paper : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private bool _yes = false, _no = false, _stamped = false, _special = false;
    [SerializeField] TextMeshProUGUI _title, _content;
    private int _karmaPoints = 1;
    [SerializeField] private string[] _text;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void SetPaper(TextAsset content, bool isSpecial)
    {
        if(content != null) _text = content.text.Split(" #END ");
        if(isSpecial) _special = true;

        _title.text = _text[0];
        _content.text = _text[1];
        _karmaPoints = int.Parse(_text[2]);
    }
    
    public void Yes()
    {
        Debug.Log("YES!");
        _stamped = true;
        _yes = true;
        _no = false;
    }

    public void No()
    {
        Debug.Log("NO!");
        _stamped = true;
        _no = true;
        _yes = false;
    }

    public void Deliver()
    {
        Animator paperAnim = gameObject.GetComponent<Animator>();
        paperAnim.SetTrigger("Deliver");
        gameObject.transform.GetChild(0).transform.parent = null;
        Destroy(this.gameObject, paperAnim.GetCurrentAnimatorStateInfo(0).length);
        if (_yes) _gameManager.PaperDelivered(_karmaPoints, _stamped, _special);
        else if (_no) _gameManager.PaperDelivered(-_karmaPoints, _stamped, _special);
        else _gameManager.PaperDelivered(-_karmaPoints * 2, _stamped, _special);
    }
}

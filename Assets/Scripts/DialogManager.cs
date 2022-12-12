using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private List<string> _dialog;
    [SerializeField] TextMeshProUGUI _dialogText;
    private bool _isTalking, _dialogStarted, _intro, _ending;
    private Animator _anim;

    void Awake()
    {
        _anim = FindObjectOfType<Animator>();
        if (SceneManager.GetActiveScene().name == "OpeningScene") _intro = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<GameManager>())
        {
            _dialog = null;
            _dialog = GameManager.Instance.Dialog;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_intro) Intro();
        if (!_dialogStarted) return;
        if (!Input.anyKeyDown) return;
        if (_dialog == null)
        {
            _anim.SetTrigger("DialogDone"); 
            return;
        }

        if(_isTalking && _dialog.Count != 0)
        {
            StopAllCoroutines();
            SetText(_dialog[0]);
        }
        else if (!_isTalking && _dialog.Count != 0)
        {
            StartCoroutine(Dialog(_dialog[0]));
        }
        else
        {
            _anim.SetTrigger("DialogDone");
        }

    }

    public void StartDialog()
    {
        _dialogStarted = true;
        if(_dialog == null) return;

        StartCoroutine(Dialog(_dialog[0]));
    }

    IEnumerator Dialog(string currentDialog)
    {
        _dialogText.text = null;
        _isTalking = true;
        foreach(char c in currentDialog)
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        _dialog.Remove(currentDialog);
        _isTalking = false;
    }
    
    private void SetText(string currentDialog)
    {
        _dialogText.text = currentDialog;
        _dialog.Remove(currentDialog);
        _isTalking = false;
    }

    public void NextScene()
    {
        if(_intro) SceneManager.LoadScene("EndOfDay");
        else if (_ending) SceneManager.LoadScene("Credits");
        else SceneManager.LoadScene("GameScene");
    }

    public void Intro()
    {
        if (_dialog.Count == 8) _anim.SetBool("Poverty", true);
        if (_dialog.Count == 7) _anim.SetBool("War", true);
        if (_dialog.Count == 6) _anim.SetBool("Disaster", true);
        if (_dialog.Count == 5) _anim.SetBool("Other", true);
    }

    public void Ending()
    {

    }
}

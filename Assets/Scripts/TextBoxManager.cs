using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;

    public TextMeshProUGUI theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    //public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split("\n");
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;

        }

    }

    private void Update()
    {
        theText.text = textLines[currentLine];

    }
}

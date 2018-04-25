using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialogController : MonoBehaviour {

    public Dialog[] englishDialogs;
    public Dialog[] spanishDialogs;

    private string[] dialogSentences;

    public float speedSentences;
    public float speedLetter;
    private float speedLetterCounter;

    public bool dialoging;
    // Update is called once per frame
    void Update () {
        if (dialoging)
        {
            UpdateDialogPosition();
            //RunShowDialogRoutine();
        }
	}

    public void StartDialog(int index)
    {
        //start the dialogs
        if (dialoging == false)
        {
            //dialogTextVisual = Instantiate(dialogTextVisual);
            LoadDialog(index);
            dialoging = true;
            ShowSentence();
        }
        
    }
    private int indexDialog;
    private void LoadDialog(int index)
    {
        indexDialog = index;
        if (PlayerPrefs.GetString("language") == "english")
        {
            dialogSentences = englishDialogs[indexDialog].sentences;
        }
        else
        {
            dialogSentences = spanishDialogs[indexDialog].sentences;
        }
        
    }

    

    public GameObject dialogTextVisual;
    private int indexSentence;
    private void ShowSentence()
    {
        dialogTextVisual.GetComponent<Text>().text = "";
        if (indexSentence < dialogSentences.Length)
        {
            StartCoroutine(PlayText(indexSentence));
            //dialogTextVisual.GetComponent<TextMesh>().text += dialogSentences[indexSentence];
            indexSentence++;
        }
        else
        {
            dialoging = false;
        }
        //
    }

    IEnumerator PlayText(int index)
    {
        foreach (char s in dialogSentences[index])
        {
            yield return new WaitForSeconds(speedLetter);
            dialogTextVisual.GetComponent<Text>().text += s.ToString();
        }
        yield return new WaitForSeconds(speedSentences);
        ShowSentence();
    }

    public void ChangeToDialog(int index)
    {
        indexDialog = index;
        indexSentence = 0;
        LoadDialog(index);
        dialoging = true;
        ShowSentence();
    }

    public Vector2 offsetDialogPosition;
    private void UpdateDialogPosition()
    {
        dialogTextVisual.transform.position = new Vector2(transform.position.x + offsetDialogPosition.x, transform.position.y + offsetDialogPosition.y);
    }
    
    public float GetDialogTime(int index)
    {
        float totalTime = englishDialogs[index].sentences.Length * speedSentences;
        for (int i = 0; i < englishDialogs[index].sentences.Length; i++)
        {
            totalTime += englishDialogs[index].sentences[i].Length * speedLetter;
        }
        return totalTime;
    }

}

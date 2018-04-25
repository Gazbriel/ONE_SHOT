using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameState : MonoBehaviour {

    public bool firstManTownInteract1;

    //Bartender
    public bool barTenderSpeech;
    public bool barTenderSpeechRichManAcusedHim;

    public bool cantEnterBar;

    //blond girl (amante)
    public bool blondGirlFirstWords;
    public bool blondGirlSpeech;

    //blond short hai woman (empresaria)
    public bool blondShortHairFirstWords;
    public bool blondShortHairSpeech;

    public bool blondShorHairTalkAboutTheRichMan;

    //the man outside
    public bool blonsShortHairAndRichManConflict;

    //the mafioso man
    public bool firstDialogMafiosoDone;

    //final scene
    public bool finalScene;

    public int GetProgress()
    {
        int progress = 0;
        if (firstManTownInteract1)
        {
            progress++;
        }
        if (barTenderSpeech)
        {
            progress++;
        }
        if (barTenderSpeechRichManAcusedHim)
        {
            progress++;
        }
        if (cantEnterBar)
        {
            progress++;
        }
        if (blondGirlFirstWords)
        {
            progress++;
        }
        if (blondGirlSpeech)
        {
            progress++;
        }
        if (blondShortHairFirstWords)
        {
            progress++;
        }
        if (blondShortHairSpeech)
        {
            progress++;
        }
        if (blondShorHairTalkAboutTheRichMan)
        {
            progress++;
        }
        if (blonsShortHairAndRichManConflict)
        {
            progress++;
        }
        if (firstDialogMafiosoDone)
        {
            progress++;
        }
        if (finalScene)
        {
            progress++;
        }

        return (int)(progress * 100 / 12);

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognizer : MonoBehaviour {
    KeywordRecognizer keywordRecognizerObj;
    public string[] Keywords_array;
    private Animator anim;
	// Use this for initialization
	void Start () {
        keywordRecognizerObj = new KeywordRecognizer(Keywords_array);
        keywordRecognizerObj.OnPhraseRecognized += OnkeywordsRecognized;
        keywordRecognizerObj.Start();
        anim = GetComponent<Animator>();
    }

    void OnkeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("keyword " + args.text + ";Confidence " + args.confidence);
        ActionPerformer(args.text);
    }

     void ActionPerformer(string text)
    {
        if (text.Contains("hit"))
            {
            anim.Play("Attack01", -1, 0f);
            }
        if (text.Contains("fall"))
            {

            anim.Play("Die", -1, 0f);
        }
    }
// Update is called once per frame
    void Update () {
		
	}
}

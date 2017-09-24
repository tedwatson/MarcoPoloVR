using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System.Collections.Generic;

public class speechRecognition : MonoBehaviour {

    public AudioSource audio;
    public gameController gc;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private void Start()
    {
        print("Start");
        // initialize
        keywords.Add("marco", () =>
        {
            MarcoCalled();
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        print("KeywordRecognizerOnPhraseRecognized");
        System.Action keywordAction;

        if(keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void MarcoCalled()
    {
        print("You just said MARCO");
        gc.InturruptAudio();
        audio.Play();
    }

}

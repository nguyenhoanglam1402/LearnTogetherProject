using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognisation : MonoBehaviour
{
  private KeywordRecognizer recognizer;
  public AudioClip[] audios;
  public ConfidenceLevel confidenceLevel = ConfidenceLevel.Medium;
  private Dictionary<string, string> conversations = new Dictionary<string, string>();
  [SerializeField]
  private string[,] messages = new string[,]{
      {"Hello", "Hi! How can I help you?"},
      {"I want to buy coffee", "Well, which one do you want to choose? Okey! Here you are!"},
      {"I'm sad", "Well, why are you sad?"},
  };

  void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
  {
    Debug.Log(args.text);
    Debug.Log(conversations[args.text]);
  }

  // Start is called before the first frame update
  void Start()
  {
      
    for (int row = 0; row < messages.Length / 2; row++)
    {
      conversations.Add(messages[row, 0], messages[row, 1]);
    }
    recognizer = new KeywordRecognizer(conversations.Keys.ToArray(), confidenceLevel);
    recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
    recognizer.Start();
  }



}

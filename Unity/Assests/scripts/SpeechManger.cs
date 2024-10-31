using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class SpeechManager : MonoBehaviour
{
    public string apiUrl = "http://localhost:5000/generate"; // Flask API URL
    public Animator animator; // Reference to the avatar's animator

    public void Speak(string prompt)
    {
        StartCoroutine(GenerateSpeech(prompt));
    }

    private IEnumerator GenerateSpeech(string prompt)
    {
        animator.SetBool("isSpeaking", true); // Start lip-sync animation

        // Create JSON data
        string jsonData = JsonUtility.ToJson(new { prompt });

        // Send request to Flask API
        using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, jsonData))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                // Handle the audio file
                string audioFilePath = "Assets/Audio/output.wav"; // Set your path
                File.WriteAllBytes(audioFilePath, www.downloadHandler.data);

                // Play the audio
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = LoadAudioClip(audioFilePath);
                audioSource.Play();

                // Stop lip-sync animation
                animator.SetBool("isSpeaking", false);
            }
        }
    }

    private AudioClip LoadAudioClip(string path)
    {
        // Load the audio clip from file
        WWW www = new WWW("file://" + path);
        while (!www.isDone) { }
        return www.GetAudioClip(false, true, AudioType.WAV);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Trigger speech on spacebar
        {
            Speak("What do you think about the future of space travel?");
        }
    }
}


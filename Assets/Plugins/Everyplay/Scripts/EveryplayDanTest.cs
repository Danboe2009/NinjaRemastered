using UnityEngine;
using System.Collections;

public class EveryplayDanTest : MonoBehaviour
{
	void Start ()
	{
		Everyplay.UploadDidComplete += Everyplay_UploadDidComplete;
		Everyplay.RecordingStarted += Everyplay_RecordingStarted;
		Everyplay.RecordingStopped += Everyplay_RecordingStopped;
		Everyplay.UploadDidStart += Everyplay_UploadDidStart;
	}

	void Everyplay_UploadDidStart (int videoId)
	{
		Debug.Log ("Upload has started.");
	}

	void Everyplay_RecordingStopped ()
	{
		Debug.Log ("Recording has stopped.");
	}

	void Everyplay_RecordingStarted ()
	{
		Debug.Log ("Recording has started.");
	}
		
	void Everyplay_UploadDidComplete (int videoId)
	{
		Debug.Log ("Finished Upload.");
		PlayerPrefs.SetInt("Diamonds", 5 + PlayerPrefs.GetInt("Diamonds"));
		PlayerPrefs.SetInt("TotalDiamonds", 5 + PlayerPrefs.GetInt("TotalDiamonds"));
	}
}
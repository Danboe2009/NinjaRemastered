using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ShowAds : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start ()
	{
		if (Advertisement.isSupported && !Advertisement.isInitialized) {
			Advertisement.Initialize("37275", false);
		}

		while (!Advertisement.isInitialized || !Advertisement.IsReady()) {
			yield return new WaitForSeconds(0.5f);
		}

		//Advertisement.Show ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Reward Ready: " + Advertisement.IsReady ("rewardedVideoZone"));
		//Debug.Log ("Default Ready: " + Advertisement.IsReady ("defaultZone"));
	}

	static public void Show(int count){
		if(count % 5 == 0)
		Advertisement.Show ();
	}
}

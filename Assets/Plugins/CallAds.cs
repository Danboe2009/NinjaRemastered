using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class CallAds : MonoBehaviour{

	public BannerView bannerView;

	void Start ()	{
		Debug.Log ("Started ads");
		if (PlayerPrefs.GetInt ("NoAds") == 0 && SceneManager.GetActiveScene().name != "GameLevel") {
			Debug.Log ("Requested Ad");
			RequestBanner ();
		}
	}

	void Update(){
		if (SceneManager.GetActiveScene ().name == "GameLevel") {
			if (bannerView != null) {
				bannerView.Hide ();
			}
		} else if(PlayerPrefs.GetInt ("NoAds") == 0) {
			if (bannerView != null) {
				bannerView.Show ();
			}
		}
	}
		
	private void RequestBanner ()	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-5009450596623359/2749965242";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView (adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ().Build ();
		// Load the banner with the request.
		bannerView.LoadAd (request);
	}
}

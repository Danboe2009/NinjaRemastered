#pragma strict

function Start () {
	if(PlayerPrefs.GetInt("FirstTime") == 0)
	{
		PlayerPrefs.SetInt("FirstTime", 1);
		SceneManager.LoadScene("GameLevel");
	}
	else
	{
		SceneManager.LoadScene("Menu");
	}
}

function Update () {
	
}

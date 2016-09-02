#pragma strict

function Start () 
{
	if(PlayerPrefs.GetInt("Level") == 29)
	{
		this.transform.GetComponent.<SpriteRenderer>().enabled = true;
	}
}

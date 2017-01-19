#pragma strict

var Top : TextMesh;
var Bot : TextMesh;

// Use this for initialization
function Start () 
{
	Top.text = ResultsLanguage.thisLanguageManager.GetTextValue ("Results.EveryTop");
	Bot.text = ResultsLanguage.thisLanguageManager.GetTextValue ("Results.EveryBot");
}

// Update is called once per frame
function Update () 
{
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	var hit : RaycastHit;

	if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Run");
			EveryplayScript.Share();

			//Kamcord.ShowView();
		}
	}
}


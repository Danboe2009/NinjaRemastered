#pragma strict

var CoinText : TextMesh;
var DiamText : TextMesh;



function Start () 
{
	Variables.Diamo = PlayerPrefs.GetInt("Diamonds");
}

function Update () 
{
	CoinText.text = Variables.Coins.ToString("f0"); //GameLanguage.thisLanguageManager.GetTextValue("Game.Coins") + " " + Variables.Coins.ToString("f0");
	DiamText.text = Variables.Diamo.ToString("f0"); //GameLanguage.thisLanguageManager.GetTextValue("Game.Diamonds") + " " + Variables.Diamo.ToString("f0");
}
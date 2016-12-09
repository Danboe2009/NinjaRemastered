#pragma strict

var text : TextMesh;

function Start () {
	text.text = "Version: " + PlayerPrefs.GetInt("Version");
} 

function Update () {
	
}

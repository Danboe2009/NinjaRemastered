#pragma strict

var Damag : GameObject;
var Tex : SpriteRenderer;

private var shown : boolean;
private var MLevel : int;
private var Castles : CastleGen;

Castles = GameObject.Find("CastleGenerator").GetComponent(CastleGen);

function Start () {
	MLevel = PlayerPrefs.GetInt("MinerLevel");
}

function FixedUpdate () {

	if(!Variables.Intro && !Variables.Tutorial && Castles.BlueHealth > 0 && Castles.PinkHealth > 0)
	{
		if(Tex.sprite.name == "Miner2s"){
		if(!shown){
			shown = true;
			var Dam = new Instantiate(Damag,Vector3(this.transform.position.x + 6,2,-4),Quaternion.Euler(0,0,0));
			Dam.GetComponent(Damage).Value =  (0.05f * MLevel * 60);
		}
	}
	else
	{
		shown = false;
	}
	}
}

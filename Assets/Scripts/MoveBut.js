#pragma strict
var Cube : GameObject;
var Dir : String;
var MoveTop : TextMesh;
var MoveBot : TextMesh;
var Sprite : SpriteRenderer;

private var Show : boolean;

function Start () 
{
	if(PlayerPrefs.GetInt("Tutorial") == 0)
	{
		Show = true;
	}
	else
	{
		Show = false;
	}
}	

function FixedUpdate () 
{
	if(Show)
	{
		MoveTop.text = GameLanguage.thisLanguageManager.GetTextValue("Game.MoveTop");
		MoveBot.text = GameLanguage.thisLanguageManager.GetTextValue("Game.MoveBot");
	}
	else
	{
		MoveTop.text = "";
		MoveBot.text = "";
	}
		
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    
    if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
    {
    	if(Input.GetButton("Fire1") && !Variables.Movement)
       	{
       		if(Show)
       		{
       			FadeOut(1);
       		}
	       	if(Dir == "Left")
	       	{
	       		Tutorial.Left = true;
				if(Cube.transform.position.x > -32)
				{
					Cube.transform.position.x --;
				}
			}
			if(Dir == "Right")
	       	{
	       		Tutorial.Right = true;
				if(Cube.transform.position.x < 32)
				{
					Cube.transform.position.x ++;
				}
			}
			Show = false;
		}
	}
}

function FadeOut (time : float) 
{
	var originalTime :float= time;
	while (time >= 0.0)
	{
	    time -= Time.deltaTime;
	    Sprite.color = Color.Lerp(Color(1,1,1,0), Color(1,1,1,1), time/originalTime);
	    yield;
	}
	Variables.Pause = false;
}
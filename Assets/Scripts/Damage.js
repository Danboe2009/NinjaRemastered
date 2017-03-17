#pragma strict

var ones : GameObject;
var tens : GameObject;
var huns : GameObject;
var plus : GameObject;
var nums : Sprite[];
var Value : int;
var type : String;

function Start () 
{
	FadeOut(1);
	tens.GetComponent(SpriteRenderer).color = Color(1,1,1,0);
	huns.GetComponent(SpriteRenderer).color = Color(1,1,1,0);
}

function Update () 
{
	if(ones.GetComponent(SpriteRenderer).color == Color(1,1,1,0))
	{
		Destroy(this.gameObject,0);
	}
	if(Value > 0)
	{
		ones.GetComponent(SpriteRenderer).sprite = nums[(Value%10)];
		ones.transform.localPosition.x = -5;
		if(Value > 9)
		{
			tens.GetComponent(SpriteRenderer).sprite = nums[((Value/10)%10)];
			tens.GetComponent(SpriteRenderer).color = Color(1,1,1,1);
			ones.transform.localPosition.x = -2.5;
			tens.transform.localPosition.x = -5;
		}
		else
		{
			tens.GetComponent(SpriteRenderer).color = Color(1,1,1,0);
		}
				
		if(Value > 99)
		{
			huns.GetComponent(SpriteRenderer).sprite = nums[Value/100];
			//huns.spriteId = huns.GetSpriteIdByName((Value/100).ToString());
			huns.GetComponent(SpriteRenderer).color = Color(1,1,1,1);
			ones.transform.localPosition.x = -0;
			tens.transform.localPosition.x = -2.5;
		}
		else
		{

			huns.GetComponent(SpriteRenderer).color = Color(1,1,1,0);
		}
	}
}

function FixedUpdate()
{
	//ones.tranform.localScale += Vector3(0.02,0.02,0);
	//ones.scale += Vector3(0.02,0.02,0);
	//tens.scale += Vector3(0.02,0.02,0);
	//huns.scale += Vector3(0.02,0.02,0);
	if(type == "Ninja")
	{
		GetComponent.<Rigidbody>().position += (Vector3.left * 2.5 * Time.deltaTime);
		GetComponent.<Rigidbody>().position += (Vector3.up * 2.5 * Time.deltaTime);
	}
	if(type == "Pirate")
	{
		GetComponent.<Rigidbody>().position += (Vector3.right * 2.5 * Time.deltaTime);
		GetComponent.<Rigidbody>().position += (Vector3.forward * 2.5 * Time.deltaTime);
	}
}

function FadeOut (time : float) 
{
	var originalTime :float= time;
	while (time >= 0.0)
	{
	    time -= Time.deltaTime;
	    ones.GetComponent(SpriteRenderer).color = Color.Lerp(Color(1,1,1,0), Color(1,1,1,1), time/originalTime);
	    plus.GetComponent(SpriteRenderer).color = Color.Lerp(Color(1,1,1,0), Color(1,1,1,1), time/originalTime);
	    if(Value > 9)
		{
	    	tens.GetComponent(SpriteRenderer).color = Color.Lerp(Color(1,1,1,0), Color(1,1,1,1), time/originalTime);
	    }
	    if(Value > 99)
		{
	    	huns.GetComponent(SpriteRenderer).color = Color.Lerp(Color(1,1,1,0), Color(1,1,1,1), time/originalTime);
	    }
	    yield;
	}
}
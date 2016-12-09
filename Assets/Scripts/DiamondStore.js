#pragma strict

var anim : GameObject;

private var open : boolean; 

function Start () {
	//Variables.InAppO = false;
}

function Update()
{
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    
    if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
    {
    	if(Input.GetButtonDown("Fire1"))
    	{
    		if(!Variables.InAppO)
    		{
	    		StartCoroutine("Open"); 
    		}
    		if(Variables.InAppO)
    		{
	    		StartCoroutine("Close"); 
    		}
    	}
    }
}

function Open()
{
	yield WaitForSeconds(0.2);
	Variables.InAppO = true;
	Variables.Pause = true;
	anim.GetComponent.<Animation>().Play("DiamondStoreIn");
}

function Close()
{
	yield WaitForSeconds(0.2);
	Variables.InAppO = false;
	Variables.Pause = false;
	anim.GetComponent.<Animation>().Play("DiamondStoreOut");
}
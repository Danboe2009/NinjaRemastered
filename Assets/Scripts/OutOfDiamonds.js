#pragma strict

var Box : GameObject;
var Type : String;
private var InApp : GameObject;

function Start () {
	Variables.Pause = true;
}

function Update () {
	
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    
    if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
    {
    	if(Input.GetButton("Fire1"))
       	{
       		
       		Variables.Pause = false;
       		if(Type == "Yes"){
       			Variables.InAppO = true;
       			Variables.Pause = true;
       			InApp = Instantiate(Resources.Load("InappStore"),Vector3(0,5,0),Quaternion.Euler(90,0,0));
       			InApp.GetComponent.<Animation>().Play("DiamondStoreIn");
       		}
       		else{

       		}
       		Destroy(Box,0);
       	}
    }
}

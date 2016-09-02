import UnityEngine.SceneManagement;
#pragma strict

var button : int;
var Pur : Purchaser;

function Update () 
{
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
   	var hit : RaycastHit;
   
   	if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
   	{
   		if(Input.GetButtonDown("Fire1"))
   		{
   			switch(button)
   			{
   				case 1:
   					Debug.Log("Number 1");
   					Pur.BuyItem("com.missingcontroller.ninjawarfare.10diamonds");
   					break;
   				case 2:
   					Debug.Log("Number 2");
   					Pur.BuyItem("com.missingcontroller.ninjawarfare.30diamonds");
   					break;
   				case 3:
   					Debug.Log("Number 3");
   					Pur.BuyItem("com.missingcontroller.ninjawarfare.125diamonds");
   					break;
   				case 4:
   					Debug.Log("Number 4");
   					Pur.BuyItem("com.missingcontroller.ninjawarfare.300diamonds");
   					break;
   				default:
   					break;
   			}
		}
	}
}
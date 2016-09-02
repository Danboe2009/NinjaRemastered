import UnityEngine.SceneManagement;
 
#pragma strict

function Start () 
{
	if(SceneManager.GetActiveScene().name == "Results")
	{
		StartCoroutine("ShowAd");
	}
}

function Update () 
{
//	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//	var hit : RaycastHit;
//    
//    if (collider.Raycast (ray, hit, 100)) 
//    {
//    	if(Input.GetButtonDown("Fire1"))
//       	{
//       		ChartBoost.Inter();
//       	}
//    }
}

//function ShowAd()
//{
//	ChartBoost.Inter();
//}
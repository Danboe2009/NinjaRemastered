#pragma strict

var Ting : AudioClip;
var anim : Animator;
var Type : String;
var Dia : SpriteRenderer;

private var ran : int;	
private var Coins : CoinGen;
private var CoinL : int;
private var Sound : int;
private var Moving : boolean;
private var Grow : boolean;
private var CoinB : GameObject;
private var timer : float;
private var playing : boolean;

Coins = GameObject.Find("BTopLeft").GetComponent(CoinGen);
CoinB = GameObject.Find("LeftBox");

function Start () 
{
	timer = 60.0;
	Sound = PlayerPrefs.GetInt("Sound");
	CoinL = PlayerPrefs.GetInt("CoinsLevel");
	Moving = false;
	if(Type == "Coin")
	{
		ran = Random.Range(0,100);	
		if(ran == 99)
		{
			//anim.Play("Coin");
			//Dia.transform.localScale = Vector3(1.05,1.05,1);
			anim.Play("Diamond");
			Type = "Diam";
		}
		if(ran < 99 && ran  > 89)
		{
			//anim.Play("Coin");

		}
		else
		{
			Dia.transform.localScale = Vector3(0.65,0.65,1);
		}
	}
	if(Type == "Diam")
	{
		anim.Play("Diamond");
		StartCoroutine("Diamond");
	}
	if(Variables.Debugger)
	{
		Moving = true;
	}
}

function Update () 
{
	if(Type == "Diam")
	{
		Debug.Log("Moving :" + Moving);
	}
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    
    if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
    {
    	if(Input.GetButtonDown("Fire1"))
       	{
       		if(Type == "Coin")
			{
				if(Sound)
	       		{
	       			AudioSource.PlayClipAtPoint(Ting, Camera.main.transform.position);
	       		}
	       		//Destroy(this.gameObject,0);
	       		Moving = true;
	       		
	       		
	       		PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins") + 1);
	       		GPG.AchievementAndSoItBegans();
	       		GPG.AchievementCoinCollector();
	       		GPG.AchievementCoinoisseur();
	       		GPG.AchievementMoneyHungry();
	       		GPG.AchievementCoinVault();
       		}
       		if(Type == "Diam")
			{
				if(Sound)
	       		{
	       			AudioSource.PlayClipAtPoint(Ting, Camera.main.transform.position);
	       		}
	       		//Destroy(this.gameObject,0);
	       		Moving = true;
			}
       	}
    }
    if(this.transform.position.z > 13 || this.transform.position.z < -13)
	{
		Destroy(this.gameObject,0);
		if(Type == "Coin")
		{
			if(ran < 99 && ran  > 89)
			{
				Coins.AddCoin(15 * CoinL);
			}
			else
			{
				Coins.AddCoin(7 * CoinL);
			}
		}
		if(Type == "Diam")
		{
			PlayerPrefs.SetInt("Diamonds", 1.0 + PlayerPrefs.GetInt("Diamonds"));
			PlayerPrefs.SetInt("TotalDiamonds", 1.0 + PlayerPrefs.GetInt("TotalDiamonds"));
			Variables.Diamo ++;
			GPG.AchievementOneCarat();
			GPG.AchievementFiveCarat();
			GPG.AchievementTenCarat();
			GPG.AchievementTwentyCarat();
		}
	}
}
function FixedUpdate()
{
	//Debug.Log("Timer: " + timer);
	if(Type == "Coin")
		{
		timer-= 0.1;
	    
	    if(timer < 20){
	    	if(!playing){
	    		playing = true;
	    		anim.Play("ShinyCoin");
	    	}
	    }
	    if(timer < 0){
	    	Destroy(this.gameObject);
	    }
    }
    if(Type == "Diam")
		{
		timer-= 0.1;
	    
	    if(timer < 20){
	    	if(!playing){
	    		playing = true;
	    		anim.Play("ShinyDiamond");
	    	}
	    }
	    if(timer < 0){
	    	Destroy(this.gameObject);
	    }
    }

    var step = 45 * Time.deltaTime;
	if(Moving)
    {
    	transform.position = Vector3.MoveTowards(transform.position, CoinB.transform.position, step);
    }
    if(Grow && Dia.transform.localScale.x < 1.5)
    {
    	//Dia.transform.localScale.x = Dia.transform.localScale.x + 0.1;
    	//Dia.transform.localScale.y = Dia.transform.localScale.y + 0.1;
    	
    	//Dia.scale.x = Dia.scale.x + 0.01;
    	//Dia.scale.y = Dia.scale.y + 0.01;
    }

}

function Diamond()
{
	//Grow = true;
	//yield WaitForSeconds(2);
	//Moving = true;
}

var Ting : AudioClip;
var Site : String;
var Tex : SpriteRenderer;
var Top : TextMesh;
var Bot : TextMesh;
var Textures : Sprite[];

private var Clicked : boolean;

function Start()
{
	StartCoroutine(Pausing());
}

function Update()
{
	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    
    if (GetComponent.<Collider>().Raycast (ray, hit, 100)) 
    {
    	if (Input.GetButtonDown("Fire1") && !Variables.Pause)
	    {
	    	if(!Clicked)
	    	{
	    		if(PlayerPrefs.GetInt("Sound") == 1)
	       		{
	       			AudioSource.PlayClipAtPoint(Ting, Camera.main.transform.position);
	       		}
	    		if(Site == "Facebook")
	    		{
	    			if(!PlayerPrefs.GetInt("VisitedFacebook"))
					{
						GPG.AchievementGameOn();
	    				PlayerPrefs.SetInt("VisitedFacebook",1);
	    				Tex.sprite = Textures[0];
	    				PlayerPrefs.SetInt("Diamonds", 1.0 + PlayerPrefs.GetInt("Diamonds"));
						PlayerPrefs.SetInt("TotalDiamonds", 1.0 + PlayerPrefs.GetInt("TotalDiamonds"));
	    			}
	    			Application.OpenURL("https://www.facebook.com/MissingController");
	    		}
	    		if(Site == "Twitter")
	    		{
	    			if(!PlayerPrefs.GetInt("VisitedTwitter"))
					{
						PlayerPrefs.SetInt("VisitedTwitter",1);
	    				Tex.sprite = Textures[0];
	    				PlayerPrefs.SetInt("Diamonds", 1.0 + PlayerPrefs.GetInt("Diamonds"));
						PlayerPrefs.SetInt("TotalDiamonds", 1.0 + PlayerPrefs.GetInt("TotalDiamonds"));
	    			}
	    			Application.OpenURL("https://twitter.com/NinjaWarGame");
	    		}
	    		if(Site == "Website")
	    		{
	    			if(!PlayerPrefs.GetInt("VisitedWebsite"))
					{
						PlayerPrefs.SetInt("VisitedWebsite",1);
	    				Tex.sprite = Textures[0];
	    				PlayerPrefs.SetInt("Diamonds", 1.0 + PlayerPrefs.GetInt("Diamonds"));
						PlayerPrefs.SetInt("TotalDiamonds", 1.0 + PlayerPrefs.GetInt("TotalDiamonds"));
	    			}
	    			Application.OpenURL("http://www.missingcontroller.com");
	    		}
	    		if(Site == "Rate") 
	    		{
	    			if(!PlayerPrefs.GetInt("VisitedRate"))
					{
						PlayerPrefs.SetInt("VisitedRate",1);
	    				PlayerPrefs.SetInt("Diamonds", 10.0 + PlayerPrefs.GetInt("Diamonds"));
						PlayerPrefs.SetInt("TotalDiamonds", 10.0 + PlayerPrefs.GetInt("TotalDiamonds"));
	    			}
	    			Application.OpenURL("https://play.google.com/store/apps/details?id=com.missingcontroller.ninjawarfare");
	    		}
	    		if(Site == "RateUs")
	    		{
	    			if(!PlayerPrefs.GetInt("VisitedRate"))
					{
						PlayerPrefs.SetInt("VisitedRate",1);
	    				//Tex.spriteId = //Tex.GetSpriteIdByName("RateUs");
	    				PlayerPrefs.SetInt("Diamonds", 10.0 + PlayerPrefs.GetInt("Diamonds"));
						PlayerPrefs.SetInt("TotalDiamonds", 10.0 + PlayerPrefs.GetInt("TotalDiamonds"));
	    			}
	    			Application.OpenURL("https://play.google.com/store/apps/details?id=com.missingcontroller.ninjawarfare");
	    		}
	    		if(Site == "Games")
	    		{
	    			Application.OpenURL("https://play.google.com/store/apps/developer?id=Missing+Controller");
	    		}

	    		Clicked = true;
	    		StartCoroutine(Reset());
	    	}
    	}
   	}
}

function Reset()
{
	yield WaitForSeconds(1);
	Clicked = false;
}

function Pausing()
{
	yield WaitForSeconds(0.1);
	if(Site == "Facebook")
	{
		if(PlayerPrefs.GetInt("VisitedFacebook"))
		{
			Tex.sprite = Textures[0];
		}
		if(!PlayerPrefs.GetInt("VisitedFacebook"))
		{
			Tex.sprite = Textures[1];
		}
	}
	if(Site == "Twitter")
	{
		if(PlayerPrefs.GetInt("VisitedTwitter"))
		{
			Tex.sprite = Textures[0];
		}
		if(!PlayerPrefs.GetInt("VisitedTwitter"))
		{
			Tex.sprite = Textures[1];
		}
	}
	if(Site == "Website")
	{
		if(PlayerPrefs.GetInt("VisitedWebsite"))
		{
			Tex.sprite = Textures[0];
		}
		if(!PlayerPrefs.GetInt("VisitedWebsite"))
		{
			Tex.sprite = Textures[1];
		}
	}
	if(Site == "RateUs")
	{
		if(!PlayerPrefs.GetInt("VisitedRate"))
		{
			Top.text = ResultsLanguage.thisLanguageManager.GetTextValue ("Results.RateTop");
			Bot.text = ResultsLanguage.thisLanguageManager.GetTextValue ("Results.RateBot");
		}
		if(PlayerPrefs.GetInt("VisitedRate"))
		{
			Top.text = ResultsLanguage.thisLanguageManager.GetTextValue ("Results.Thanks");
			Bot.text = "";
		}
	}
}

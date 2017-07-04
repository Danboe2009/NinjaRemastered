using UnityEngine;
using System;
using System.Collections;
using System.Globalization;
using SmartLocalization;
public class OutOFDiamondsLang : MonoBehaviour {

	public TextMesh Line1;
	public TextMesh Line2;
	public TextMesh Yes;
	public TextMesh No;

	public static LanguageManager thisLanguageManager;

	void Start () 
	{
		thisLanguageManager = LanguageManager.Instance;

		SmartCultureInfo systemLanguage = thisLanguageManager.GetDeviceCultureIfSupported ();
		if(thisLanguageManager.IsCultureSupported(systemLanguage))
		{
			thisLanguageManager.ChangeLanguage(systemLanguage);
			//thisLanguageManager.ChangeLanguage("ko-KR");
		}
		thisLanguageManager = LanguageManager.Instance;



		Line1.text = thisLanguageManager.GetTextValue ("Upgrades.NotEnoughDiamonds");
		Line2.text = thisLanguageManager.GetTextValue ("Upgrades.DoYouWant");
		Yes.text = thisLanguageManager.GetTextValue ("Menu.Yes");
		No.text = thisLanguageManager.GetTextValue ("Menu.No");
	}
}

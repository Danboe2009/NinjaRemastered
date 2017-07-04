using UnityEngine;
using System;
using System.Collections;
using System.Globalization;
using SmartLocalization;

public class InAppStoreLang : MonoBehaviour {

	public TextMesh Title;
	public TextMesh tenDiamonds;
	public TextMesh thirtyDiamonds;
	public TextMesh HundredDriamonds;
	public TextMesh ThreeDiamonds;
	public TextMesh MostPopular;
	public TextMesh BestValue;

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

		Title.text = thisLanguageManager.GetTextValue ("InApp.Title");
		tenDiamonds.text = thisLanguageManager.GetTextValue ("InApp.Ten");
		thirtyDiamonds.text = thisLanguageManager.GetTextValue ("InApp.Thirty");
		HundredDriamonds.text = thisLanguageManager.GetTextValue ("InApp.Hundred");
		ThreeDiamonds.text = thisLanguageManager.GetTextValue ("InApp.Three");
		MostPopular.text = thisLanguageManager.GetTextValue ("InApp.Most");
		BestValue.text = thisLanguageManager.GetTextValue ("InApp.Best");
	}
}

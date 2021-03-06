﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPG : MonoBehaviour {

	void Start()
	{
		GooglePlayGames.PlayGamesPlatform.Activate();

		Social.localUser.Authenticate((bool success) => {
			if (success) {
//				string token = GooglePlayGames.PlayGamesPlatform.Instance.GetToken();
//				Debug.Log("token: " + token);
			} else {
				
			}
		});
	}

	void Login(){
		
	}

	public static void LoadAchievements()
	{
		Social.ShowAchievementsUI ();
		Debug.Log ("Achievements");
	}

	public static void LoadHighscores()
	{
		Social.ShowLeaderboardUI ();
		Debug.Log ("High Score");
	}

	public static void AchievementGameOn()
	{
		Debug.Log ("Game On Sent");
		Social.ReportProgress("CgkI7PWMhvoCEAIQEQ", 100.0f, (bool success) => {
			Debug.Log("Game on: " + success); // handle success or failure
		});
	}

	public static void AchievementBattle()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQDw", 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	//Swordsman
	public static void AchievementSmallArmy()
	{
		PlayGamesPlatform.Instance.IncrementAchievement("CgkI7PWMhvoCEAIQEA", 1, (bool success) => {
			//success or failure
		}); 
	}
	public static void AchievementSliceDice()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQEg", 1, (bool success) => {
			//success or failure
		});
	} 
	public static void AchievementCentury()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQEw", 1, (bool success) => {
				//success or failure
		});
	}
	public static void AchievementNinjaSlasher()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQFA", 1, (bool success) => {
				//success or failure
		});
	}
	public static void AchievementSwordSwipes()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQFQ", 1, (bool success) => {
				//success or failure
		});
	}
	public static void AchievementNinjaGuiding()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQFg", 1, (bool success) => {
				//success or failure
		});
	}

	//Nunchuck
	public static void AchievementSpeedKills()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQFw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementCloseCombat()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQGA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSwiftPainful()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQGQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementQuickKiller()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQGg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementFastHands()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQGw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMach10()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQHA", 1, (bool success) => {
			//success or failure
		});
	}

	//Throwing Star
	public static void AchievementConcealed()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQHQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementThrowEm()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQHg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSharp()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQHw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementChucking()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQIA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementShuriken()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQIQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void Achievement6Pointed()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQIg", 1, (bool success) => {
			//success or failure
		});
	}

	//Longbow
	public static void AchievementArcher()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQIw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementLongRange()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQJA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementReadyAim()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQJQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementBowArrow()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQJg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementDistant()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQJw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementRobin()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQKA", 1, (bool success) => {
			//success or failure
		});
	}

	//WoodStaff
	public static void AchievementBlunt()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQKQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementThud()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQKg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSwatEm()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQKw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementWooden()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQLA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSmacking()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQLQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementTree()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQLg", 1, (bool success) => {
			//success or failure
		});
	}

	//Chain&Sickle
	public static void AchievementChain()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQLw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSickles()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQMA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementAttack()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQMQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementClose()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQMg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementChainEm()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQMw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementGrim()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQNA", 1, (bool success) => {
			//success or failure
		});
	}

	//Sai
	public static void AchievementStab()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQNQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMulti()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQNg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementBlunted()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQNw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMetal()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQOA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSaiYou()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQOQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMartial()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQOg", 1, (bool success) => {
			//success or failure
		});
	}

	//HandClaw
	public static void AchievementCombatant()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQOw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementFighter()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQPA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSlicing()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQPQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementTwoTalons()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQPg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementBreaking()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQPw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementClawWarrior()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQQA", 1, (bool success) => {
			//success or failure
		});
	}

	//Coins
	public static void AchievementAndSoItBegans()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQQQ",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementCoinCollector()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQQg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementCoinoisseur()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQQw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMoneyHungry()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQRA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementCoinVault()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQRQ", 1, (bool success) => {
			//success or failure
		});
	}

	//Diamonds
	public static void AchievementOneCarat()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQCQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementFiveCarat()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQCg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementTenCarat()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQCw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementTwentyCarat()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQDA", 1, (bool success) => {
			//success or failure
		});
	}

	//Kills
	public static void AchievementCzar()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQRg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementKing()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQRw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementDictator()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQSA", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSulton()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQSQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementMonarch()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQSg", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSoverign()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQSw", 1, (bool success) => {
			//success or failure
		});
	}

	//Swordsman
	public static void AchievementSharpening()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQTA",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementEdgeOfTheBlade()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQTQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSwordsMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQAQ", 1, (bool success) => {
			//success or failure
		});
	}

	//Nunchuck
	public static void AchievementSpeedItUp()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQTg",100.0f, (bool success) => {
				//success or failure
		});
	}
	public static void AchievementGettingQuicker()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQTw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementNunchuckMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQAw", 1, (bool success) => {
			//success or failure
		});
	}

	//ThrowingStar
	public static void AchievementPointy()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQUA",100.0f,  (bool success) => {
			//success or failure
		});
	}
	public static void AchievementPowerfulRage()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQUQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementThrowingStarMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQBA", 1, (bool success) => {
			//success or failure
		});
	}

	//Longbow
	public static void AchievementTestingFlight()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQUg",100.0f,  (bool success) => {
				//success or failure
		});
	}
	public static void AchievementIntermediateArcher()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQUw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementLongbowMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQBQ", 1, (bool success) => {
			//success or failure
		});
	}

	//Woodstaff
	public static void AchievementKnockOnWood()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQVA",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementJankaTest()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQVQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementWoodStaffMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQDQ", 1, (bool success) => {
			//success or failure
		});
	}

	//Chain&Sickle
	public static void AchievementChainGang()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQVg",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSickleWithIt()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQVw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementChainSickleMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQBg", 1, (bool success) => {
			//success or failure
		});
	}

	//Sai
	public static void AchievementBonSai()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQWA",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSaiAnora()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQWQ", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementSaiMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQBw", 1, (bool success) => {
			//success or failure
		});
	}

	//ClawMan
	public static void AchievementSharpeningMyClaws()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQWg",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementDualWield()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQWw", 1, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementHandClawMaster()
	{
		PlayGamesPlatform.Instance.IncrementAchievement ("CgkI7PWMhvoCEAIQCA", 1, (bool success) => {
			//success or failure
		});
	}

	//Unlocks
	public static void AchievementRecruiter()
	{
		if (PlayerPrefs.GetInt ("TotalUnlocks") == 2) {
			Social.ReportProgress ("CgkI7PWMhvoCEAIQXA", 100.0f, (bool success) => {
				//success or failure
			});
		}
	}
	public static void AchievementArmyBuilder()
	{
		if(PlayerPrefs.GetInt("TotalUnlocks") == 4)
		{
			Social.ReportProgress("CgkI7PWMhvoCEAIQXQ",100.0f, (bool success) => {
				//success or failure
			});
		}

	}
	public static void AchievementWarLord()
	{	
		if(PlayerPrefs.GetInt("TotalUnlocks") == 6)
		{
			Social.ReportProgress("CgkI7PWMhvoCEAIQXg",100.0f, (bool success) => {
				//success or failure
			});
		}
	}
	public static void AchievementFullPotential()
	{
		if(PlayerPrefs.GetInt("TotalUnlocks") == 8)
		{
			Social.ReportProgress("CgkI7PWMhvoCEAIQXw",100.0f, (bool success) => {
				//success or failure
			});
		}
	}

	//Levels
	public static void AchievementQuestStarter()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQYA",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementStickingWithIt()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQYQ",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementAdventurer()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQYg",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementJourneyMan()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQYw",100.0f, (bool success) => {
			//success or failure
		});
	}
	public static void AchievementRelentless()
	{
		Social.ReportProgress("CgkI7PWMhvoCEAIQZQ",100.0f, (bool success) => {
			//success or failure
		});
	}

	public static void AddScoreHighscore(long Score)
	{
		Social.ReportScore(Score, "CgkI7PWMhvoCEAIQDg", (bool success) => {
				// handle success or failure
		});						  
	}

	public static void AddLevelHighscore(long Level)
	{
		Social.ReportScore(Level,"CgkI7PWMhvoCEAIQaA", (bool success) => {
				// handle success or failure
		});						  
	}

	public static void AddKillsHighscore(long Kills)
	{
		Social.ReportScore(Kills,"CgkI7PWMhvoCEAIQZw",(bool success) => {
				// handle success or failure
		});						  
	}
}
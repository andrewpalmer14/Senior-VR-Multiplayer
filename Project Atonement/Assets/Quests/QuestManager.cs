using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;

public class QuestManager : MonoBehaviour {

	[Range (0.0f, 15.0f)]
	[SerializeField] float questGivingDistance = 5.0f;
	[SerializeField] RawImage questChatImage = null;
	[SerializeField] Text questCTAText = null;
	[SerializeField] Text questReponse1Text = null;
	[SerializeField] Text questReponse2Text = null;
	[SerializeField] Text questReponse3Text = null;
	[SerializeField] Image prideBackground = null;
	[SerializeField] Image wrathBackground = null;
	[SerializeField] Image slothBackground = null;
	[SerializeField] Image loveBackground = null;
	[SerializeField] Image greedBackground = null;
	[SerializeField] Image gluttonyBackground = null;
	[SerializeField] Image questProgressBackground = null;

	private GameObject questChatImageInstance = null;
	private GameObject questCTATextInstance = null;
	private GameObject questReponse1TextInstance = null;
	private GameObject questReponse2TextInstance = null;
	private GameObject questReponse3TextInstance = null;
	private GameObject prideBackgroundInstance = null;
	private GameObject wrathBackgroundInstance = null;
	private GameObject slothBackgroundInstance = null;
	private GameObject loveBackgroundInstance = null;
	private GameObject greedBackgroundInstance = null;
	private GameObject gluttonyBackgroundInstance = null;
	private GameObject questProgressBackgroundInstance = null;

	private Text userUiText;
	private Player player;
	private QuestGiver[] questGivers;
	private QuestGiver currentQuestGiver = null;
	private QuestGiver questGiverInChat = null;
	private bool inQuestChat = false;
	private bool inQuestCompletedChat = false;
	private string defaultText = "look around for people to help";

	// Use this for initialization
	void Start () {
		userUiText = GetComponentInChildren<Text>();
		userUiText.text = defaultText;
		questGivers = FindObjectsOfType<QuestGiver>();
		player = FindObjectOfType<Player>();
		if (player != null) {
			InstantiatePlayerUI();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = FindObjectOfType<Player>();
			if (player != null) {
				InstantiatePlayerUI();
			}
		} else {
			if (inQuestChat) {
				if (CrossPlatformInputManager.GetButton("Fire2")) {
					print("B option taken: Pride");
					questGiverInChat.StartQuest();
					questGiverInChat.PrideRouteTaken();
					player.IncreasePride(100);
					prideBackgroundInstance.GetComponentInChildren<Text>().text = player.GetPrideLvl().ToString();
					EndQuestChat();
				} else if (CrossPlatformInputManager.GetButton("Fire3")) {
					print("X option taken: Wrath");
					questGiverInChat.StartQuest();
					questGiverInChat.WrathRouteTaken();
					player.IncreaseWrath(100);
					wrathBackgroundInstance.GetComponentInChildren<Text>().text = player.GetWrathLvl().ToString();
					EndQuestChat();
				} else if (CrossPlatformInputManager.GetButton("Fire4")) {
					print("Y option taken: Sloth");
					questGiverInChat.StartQuest();
					questGiverInChat.SlothRouteTaken();
					player.IncreaseSloth(100);
					slothBackgroundInstance.GetComponentInChildren<Text>().text = player.GetSlothLvl().ToString();
					EndQuestChat();
				}
			}
			if (inQuestCompletedChat) {
				if (CrossPlatformInputManager.GetButton("Fire2")) {
					print("B option taken: Love");
					questGiverInChat.CompleteQuest();
					//questGiverInChat.LoveResponseTaken();
					player.IncreaseLove(350);
					loveBackgroundInstance.GetComponentInChildren<Text>().text = player.GetLoveLvl().ToString();
					EndQuestCompletedChat();
				} else if (CrossPlatformInputManager.GetButton("Fire3")) {
					print("X option taken: Greed");
					questGiverInChat.CompleteQuest();
					//questGiverInChat.GreedResponseTaken();
					player.IncreaseGreed(350);
					greedBackgroundInstance.GetComponentInChildren<Text>().text = player.GetGreedLvl().ToString();
					EndQuestCompletedChat();
				} else if (CrossPlatformInputManager.GetButton("Fire4")) {
					print("Y option taken: Gluttony");
					questGiverInChat.CompleteQuest();
					//questGiverInChat.GluttonyResponseTaken();
					player.IncreaseGluttony(350);
					gluttonyBackgroundInstance.GetComponentInChildren<Text>().text = player.GetGluttonyLvl().ToString();
					EndQuestCompletedChat();
				}
			}
			foreach (QuestGiver questGiver in questGivers) {
				if (questGiver != null) {
					questProgressBackgroundInstance.GetComponentInChildren<Text>().text = questGiver.GetQuestProgess();
					if ((questGiver.transform.position - player.transform.position).magnitude <= questGivingDistance) {
						currentQuestGiver = questGiver;
						if (!questGiver.QuestIsStarted()) {
							SetText(questGiver.SendQuestStartText());
							if (CrossPlatformInputManager.GetButton("Fire1")) {
								print("Quest Chat Started!");
								StartQuestChat(questGiver);
							}
						} else if (questGiver.QuestIsStarted() && !questGiver.QuestIsReadyToBeCompleted()) {
							SetText(questGiver.SendQuestBeganText());
						} else if (questGiver.QuestIsReadyToBeCompleted() && !questGiver.QuestIsCompleted()) {
							SetText(questGiver.SendQuestReadyToCompleteText());
							if (CrossPlatformInputManager.GetButton("Fire1")) {
								print("Quest Completed Chat Started!");
								StartQuestCompletedChat(questGiver);
							}
						} else if (questGiver.QuestIsCompleted()) {
							SetText(questGiver.SendQuestCompletedText());
						}
					}
				}
			}
			if (currentQuestGiver != null && (currentQuestGiver.transform.position - player.transform.position).magnitude > questGivingDistance) {
				currentQuestGiver = null;
				SetText(defaultText);
			}
		}
	}

	private void SetText(string uiText) {
		this.userUiText.text = uiText;
	}

	private void StartQuestChat(QuestGiver questGiver) {
		if (!inQuestChat) {
			questGiverInChat = questGiver;
			player.GetComponent<PlayerMovement>().StartQuestChat();
			questChatImageInstance = Instantiate(questChatImage, this.transform).gameObject;
			questCTAText.text = questGiver.QCTA();
			questCTATextInstance = Instantiate(questCTAText, this.transform).gameObject;
			questReponse1Text.text = questGiver.PrideR();
			questReponse2Text.text = questGiver.WrathR();
			questReponse3Text.text = questGiver.SlothR();
			questReponse1TextInstance = Instantiate(questReponse1Text, this.transform).gameObject;
			questReponse2TextInstance = Instantiate(questReponse2Text, this.transform).gameObject;
			questReponse3TextInstance = Instantiate(questReponse3Text, this.transform).gameObject;
			inQuestChat = true;
		}
	}

	private void StartQuestCompletedChat(QuestGiver questGiver) {
		if (!inQuestCompletedChat) {
			questGiverInChat = questGiver;
			player.GetComponent<PlayerMovement>().StartQuestChat();
			questChatImageInstance = Instantiate(questChatImage, this.transform).gameObject;
			questCTAText.text = questGiver.QGR();
			questCTATextInstance = Instantiate(questCTAText, this.transform).gameObject;
			questReponse1Text.text = questGiver.LoveR();
			questReponse2Text.text = questGiver.GreedR();
			questReponse3Text.text = questGiver.GluttonyR();
			questReponse1TextInstance = Instantiate(questReponse1Text, this.transform).gameObject;
			questReponse2TextInstance = Instantiate(questReponse2Text, this.transform).gameObject;
			questReponse3TextInstance = Instantiate(questReponse3Text, this.transform).gameObject;
			inQuestCompletedChat = true;
		}
	}

	private void EndQuestChat() {
		questGiverInChat = null;
		inQuestChat = false;
		Destroy(questChatImageInstance);
		Destroy(questCTATextInstance);
		Destroy(questReponse1TextInstance);
		Destroy(questReponse2TextInstance);
		Destroy(questReponse3TextInstance);
		player.GetComponent<PlayerMovement>().EndQuestChat();
	}

	private void EndQuestCompletedChat() {
		questGiverInChat = null;
		inQuestCompletedChat = false;
		Destroy(questChatImageInstance);
		Destroy(questCTATextInstance);
		Destroy(questReponse1TextInstance);
		Destroy(questReponse2TextInstance);
		Destroy(questReponse3TextInstance);
		player.GetComponent<PlayerMovement>().EndQuestChat();
	}

	private void InstantiatePlayerUI() {
		prideBackground.GetComponentInChildren<Text>().text = player.GetPrideLvl().ToString();
		prideBackgroundInstance = Instantiate(prideBackground, this.transform).gameObject;

		wrathBackground.GetComponentInChildren<Text>().text = player.GetWrathLvl().ToString();
		wrathBackgroundInstance = Instantiate(wrathBackground, this.transform).gameObject;

		slothBackground.GetComponentInChildren<Text>().text = player.GetSlothLvl().ToString();
		slothBackgroundInstance = Instantiate(slothBackground, this.transform).gameObject;

		loveBackground.GetComponentInChildren<Text>().text = player.GetLoveLvl().ToString();
		loveBackgroundInstance = Instantiate(loveBackground, this.transform).gameObject;

		greedBackground.GetComponentInChildren<Text>().text = player.GetGreedLvl().ToString();
		greedBackgroundInstance = Instantiate(greedBackground, this.transform).gameObject;

		gluttonyBackground.GetComponentInChildren<Text>().text = player.GetGluttonyLvl().ToString();
		gluttonyBackgroundInstance = Instantiate(gluttonyBackground, this.transform).gameObject;

		questProgressBackground.GetComponentInChildren<Text>().text = "No current objective";
		questProgressBackgroundInstance = Instantiate(questProgressBackground, this.transform).gameObject;
	}

	public void UpdatePrideText() {
		prideBackgroundInstance.GetComponentInChildren<Text>().text = player.GetPrideLvl().ToString();
	}

	public void UpdateWrathText() {
		wrathBackgroundInstance.GetComponentInChildren<Text>().text = player.GetWrathLvl().ToString();
	}

	public void UpdateSlothText() {
		slothBackgroundInstance.GetComponentInChildren<Text>().text = player.GetSlothLvl().ToString();
	}

	public void UpdateLoveText() {
		loveBackgroundInstance.GetComponentInChildren<Text>().text = player.GetLoveLvl().ToString();
	}

	public void UpdateGreedText() {
		greedBackgroundInstance.GetComponentInChildren<Text>().text = player.GetGreedLvl().ToString();
	}

	public void UpdateGluttonyText() {
		gluttonyBackgroundInstance.GetComponentInChildren<Text>().text = player.GetGluttonyLvl().ToString();
	}
}

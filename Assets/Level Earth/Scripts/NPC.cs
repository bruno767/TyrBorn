using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {


	[Header("Player and Canvas")]
	public GameObject Player;
	public GameObject canvas;

	[Header("NPC Dialogues",order=1)]
	[Tooltip("Change your NPC dialogues.")]
	[TextArea(3,10)]
	public string[] NpcTalks;
	[Tooltip("Change your Player dialogues.")]
	[TextArea(3,10)]
	public string[] UserTalks;
	[Tooltip("Change your NPC IDLE dialogues.")]
	[TextArea(3,10)]
	public string[] IdleNPCTalks;

	protected int[] talkingIndex; // Npc index, Player Index
	protected int talkingPerson; // 0 NPC, 1 Player

	[Header("Variables")]
	[Range(5,100)]
	public float triggerDistance;

	private bool npcAlreadyFinishedTalking, showDefaultMessage;
	private bool talking ;

    private AudioSource audioSource;

    public AudioClip[] player_clips;
    public AudioClip[] npc_clips;

    bool waitingToTalk;

    // Use this for initialization
    void Start () {
		showDefaultMessage = false;
		npcAlreadyFinishedTalking = false;
		talkingIndex = new int[2] { 0, 0 };
        audioSource = GetComponent<AudioSource>();
        waitingToTalk = false;
    }

	// Update is called once per frame
	void Update () {

		if (distance () < triggerDistance && !npcAlreadyFinishedTalking) {
			talking = true;
			// First we need to activate the canvas

			if (Input.GetKeyDown (KeyCode.U)) {
				talkingIndex [talkingPerson] += 1;
				talkingPerson = talkingPerson == 0 ? 1 : 0;
                waitingToTalk = false;
            }

			if (talkingIndex [0] >= NpcTalks.Length && talkingIndex [1] >= UserTalks.Length) {
				talking = false;
				npcAlreadyFinishedTalking = true;
			}

		} else if (distance () < triggerDistance){ 
			talking = false;
			showDefaultMessage = true;
		}
		else {
			talking = false;
			showDefaultMessage = false;
		}
	}


	// Calculate distance between NPC and Tim
	float distance(){

		Vector3 thispos = transform.position;
		Vector3 timpos = Player.transform.position;

		return Mathf.Sqrt (Mathf.Pow(timpos.x - thispos.x,2) + Mathf.Pow(timpos.y - thispos.y,2) + Mathf.Pow(timpos.z - thispos.z,2));
	}

	void OnGUI () {
		if (talking) {
			string text = talkingPerson == 0 ? NpcTalks [talkingIndex [0]] : UserTalks [talkingIndex [1]];

            GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 200f, 200f), text);
            if (!waitingToTalk)
            {
                audioSource.PlayOneShot(talkingPerson == 0 ? npc_clips[talkingIndex[0]] : player_clips[talkingIndex[1]]);
                waitingToTalk = true;
            }
        } else if (showDefaultMessage) {
			
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 200f, 200f), IdleNPCTalks[0]);
		}
	}
}
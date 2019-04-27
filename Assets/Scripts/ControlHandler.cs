using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHandler : MonoBehaviour
{
	
	public GameObject[] characters;
    // Start is called before the first frame update
    void Start()
    {
		//characters = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void ReplayActions(){
		MovePlayer player = (MovePlayer)FindCurrentPlayer();
		Rigidbody2D playerRigid = player.GetComponent<Rigidbody2D>();

		Debug.Log("Replay");
		playerRigid.velocity = Vector2.zero;
		player.transform.position = player.OriginalPos;
		player.FrameCount = 0;
		player.IsRecording = false;
		player.IsPlaying = true;
	}
	
	public void StartRecord(){
		ResetAll();
		//IsRecording = true;
	}
	
	public void StopRecord(){
		MovePlayer player = (MovePlayer)FindCurrentPlayer();
		//Rigidbody2D asd = player.GetComponent<Rigidbody2D>();

		player.IsRecording = false;
	}
	
	public void PlayRecord(){
		MovePlayer player = (MovePlayer)FindCurrentPlayer();
		Rigidbody2D playerRigid = player.GetComponent<Rigidbody2D>();

		player.IsPlaying = true;
		playerRigid.velocity = Vector2.zero;
		player.transform.position = player.OriginalPos;
		player.FrameCount = 0;
	}
	
	public void ResetRecord(){
		MovePlayer player = (MovePlayer)FindCurrentPlayer();
		Rigidbody2D playerRigid = player.GetComponent<Rigidbody2D>();

		player.IsPlaying = false;
		playerRigid.velocity = Vector2.zero;
		player.transform.position = player.OriginalPos;
		player.FrameCount = 0;
	}
	
	public void ResetAll(){
		MovePlayer player = (MovePlayer)FindCurrentPlayer();
		Rigidbody2D asd = player.GetComponent<Rigidbody2D>();
		asd.velocity = Vector2.zero;
		player.transform.position = player.OriginalPos;
		//player.rigidbody2D.velocity = Vector2.zero;
		//player.transform.position = OriginalPos;
		player.FrameCount = 0;
		player.IsRecording = false;
		player.IsActive = false;
		player.IsPlaying = false;
		player.ClearRecording();
		
		player.IsRecording = true;
	}
	
	MovePlayer FindCurrentPlayer(){
		characters = GameObject.FindGameObjectsWithTag("Player");
		for (int a = 0; a <= characters.Length; a++) {
			MovePlayer currentActor = characters[a].GetComponent<MovePlayer>();
			if (currentActor.isCurrentActivePlayer == true){
				return currentActor;
			}
		}
		return null;
	}
	
}

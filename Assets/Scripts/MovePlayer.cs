using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rigidbody2D;
	private BoxCollider2D playerCollider;
	private float input;
	private int facing = 1;
	private bool IsRecording = false;
	private bool IsPlaying = false;
	private bool IsActive = false;
	private int FrameCount = 0;
	public Vector2 OriginalPos;
	
	private List<bool[]> recording = new List<bool[]>();
	private bool[] BoolArr; // ORDER: RIGHT LEFT JUMP 
	
    // Start is called before the first frame update
    void Start()
    {
		rigidbody2D = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		gameObject.tag = "Player";
		OriginalPos = gameObject.transform.position;

		Debug.Log(recording.Count);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (IsRecording) {
			RecordActions();
			if (recording.Count > 0) {
				PlayActions(recording.Count - 1);
			}
		}
		if (IsPlaying) {
			if (FrameCount < recording.Count) {
				PlayActions(FrameCount);
				FrameCount++;
			} else {
				IsPlaying = false;
			}
		}
//		if (Input.GetButton("Fire1")) {
//			ReplayActions();
//		}
    }
	
	bool CastRayDown(){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.6f);
		if (hit.collider != null) {
			Debug.Log("JUMP");
			return true;
		} else {
			return false;
		}
	}
	
	void MoveLeft(){
			Vector2 VeloX = rigidbody2D.velocity;
			VeloX.x = -2 * speed;
			rigidbody2D.velocity = VeloX;		
	}
	
	void MoveRight(){
			Vector2 VeloX = rigidbody2D.velocity;
			VeloX.x = 2 * speed;
			rigidbody2D.velocity = VeloX;	
	}
	
	void MoveJump(){
			rigidbody2D.gravityScale = 2.5f;
			if (CastRayDown()) { 
				rigidbody2D.angularVelocity = 0;
				
				Vector2 VeloY = rigidbody2D.velocity;
				VeloY.y = speed * 4;
				rigidbody2D.velocity = VeloY;
			}
	}
	
	void MoveNoJump(){
		rigidbody2D.gravityScale = 5.0f;
	}
	
	void RecordActions(){
		BoolArr = new bool[3];
		
		if (Input.GetButton("Horizontal")) {				
			input = Input.GetAxisRaw("Horizontal") * speed;
			if (input > 0 ) {
				BoolArr[0] = true;
			} else {
				BoolArr[1] = true;
			}

		}
		if (Input.GetButton("Vertical")) {
			BoolArr[2] = true;
		}
		
		if (IsActive) {
			recording.Add(BoolArr);
		} else { 
			if (BoolArr[0] == true || BoolArr[1] == true || BoolArr[2] == true) {
				IsActive = true;
				recording.Add(BoolArr);
			}
		}
	}
	
	void PlayActions(int frameNum) {
		if (recording[frameNum][0] == true ) {
			MoveRight();
		}
		if (recording[frameNum][1] == true ) {
			MoveLeft();
		}
		if (recording[frameNum][2] == true ) {
			MoveJump();
		} else {
			MoveNoJump();
		}
	}
	
	void ReplayActions(){
		Debug.Log("Replay");
		rigidbody2D.velocity = Vector2.zero;
		gameObject.transform.position = OriginalPos;
		FrameCount = 0;
		IsRecording = false;
		IsPlaying = true;
	}
	
	public void StartRecord(){
		ResetAll();
		IsRecording = true;
	}
	
	public void StopRecord(){
		IsRecording = false;
	}
	
	public void PlayRecord(){
		IsPlaying = true;
		rigidbody2D.velocity = Vector2.zero;
		gameObject.transform.position = OriginalPos;
		FrameCount = 0;
	}
	
	public void ResetRecord(){
		IsPlaying = false;
		rigidbody2D.velocity = Vector2.zero;
		gameObject.transform.position = OriginalPos;
		FrameCount = 0;
	}
	
	public void ResetAll(){
		rigidbody2D.velocity = Vector2.zero;
		gameObject.transform.position = OriginalPos;
		FrameCount = 0;
		IsRecording = false;
		IsActive = false;
		IsPlaying = false;
		recording.Clear();
	}
	
    void OnApplicationQuit()
    {
        Debug.Log("Number of recorded frames " + recording.Count);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rigidbody2D;
	private BoxCollider2D playerCollider;
	private float input;
	public bool IsActive = false;
	public bool isCurrentActivePlayer = true;
	public int FrameCount = 0;
	public Vector2 OriginalPos;
	//public enum State {Sleep, Record, Play, Wait};
	private List<bool[]> recording = new List<bool[]>();
	private bool[] BoolArr; // ORDER: RIGHT LEFT JUMP

	private PlayerStateManager stateManager;
	
    // Start is called before the first frame update
    void Start()
    {
		rigidbody2D = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		gameObject.tag = "Player";
		OriginalPos = gameObject.transform.position;

		stateManager = GetComponentInParent<PlayerStateManager>();
		
		Debug.Log(recording.Count);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (stateManager.currentState == PlayerStateManager.State.Record) {
			RecordActions();
			if (recording.Count > 0) {
				PlayActions(recording.Count - 1);
			}
		}
		if (stateManager.currentState == PlayerStateManager.State.Play) {
			if (FrameCount < recording.Count) {
				PlayActions(FrameCount);
				FrameCount++;
			}
		}
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
	
	public void ResetAll(){
		rigidbody2D.velocity = Vector2.zero;
		gameObject.transform.position = OriginalPos;
		FrameCount = 0;
	}
	
	public void ClearRecording(){
		recording.Clear();
	}
	
    void OnApplicationQuit()
    {
        Debug.Log("Number of recorded frames " + recording.Count);
    }
}

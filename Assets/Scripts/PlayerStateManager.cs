using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // Start is called before the first frame update

	public enum State {Sleep, Record, Play, Wait};

    public State currentState;

    void Start()
    {
        currentState = State.Sleep;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    MovePlayer GetPlayer(){
        return this.GetComponentInChildren<MovePlayer>();
    }

    GameObject GetButton(string buttonName){
        //fix this to get correct component
        this.gameObject.transform.GetChild(0);
        return GameObject.Find(buttonName);
    }

    public void ChangeState(string stateStr){
        switch (stateStr){
            case "record":
                currentState = State.Record;
                var stopButton = GetButton("Stop Record");
                stopButton.transform.localPosition = new Vector3(0,70,0);
                break;
            case "stop":
                currentState = State.Wait;
                break;
            case "play":
                currentState = State.Play;
                break;
            case "rewind":
                currentState = State.Wait;
                break;
        }
        GetPlayer().ResetAll();
    }
}

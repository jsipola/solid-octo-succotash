using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RecordScript : MonoBehaviour
{
	public GameObject button;
	public UnityEvent OnClick = new UnityEvent();

	public enum Action {Record, StopRecord, Play, Reset};

	public Action Current_Action;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit Hit;
         
         if (Input.GetMouseButtonDown(0))
         {
             if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
             {
                 Debug.Log("Button Clicked");
                 OnClick.Invoke();
				 switch (Current_Action)
				 {
					case Action.Record:
						StartRecordChild();
						break;
					case Action.StopRecord:
						StopRecordChild();
						break;
					case Action.Play:
						PlayActionChild();
						break;
					case Action.Reset:
						RewindActionChild();
						break;
				 }
             }
         }
    }
	
	void StartRecordChild(){	
		GetComponentInParent<PlayerStateManager>().ChangeState("record");
		this.transform.position = new Vector3(0,0,0);
	}
	
	void StopRecordChild(){
		GetComponentInParent<PlayerStateManager>().ChangeState("stop");
	}
	
	void PlayActionChild(){
		GetComponentInParent<PlayerStateManager>().ChangeState("play");		
	}
	
	void RewindActionChild(){
		GetComponentInParent<PlayerStateManager>().ChangeState("rewind");
	}

	void MoveButton(){
		this.transform.position = new Vector3(0,0,0);
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RecordScript : MonoBehaviour
{
	public GameObject button;
	public UnityEvent OnClick = new UnityEvent();

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
				 StartRecordChild();
             }
         }
    }
	
	void StartRecordChild(){
		GameObject gamePlayer = button.transform.parent.gameObject;
		
		MovePlayer player = gamePlayer.GetComponentInChildren<MovePlayer>();
		
		player.StartRecord();
		
	}
}

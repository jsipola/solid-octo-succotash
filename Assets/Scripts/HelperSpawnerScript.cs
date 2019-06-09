using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperSpawnerScript : MonoBehaviour
{
		
	public MovePlayer helper;
	public GameObject master;
	public MakeButtonCombo buttons;
	public ActionButton button;
	public SimpleObjectPool buttonObjectPool;
	private List<MovePlayer> listOfPlayers = new List<MovePlayer>();
	private List<GameObject> listOfCubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
			listOfPlayers.Add(helper);
			listOfCubes.Add(master);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SpawnHelper(){
		helper.isCurrentActivePlayer = false;
		MovePlayer newHelper = (MovePlayer)Instantiate(helper, helper.OriginalPos, Quaternion.identity);
		newHelper.isCurrentActivePlayer = true;
		helper = newHelper; // replace old character with the newly created one
		listOfPlayers.Add(helper);

		//GameObject newButton = buttonObjectPool.GetObject();
		//ActionButton sampleButton = newButton.GetComponent<ActionButton>();
		
		// !!!
		//MakeButtonCombo newButtons = (MakeButtonCombo)Instantiate(buttons, buttons.originPos, Quaternion.identity);

	}
	
	public void RemoveHelper(){
		// remove current player
		//
		
		if (listOfPlayers.Count == 1) {
			return;
		}
		Destroy(listOfPlayers[listOfPlayers.Count - 1].gameObject);
		listOfPlayers.RemoveAt(listOfPlayers.Count - 1);
		// select the new player
		//
		helper = listOfPlayers[listOfPlayers.Count - 1];
		helper.isCurrentActivePlayer = true;
		//helper.IsCurrentActivePlayer = true;
	}

	public void CreateNewPlayerMaster(){
		// Create new Player & buttons
		//
		GameObject newMaster = (GameObject)Instantiate(master,master.transform.position + new Vector3(2,0,0), Quaternion.identity);
		listOfCubes.Add(newMaster);
		master = newMaster;
	}

	public void DeletePlayers(){
		// Delete Last created Player Assets
		//
		if (listOfCubes.Count == 1) {
			return;
		}
		Destroy(listOfCubes[listOfCubes.Count - 1]);
		listOfCubes.RemoveAt(listOfCubes.Count - 1);
		master = listOfCubes[listOfCubes.Count - 1];
	}

}

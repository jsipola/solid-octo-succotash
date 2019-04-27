using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperSpawnerScript : MonoBehaviour
{
		
	public MovePlayer helper;
	public MakeButtonCombo buttons;
	public ActionButton button;
	public SimpleObjectPool buttonObjectPool;
	private List<MovePlayer> listOfPlayers = new List<MovePlayer>();
    // Start is called before the first frame update
    void Start()
    {
		listOfPlayers.Add(helper);
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

		//GameObject newButton = buttonObjectPool.GetObject();
		//ActionButton sampleButton = newButton.GetComponent<ActionButton>();
		
		// !!!
		//MakeButtonCombo newButtons = (MakeButtonCombo)Instantiate(buttons, buttons.originPos, Quaternion.identity);

	}
	

}

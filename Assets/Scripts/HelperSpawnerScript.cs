using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperSpawnerScript : MonoBehaviour
{
		
	public MovePlayer helper;
	public ActionButton button;
	public SimpleObjectPool buttonObjectPool;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SpawnHelper(){
		MovePlayer newHelper = (MovePlayer)Instantiate(helper, helper.OriginalPos, Quaternion.identity);
		GameObject newButton = buttonObjectPool.GetObject();
		ActionButton sampleButton = newButton.GetComponent<ActionButton>();

	}
	

}

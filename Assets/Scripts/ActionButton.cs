using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {
    
    public Button buttonComponent;

    
    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener (HandleClick);
    }
    
    
    public void HandleClick()
    {
		Debug.Log("Buuttoon");
        //scrollList.TryTransferItemToOtherShop (item);
    }
}
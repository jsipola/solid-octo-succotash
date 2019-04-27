using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButtonCombo : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_RecordButton, m_StopRecButton, m_PlayButton, m_SpawnButton, m_ResetButton;
	public Vector3 originPos = new Vector3(0,0,0);

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
		originPos = m_RecordButton.transform.position;
        //m_RecordButton.onClick.AddListener(TaskOnClick);
		m_RecordButton.onClick.AddListener(() => HideButton(0));
		//m_RecordButton.onClick.AddListener(() => HideButton(2));

        //m_YourSecondButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
		m_StopRecButton.onClick.AddListener(() => HideButton(1));
		//m_StopRecButton.onClick.AddListener(() => HideButton(0)); // turha
/*
        m_RecordButton.onClick.AddListener(() => ButtonClicked(42));
		m_PlayButton.onClick.AddListener(() => ButtonClicked(43));
		m_ResetButton.onClick.AddListener(() => ButtonClicked(44));
		m_StopRecButton.onClick.AddListener(() => ButtonClicked(45));
*/	
        //m_YourThirdButton.onClick.AddListener(TaskOnClick);
		m_PlayButton.onClick.AddListener(() => HideButton(2));
		//m_PlayButton.onClick.AddListener(() => HideButton(1)); // turha
		
		m_ResetButton.onClick.AddListener(() => HideButton(3));
		
		m_SpawnButton.onClick.AddListener(() => HideButton(4));
		
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
	
	void HideButton(int NumOfButton) {
		switch (NumOfButton) {
			case 0:
				m_RecordButton.transform.position = new Vector3(0,0,0);
				m_StopRecButton.transform.position = originPos;
				//m_YourThirdButton.GetComponentInChildren<Text>().text = "asdasd";
				break;
			case 1:
				m_StopRecButton.transform.position = new Vector3(0,0,0);
				m_PlayButton.transform.position = originPos;
				break;
			case 2:
				m_PlayButton.transform.position = new Vector3(0,0,0);
				m_ResetButton.transform.position = originPos;
				break;
			case 3:
				m_ResetButton.transform.position = new Vector3(0,0,0);
				m_RecordButton.transform.position = originPos;
				break;
			case 4:
				m_StopRecButton.transform.position = new Vector3(0,0,0);
				m_ResetButton.transform.position = new Vector3(0,0,0);
				m_PlayButton.transform.position = new Vector3(0,0,0);
				originPos += new Vector3(150,0,0);
				m_RecordButton.transform.position = originPos;
				m_SpawnButton.transform.position += new Vector3(150,0,0);
				break;
		}
	}
	
	
}

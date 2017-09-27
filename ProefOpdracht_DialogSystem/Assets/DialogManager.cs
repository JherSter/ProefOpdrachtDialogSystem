using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	private XMLparser _xml;
	[SerializeField]private Text _question, _name, _answers;
	private Dropdown _dropdown;
	private bool _answered;
	
	
	
	


	private void Start()
	{
		_xml = GameObject.FindGameObjectWithTag("XmlParser").GetComponent<XMLparser>();
		_dropdown = GetComponentInChildren<Dropdown>();
		


	}

	private void Update()
	{
		switch (_dropdown.value)
		{
				
					case 0:
						if (!_answered)
						{
							NpcDailogue(1,0);
							
						}
						
						break;
					case 1:
						
						if (!_answered)
						{
							NpcDailogue(0,1);
							
						}
						
						break;
				
			default:
				break;
		}


		if (!Input.GetKeyDown(KeyCode.Alpha1)) return;
		_answered = true;
		Yesanswer();
		
		if (!Input.GetKeyDown(KeyCode.Alpha2)) return;
		_answered = true;
		NoAnswer();
	}

	private void Yesanswer()
	{
		_answers.text = _xml.Answers;
		
	}
	private void NoAnswer()
	{
		_answers.text = _xml.Farwell;
		
	}

	private void NpcDailogue(int value1, int value2)
	{
		
		_xml.PageNume = value1;
		_xml.Interation = value2;
		_name.text = _xml.NameOfNpc;
		_question.text = _xml.Dialog;
		print(_answered);
	}

	
}

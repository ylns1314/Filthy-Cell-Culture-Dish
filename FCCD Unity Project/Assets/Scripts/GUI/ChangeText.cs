//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;
public class ChangeText : MonoBehaviour {
	Text instruction;
	
	void Start()
	{
		instruction = GetComponent<Text>();
	}
	
	public void ChangeMyText(string NewText)
	{
		Debug.Log (instruction.name);
		instruction.text=NewText;
	}
}


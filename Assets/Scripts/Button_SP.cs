using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_SP : MonoBehaviour
{
	[SerializeField] private GameObject[] levels;
	
	void Start() 
	{
		Close();
	}
	
	public void Open()
	{
		for (int i = 0; i < levels.Length; i++)
		{
			levels[i].SetActive(true);
		}
	}

	public void Close()
	{
		for (int i = 0; i < levels.Length; i++)
		{
			levels[i].SetActive(false);
		}
	}
}

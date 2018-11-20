using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
	public ElementPanel elementPrefab;

	public Transform perentTranform;

	public List<ElementPanel> initElements;

	public Text balance;

	public Text winValue;

	public Button goGame;

	public int valuePanel = 5;

	private void Start()
	{
		for (int i = 0; i < valuePanel; i++)
		{
			initElements.Add(Instantiate(elementPrefab, perentTranform));
		}

		goGame.onClick.AddListener(GoGame);
	}

	private void GoGame()
	{
		for(int i = 0; i < initElements.Count; i++)
		{
			initElements[i].thisText.text = RandomValue().ToString();
		}
	}

	private int RandomValue()
	{
		int random;

		random = UnityEngine.Random.Range(1, 10);

		return random;
	}
}

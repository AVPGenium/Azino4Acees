using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
	public ElementPanel elementPrefab;

	public Transform perentTranform;

	public List<ElementPanel> initElements;

	public int valuePanel = 5;

	private void Start()
	{
		for (int i = 0; i < valuePanel; i++)
		{
			initElements.Add(Instantiate(elementPrefab, perentTranform));
		}
	}
}

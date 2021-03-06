﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageLibrary : MonoBehaviour
{
	//Keeping track of the page
	public int currentPage = 0;
	public GameObject[] pageIncrease;
	public GameObject[] pageDecrease;
	public GameObject[] totalPages;
	public int pageCount = 0;
	public int arraySize;

	//Parameters for the raycast
	private Transform _raycaster;
	public string doorTag = "Door"; //TODO: Add 'Door' to the tag list once all changes get pushed to repo, currently using placeholder in testing scene
	float length = 100; //Length of the raycast from camera

	//Debugging the raycast
	public Material highlightMaterial;
	public Material defaultMaterial;

	//Debugging the while loops
	public GameObject[] debugObjects;

	// Start is called before the first frame update
	void Start()
	{
		int arraySize = pageIncrease.Length;
		while (pageCount < arraySize)
		{
			pageIncrease[pageCount].AddComponent<AddInteractScript>();
			pageDecrease[pageCount].AddComponent<AddInteractScript>();
			++pageCount;
			print(pageCount);
		}
	}


	// Update is called once per frame
	void Update()
	{
		if (_raycaster != null)
		{
			var selectionRenderer = _raycaster.GetComponent<Renderer>();
			selectionRenderer.material = defaultMaterial;
			_raycaster = null;
		}
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, length))
		{
			var selection = hit.transform;
			if (selection.CompareTag(doorTag))
			{
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material = highlightMaterial; //currently not set up to change colour back
					if (Input.GetMouseButtonDown(0))
					{
						
						if (hit.transform.gameObject == pageIncrease[currentPage])
						{
							Invoke("Increase", 0);
						}
						if (hit.transform.gameObject == pageDecrease[currentPage])
						{
							Invoke("Decrease", 0);
						}
					}
				}
				_raycaster = selection;
			}
		}
		while (currentPage == 0)
		{
			debugObjects[currentPage].SetActive(true);
		}
		while (currentPage == 1)
		{
			debugObjects[currentPage].SetActive(true);
		}
		while (currentPage == 2)
		{
			debugObjects[currentPage].SetActive(true);
		}
	}


	//Increase and Decrease are so that only specific doors register, and assign a specific page number for, for example, setting a certain page as active
	//Increase: It is set to increase the currentPage count
	public void Increase()
		{
			currentPage ++;
			print(currentPage);
		}

	//Decrease: It is set to decrease the currentPage count
	public void Decrease()
	{
		if (currentPage > 0)
		{
			currentPage --;
			print(currentPage);
		}
	}
}

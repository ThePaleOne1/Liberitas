using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTabTest : MonoBehaviour
{
	[SerializeField] private Material highlightMaterial;
	float length = 100;
	float distance = 2;
	[SerializeField] private string yellowTag = "yellow";
	[SerializeField] private string pinkTag = "pink";
	private Transform _potato;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private GameObject Tab;
	private bool startedSwitch = false;

	// Start is called before the first frame update
	void Start()
    {
		
    }

	// Update is called once per frame
	void Update()
	{
		if (_potato != null)
		{
			var selectionRenderer = _potato.GetComponent<Renderer>();
			selectionRenderer.material = defaultMaterial;
			_potato = null;
		}
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, length))
		{
			var selection = hit.transform;
			if (selection.CompareTag(yellowTag))
			{
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown(0))
					{
						if (startedSwitch == false)
						{
							Debug.Log("Pulled Out");
							hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
							Invoke("pink", 0.4f);
							startedSwitch = true;
						}
					}
				}
				_potato = selection;
			}
			if (selection.CompareTag(pinkTag))
			{
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown(0))
					{
						if (startedSwitch == false)
						{
							Debug.Log("Pulled In");
							hit.transform.Translate(Vector3.right * Time.deltaTime * distance);
							Invoke("yellow", 0.4f);
							startedSwitch = true;
						}
					}
				}
				_potato = selection;
			}
		}
	}

	void pink()
	{
		Tab.tag = pinkTag;
		startedSwitch = false;
	}

	void yellow()
	{
		Tab.tag = yellowTag;
		startedSwitch = false;
	}

}

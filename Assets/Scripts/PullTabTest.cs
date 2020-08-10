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
	[SerializeField] private GameObject TabOne;
	[SerializeField] private GameObject TabTwo;
	[SerializeField] private GameObject TabThree;
	[SerializeField] private Animator Bridge;
	[SerializeField] private Animator Flower;
	private bool startedSwitchOne = false;
	private bool startedSwitchTwo = false;
	private bool startedSwitchThree = false;


	Animator anim;

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
						if (hit.transform.gameObject == TabOne)
						{
							if (startedSwitchOne == false)
							{
								Debug.Log("Pulled Out");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", true);
								//hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
								Invoke("pinkOne", 0.4f);
								startedSwitchOne = true;
							}
						}
						if (hit.transform.gameObject == TabTwo)
						{
							if (startedSwitchTwo == false)
							{
								Debug.Log("Pulled Out");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", true);
								//hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
								Invoke("pinkTwo", 0.4f);
								startedSwitchTwo = true;
								Flower.SetBool("WaterTheOdds", true);
							}
						}
						if (hit.transform.gameObject == TabThree)
						{
							if (startedSwitchThree == false)
							{
								Debug.Log("Pulled Out");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", true);
								//hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
								Invoke("pinkThree", 0.4f);
								startedSwitchThree = true;
								Bridge.SetBool("IsPulled", true);
							}
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
						if (hit.transform.gameObject == TabOne)
						{
							if (startedSwitchOne == false)
							{
								Debug.Log("Pulled In");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", false);
								//hit.transform.Translate(Vector3.right * Time.deltaTime * distance);
								Invoke("yellowOne", 0.4f);
								startedSwitchOne = true;
							}
						}
						if (hit.transform.gameObject == TabTwo)
						{
							if (startedSwitchTwo == false)
							{
								Debug.Log("Pulled Out");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", false);
								//hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
								Invoke("yellowTwo", 0.4f);
								startedSwitchTwo = true;
								Flower.SetBool("WaterTheOdds", false);
							}
						}
						if (hit.transform.gameObject == TabThree)
						{
							if (startedSwitchThree == false)
							{
								Debug.Log("Pulled Out");
								anim = hit.transform.gameObject.GetComponent<Animator>();
								anim.SetBool("IsPulled", false);
								//hit.transform.Translate(Vector3.left * Time.deltaTime * distance);
								Invoke("yellowThree", 0.4f);
								startedSwitchThree = true;
								Bridge.SetBool("IsPulled", false);
							}
						}
					}
				}
				_potato = selection;
			}

		}
	}

	void pinkOne()
	{
		TabOne.tag = pinkTag;
		startedSwitchOne = false;
	}

	void yellowOne()
	{
		TabOne.tag = yellowTag;
		startedSwitchOne = false;
	}
	void pinkTwo()
	{
		TabTwo.tag = pinkTag;
		startedSwitchTwo = false;
	}

	void yellowTwo()
	{
		TabTwo.tag = yellowTag;
		startedSwitchTwo = false;
	}
	void pinkThree()
	{
		TabThree.tag = pinkTag;
		startedSwitchThree = false;
	}

	void yellowThree()
	{
		TabThree.tag = yellowTag;
		startedSwitchThree = false;
	}
}

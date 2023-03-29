using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{
	public Text TextonValue;

	private void Start()
	{
		TextonValue.text = ConstantManagerScript.Instance.Value.ToString();
	}

	public void GoToFirstScene()
	{
		SceneManager.LoadScene("SampleScene");
		ConstantManagerScript.Instance.Value++;
	}

	public void GoToSecondScene()
	{
		SceneManager.LoadScene("Scene2");
		ConstantManagerScript.Instance.Value++;
	}

}

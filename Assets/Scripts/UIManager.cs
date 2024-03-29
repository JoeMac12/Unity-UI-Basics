using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public Image key;

	public Slider redSlider;
	public Slider greenSlider;
	public Slider blueSlider;
	public Slider alphaSlider;
	public Image targetImage;
	public TextMeshProUGUI visibilityText;

	public TextMeshProUGUI option;

	public TMP_InputField nameInputField;
	public TextMeshProUGUI nameText;

	private int score = 0;

	void Start()
	{
		UpdateScoreDisplay();
		UpdateColor();
		UpdateNameText();
		UpdateVisibilityText();
	}

	public void ModifyScore(int change) // Main method
	{
		if (change == 0) // Reset score if chance is 0
		{
			score = 0;
		}
		else
		{
			long limitScore = (long)score + change; // Use long for overflow

			if (limitScore < -999999999)
			{
				score = -999999999;
			}
			else if (limitScore > 999999999)
			{
				score = 999999999;
			}
			else
			{
				score = (int)limitScore;
			}
		}

		UpdateScoreDisplay();
	}

	public void AddRandomScore() // Random score method
	{
		int randomScore = Random.Range(-999999999, 999999999);
		ModifyScore(randomScore);
	}

	private void UpdateScoreDisplay()
	{
		scoreText.text = score.ToString();
	}

	public void ToggleImageVisibility() // Toggle key image
	{
		if (key != null)
		{
			key.enabled = !key.enabled;
			UpdateVisibilityText();
		}
	}

	private void UpdateVisibilityText() // Change text based on image state
	{
		if (key.enabled)
		{
			visibilityText.text = "Hide Key";
		}
		else
		{
			visibilityText.text = "Show Key";
		}
	}

	public void QuitGame() // Quit
	{
		Application.Quit();
	}

	public void UpdateColor() // Change color of image
	{
		Color newColor = new Color(redSlider.value, greenSlider.value, blueSlider.value, alphaSlider.value);
		targetImage.color = newColor;
	}

	public void UpdateNameText() // Input Field for name
	{
		nameText.text = "Welcome: " + nameInputField.text;
	}

	public void ChooseColor(int val) // Dropdown for changing title color
	{
		if (val == 0)
		{
			option.color = Color.red;
		}
		if (val == 1)
		{
			option.color = Color.green;
		}
		if (val == 2)
		{
			option.color = Color.yellow;
		}
	}
}

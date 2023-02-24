using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIdata : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _losePanel;

    private int _score;
    private float _minutes;
    private float _seconds;
    private bool _lost = false;

    [HideInInspector] public int health;

    private void Update()
    {
        if (!_lost)
        {
            _minutes = (int)(Time.timeSinceLevelLoad / 60f);
            _seconds = (int)(Time.timeSinceLevelLoad % 60f);
            UpdateText();
        }
    }
    public void Reset()
    {
        _score = 0;
        health = 3;
        UpdateText();
    }

    public void Increment()
    {
        _score++;
        UpdateText();
    }

    public void LoseHealth()
    {
        health--;
        UpdateText();

        if (health == 0)
        {
            _losePanel.SetActive(true);
            _lost = true;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Scene");
    }

    private void UpdateText()
    {
        _text.text = $"Meteorites destroyed {_score}\nTime {_minutes:00}:{_seconds:00}\nLifes {health}";
    }
}

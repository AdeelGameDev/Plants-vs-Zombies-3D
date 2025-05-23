using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private RectTransform pausedUI;
    private bool isPaused = false;
    private AudioSource[] allAudioSources;

    void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
        allAudioSources = FindObjectsOfType<AudioSource>();
        pausedUI.gameObject.SetActive(false); // Ensure paused UI starts hidden
        UpdatePauseText();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausedUI.gameObject.SetActive(isPaused); // Show/hide paused UI

        foreach (var audio in allAudioSources)
        {
            if (isPaused)
                audio.Pause();
            else
                audio.UnPause();
        }

        UpdatePauseText();
    }

    private void UpdatePauseText()
    {
        pauseText.text = isPaused ? "UnPause" : "Pause";
    }
}

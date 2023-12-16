using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    private bool _isOpenPanel;
    private float _pause = 0;
    private float _start = 1;

    public void ChangeState(GameObject panel)
    {
        _isOpenPanel = panel.activeSelf;
        Debug.Log(_isOpenPanel);

        if (_isOpenPanel)
            Close(panel);
        else
            Open(panel);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Open(GameObject panel)
    {
        panel.SetActive(true);

        Time.timeScale = _pause;

    }

    private void Close(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = _start;

    }
}

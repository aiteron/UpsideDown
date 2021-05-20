using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreSettings : MonoBehaviour
{
    public void ClearScore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void Unselect()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}

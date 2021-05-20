using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private Sprite fullStar;
    
    void Start()
    {
        var star1 = transform.Find("Star1");
        var star2 = transform.Find("Star2");
        var star3 = transform.Find("Star3");

        if (PlayerPrefs.HasKey(levelName + "Score"))
        {
            int score = PlayerPrefs.GetInt(levelName + "Score");
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);

            if (score >= 1)
            {
                star1.GetComponent<Image>().sprite = fullStar;
            }
            if (score >= 2)
            {
                star2.GetComponent<Image>().sprite = fullStar;
            }
            if (score == 3)
            {
                star3.GetComponent<Image>().sprite = fullStar;
            }
        }
    }
}

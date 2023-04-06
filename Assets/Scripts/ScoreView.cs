using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI view;

    // Update is called once per frame
    private void Update()
    {
        this.view.text = Score.GetScore().ToString("F2");
    }
}

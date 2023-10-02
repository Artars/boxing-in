using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public string youWin;
    public string youLost;

    public TMPro.TMP_Text result;
    public TMPro.TMP_Text point;
    public TMPro.TMP_Text time;

    public void SetFinalScreen(bool win, float point, float time)
    {
        result.text = win ? youWin : youLost;
        this.point.text = point.ToString("F0");
        this.time.text = time.ToString("F2");

        if(win)
        {
            AudioManager.instance.PlaySound("Win");
        }
        else
        {
            AudioManager.instance.PlaySound("GameOver");
        }
    }
}

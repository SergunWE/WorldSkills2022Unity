using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCheck : MonoBehaviour
{
    [SerializeField] private FloatVariable playerHP;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioListener audioListener;

    private void FixedUpdate()
    {
        if(playerHP.Value < 0)
        {
            gameOverPanel.SetActive(true);
            audioListener.enabled = false;
        }
    }
}

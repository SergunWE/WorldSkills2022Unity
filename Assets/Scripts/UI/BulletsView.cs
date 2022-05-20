using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletsView : MonoBehaviour
{
    [SerializeField] private BulletManager bulletManager;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = bulletManager.ClipBullet + "/" + bulletManager.MaxBullet;
    }
}

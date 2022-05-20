using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMaker : MonoBehaviour
{
    [SerializeField] private Image[] marker;
    void Start()
    {
        foreach (var item in marker)
        {
            item.color = Color.clear;
        }
    }

    public void Hit()
    {
        foreach (var item in marker)
        {
            StopAllCoroutines();
            item.color = Color.white;
        }
        StartCoroutine(HitColor());
    }

    private IEnumerator HitColor()
    {
        float time = 0.0f;
        while (time < 1f)
        {
            /*float a = Mathf.Lerp(255, 0, time);
            marker[0].color = new Color(a, a, a, a);
            foreach (var item in marker)
            {
               //item.color = new Color(a,a,a); 
            }*/
            
            yield return null;
            time += Time.deltaTime;
        }
        foreach (var item in marker)
        {
            item.color = Color.clear;
        }
    }
}

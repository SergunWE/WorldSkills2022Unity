using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform objectTracking;
    
        void Update()
    {
        //���������� ������ � �������, �� ������� ������
        transform.position = objectTracking.position;    
    }
}

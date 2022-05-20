using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform objectTracking;
    
        void Update()
    {
        //перемещаем камеру к объекту, за которым следим
        transform.position = objectTracking.position;    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour
{
    bool _isRotate = false;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRotate)
        {
            var rot = transform.rotation;
            rot.y += Time.deltaTime * 1;
            transform.rotation = rot;
        }
    }

    public void startRotate()
    {
        _isRotate = true;
    }

    public void stopRotate()
    {
        _isRotate = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour
{
    bool _isRotate = false;
    bool _isScaleUp = false;
    bool _isScaleDown = false;
    float _scaleStep = 0.001f;
    float _maxScale = 0.15f;
    int _rotateSpeed = 15;
    BarGraphDat _barGraphDat;
    
    // Start is called before the first frame update
    void Start()
    {
        _barGraphDat = GetComponentInChildren<BarGraphDat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRotate)
        {
            var rot = transform.eulerAngles;
            rot.y += Time.deltaTime * _rotateSpeed;
            transform.rotation = Quaternion.Euler(rot);
        }

        if(_isScaleUp)
        {
            var scale = transform.localScale;
            if (scale.x > _maxScale || scale.y > _maxScale || scale.z > _maxScale)
            {
                return;
            }

            scale.x += _scaleStep;
            scale.z += _scaleStep;
            scale.y += _scaleStep;
            transform.localScale = scale;
        }

        if(_isScaleDown)
        {
            var scale = transform.localScale;

            if (scale.x <= _scaleStep || scale.y <= _scaleStep || scale.z <= _scaleStep)
            {
                return;
            }

            scale.x -= _scaleStep;
            scale.z -= _scaleStep;
            scale.y -= _scaleStep;

            transform.localScale = scale;
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

    public void startScaleUp()
    {
        _isScaleUp = true;
    }

    public void stopScaleUp()
    {
        _isScaleUp = false;
    }

    public void startScaleDown()
    {
        _isScaleDown = true;
    }

    public void stopScaleDown()
    {
        _isScaleDown = false;
    }

    public void setChartYear(int year)
    {
        _barGraphDat.updateBarYear(year);
    }
}

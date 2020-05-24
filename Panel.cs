using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    GameObject _gobjBtnPlus, _gobjBtnMinus, _gobjBtnAspects, _gobjBtnRotate;
    GameObject _gobjChart;
    Chart _chart;
    AudioSource _btnSound;

    // Start is called before the first frame update
    void Start()
    {
        _gobjChart = GameObject.Find("Chart");
        _chart = _gobjChart.GetComponent<Chart>();

        _gobjBtnPlus = GameObject.Find("Button Plus");
        _gobjBtnMinus = GameObject.Find("Button Minus");
        _gobjBtnRotate = GameObject.Find("Button Rotate");
        _gobjBtnAspects = GameObject.Find("Button Aspect");

        _btnSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buttonDown(GameObject obj)
    {
        Vector3 scale = obj.transform.localScale;
        scale.y = 0.01f;
        obj.transform.localScale = scale;

        _btnSound.Play();
    }

    void buttonUp(GameObject obj)
    {
        Vector3 scale = obj.transform.localScale;
        scale.y = 0.01f;
        obj.transform.localScale = scale;
    }

    public void plusPress()
    {
        buttonDown(_gobjBtnPlus);
        _chart.startScaleUp();
    }

    public void plusRelease()
    {
        buttonUp(_gobjBtnPlus);
        _chart.stopScaleUp();
    }

    public void minusPress()
    {
        buttonDown(_gobjBtnMinus);
        _chart.startScaleDown();
    }

    public void minusRelase()
    {
        buttonUp(_gobjBtnMinus);
        _chart.stopScaleDown();
    }

    public void rotatePress()
    {
        buttonDown(_gobjBtnRotate);

        _chart.startRotate();
    }

    public void rotateRelease()
    {
        buttonUp(_gobjBtnRotate);
        _chart.stopRotate();
    }

    public void aspectsPress()
    {
        buttonDown(_gobjBtnAspects);
    }

    public void aspectsRelease()
    {
        buttonUp(_gobjBtnAspects);
    }
}

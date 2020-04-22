using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgressBar : FillBar
{
    private UnityEvent onProgressComplete;

    public new float CurrentValue
    {
        get
        {
            return base.CurrentValue;
        }
        set
        {
            if (value >= slider.maxValue)
                onProgressComplete.Invoke();
            base.CurrentValue = value % slider.maxValue;
        }
    }

    void OnProgressComplete()
    {
        Debug.Log("Progress Complete");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue += 0.0153f;
    }
}

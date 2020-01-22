using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : Singleton<ObjectMovement>
{
    public AnimationCurve MoveCurve;    
    private Vector3 _target;
    private Vector3 _startPoint;
    private float _animationTimePosition;

    private void Start()
    {
        UpdatePath();
       
    }

    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (_target != transform.position)
        {
            _animationTimePosition += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPoint, _target, MoveCurve.Evaluate(_animationTimePosition));
        }
        else
        {
            UpdatePath();
            _animationTimePosition = 0;
        }
    }
    private void UpdatePath()
    {
        _startPoint = transform.position;
        _target = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }    
}

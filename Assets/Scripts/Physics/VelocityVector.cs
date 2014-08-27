using UnityEngine;
using System.Collections;

public class VelocityVector {

    public float magnitude {
        get { return _magnitude; }
    }

    public float horizontal {
        get { return _horizontal; }
    }

    public float vertical {
        get { return _vertical; }
    }

    // Angle is in degrees
    public float angle {
        get { return _angle; }
    }

    public float radAngle {
        get { return _angle * Mathf.Deg2Rad; }
    }

    private float _magnitude;
    private float _horizontal;
    private float _vertical;
    private float _angle;

    public VelocityVector() {
        SetVector(0.0f, 0.0f);
    }

    public void UpdateVector(float aHorizontal, float aVertical) {
        _vertical += aVertical;
        _horizontal += aHorizontal;

        _magnitude = Mathf.Sqrt(
                Mathf.Pow(aVertical, 2.0f) + Mathf.Pow(aHorizontal, 2.0f)
            );
        _angle = CalculateAngle();
    }

    public void SetVector(float aMagnitude, float aAngle) {
        if (aMagnitude < 0.0f) {
            Debug.LogError ("VelocityVector: Magnitude can't be less than zero.");
            return;
        }
        _magnitude = aMagnitude;
        _vertical = aMagnitude * Mathf.Sin(aAngle * Mathf.Deg2Rad);
        _horizontal = aMagnitude * Mathf.Cos(aAngle * Mathf.Deg2Rad);
        _angle = aAngle;
    }

    private float CalculateAngle() {
        if (!Utilities.isZero(_horizontal)) {
            return Mathf.Atan(_vertical / _horizontal) * Mathf.Rad2Deg;
        } else {
            if (_vertical < 0.0f) { return -90.0f; }
            else { return 90.0f; }
        }
    }
}
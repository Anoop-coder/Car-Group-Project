using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SPEEDNOEDIT : MonoBehaviour
{

    public Rigidbody target;



    public float maxSpeed = 0.0f;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;


    public TMP_Text mphText;
    public RectTransform arrow;

    private float speed = 0.0f;

    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;

        if (mphText != null)
            mphText.text = ((int)speed + "km/h");
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Device_Operator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject Text;
    [SerializeField] private float Distance_Use;
    [SerializeField] private GameObject[] Doors;
    [SerializeField] private bool[] D_able;
    [SerializeField] private GameObject[] Lights;
    [SerializeField] private GameObject Switcher;
    [SerializeField] private bool On_Off;

    void Start()
    {
        Text.SetActive(false);
        Active(Lights);
    }
    
    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        for (int i = 0; i < Doors.Length; i++)
        {
            if ((Physics.Raycast(ray, out hit)) && (hit.distance <= Distance_Use))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject == Doors[i])
                {
                    Text.SetActive(true);
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (D_able[i] == false)
                        {
                            hitObject.transform.Rotate(0,0,90);
                            D_able[i] = true;
                        }
                        else
                        {
                            hitObject.transform.Rotate(0,0,-90);
                            D_able[i] = false;
                        }
                    }
                }
            }
            else
            {
                Text.SetActive(false);
            }
        }
        if ((Physics.Raycast(ray, out hit)) && (hit.distance <= Distance_Use))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject == Switcher)
            {
                Text.SetActive(true);
                if (Input.GetButtonDown("Fire1"))
                {
                    Active(Lights);
                }
            }
        }
        else
        {
            Text.SetActive(false);
        }
    }
    
    private void Active(GameObject[] bt)
    {
        if (On_Off)
        {
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i].SetActive(false);
            }
            On_Off = false;
        }
        else
        {
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i].SetActive(true);
            }
            On_Off = true;
        }
    }
}

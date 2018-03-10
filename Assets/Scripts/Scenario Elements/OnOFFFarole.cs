using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOFFFarole : MonoBehaviour {

    public GameObject farole;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TurnLight();
        }
    }
    public void TurnLight()
    {
        farole.gameObject.SetActive(!farole.gameObject.activeSelf);
    }
}

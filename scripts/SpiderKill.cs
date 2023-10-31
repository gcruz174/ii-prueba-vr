using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKill : MonoBehaviour
{
    public float timeToKill = 2f;

    private float _timer;
    private bool _aiming;

    private void Update()
    {
        if (_aiming)
        {
            _timer += Time.deltaTime;
            if (_timer >= timeToKill)
            {
                Debug.Log("Se ha matado a la araña con el poder");
                gameObject.SetActive(false);
            }
        }
    }

    public void OnPointerEnter()
    {
        Debug.Log("Se ha activado el poder");
        _aiming = true;
    }

    public void OnPointerExit()
    {
        Debug.Log("Se ha desactivado el poder");
        _aiming = false;
        _timer = 0f;
    }
}

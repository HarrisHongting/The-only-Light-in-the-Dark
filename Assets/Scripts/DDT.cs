using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DDT : MonoBehaviour
{
    [SerializeField] private CustomPassVolume _cpv;

    private TIPS_2 t2;

    private float _initSize;

    private void Start()
    {
        _initSize = 0.1f;
        if (_cpv.customPasses[0] is TIPS_2 f)
        {
            t2 = f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SizeCoRoutine());
        }
    }

    private IEnumerator SizeCoRoutine()
    {
        while (_initSize <= 100)
        {
            _initSize += 1f;
            t2.size = _initSize;
            yield return new WaitForFixedUpdate();
        }

        _initSize = 1f;
        t2.size = _initSize = 1f;
        yield return null;
    }
}

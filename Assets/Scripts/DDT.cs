using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DDT : MonoBehaviour
{
    [SerializeField] private CustomPassVolume _cpv;

    private TIPS_2 t2;

    private float _initSize;

    public float cooldown = 10.0f; // 冷却时间
    private float timer = 0.0f;   // 计时器
    private bool isCooldown = false; // 是否在冷却中
    public Image cooldownImage;
    
    public GameObject GameSettings;
    private void Start()
    {
        
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        GameSettings.SetActive(false);
        
        _initSize = 0.01f;
        if (_cpv.customPasses[0] is TIPS_2 f)
        {
            t2 = f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isCooldown)
            {
                // 激活技能
                ActivateSkill();
            }
        }

        if (isCooldown)
        {
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    isCooldown = false;
                }
                cooldownImage.fillAmount = timer / cooldown;
        }

        void ActivateSkill() 
            {
                StartCoroutine(SizeCoRoutine());   
                Debug.Log("Skill activated!");  
                isCooldown = true;
                timer = cooldown;
                cooldownImage.fillAmount = 1.0f;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("暂停了");
            Time.timeScale = 0;
            GameSettings.SetActive(true);;
        }
            
        if (GameSettings.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    private IEnumerator SizeCoRoutine()
    {
        while (_initSize <= 150)
        {
            _initSize += 1f;
            t2.size = _initSize;
            yield return new WaitForFixedUpdate();
        }

        _initSize = 0.1f;
        t2.size = _initSize = 0.1f;
        yield return null;
    }
}

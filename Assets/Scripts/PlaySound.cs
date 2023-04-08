using System.Collections.Generic;
using UnityEngine;

public class PlayNearbySounds : MonoBehaviour
{
    public float range = 5.0f; // 检测范围
    private List<AudioSource> audioSources;

    void Start()
    {
        // 寻找场景中所有的AudioSource组件并添加到列表中
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
    }

    void Update()
    {
        // 当按下E键时
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 遍历场景中所有的AudioSource组件
            foreach (AudioSource audioSource in audioSources.ToArray()) // 使用ToArray()创建一个副本，以避免在迭代过程中更改列表
            {
                // 检查AudioSource是否有效
                if (audioSource == null)
                {
                    // 从列表中移除无效的AudioSource
                    audioSources.Remove(audioSource);
                }
                else
                {
                    // 计算Player和AudioSource之间的距离
                    float distance = Vector3.Distance(transform.position, audioSource.transform.position);

                    // 如果距离在指定范围内
                    if (distance <= range)
                    {
                        // 播放声音
                        audioSource.Play();
                    }
                }
            }
        }
    }
}
using UnityEngine;
using TMPro;
using System.Collections;

public class StoryController : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public string[] storyContent;
    private int currentIndex = 0;
    public float textSpeed = 0.05f; // 每个字符显示的速度，可以根据需要调整

    private void Start()
    {
        if (storyContent.Length > 0)
        {
            StartCoroutine(TypeText(storyContent[currentIndex]));
        }
    }

    public void NextStorySegment()
    {
        if (currentIndex < storyContent.Length)
        {
            StopAllCoroutines(); // 停止当前的文字显示
            currentIndex++;
            if (currentIndex < storyContent.Length)
            {
                StartCoroutine(TypeText(storyContent[currentIndex]));
            }
            else
            {
                // 加载游戏场景
                UnityEngine.SceneManagement.SceneManager.LoadScene("Maze0");
            }
        }
    }

    public void Skip()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Maze0");
    }

    private IEnumerator TypeText(string text)
    {
        storyText.text = "";
        foreach (char c in text)
        {
            storyText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
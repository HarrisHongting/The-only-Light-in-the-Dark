using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    private bool canMove = false;
    
    private void Update()
    {
        if(canMove)
        {
            // 计算怪物和玩家之间的距离
            float distance = Vector3.Distance(transform.position, player.position);

            // 如果怪物在玩家后面，就向玩家移动
            if (distance > stoppingDistance)
            {
                //Debug.Log(distance);
                transform.LookAt(player); 
                //Vector3 direction = (player.position - transform.position).normalized;
                //transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
            // 如果怪物追到了玩家，就结束游戏
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    public void PlayerMoved()
    {
        canMove = true;
    }
}
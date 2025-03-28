using UnityEngine;
using UnityEngine.SceneManagement;

public class tijdelijkWin : MonoBehaviour
{
    [SerializeField] int totalEnemys;

    public void enemyDead() {

        totalEnemys--;

        if (totalEnemys <= 0) {
            SceneManager.LoadScene("YouWinScreen");

        }
    
    
    }
}

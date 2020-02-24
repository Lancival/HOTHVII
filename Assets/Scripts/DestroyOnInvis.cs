using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvis : MonoBehaviour
{
    bool willWrap;
    private float BORDER = 0.1f;
    void OnBecameInvisible() {
        if (!GameObject.Find("Player").GetComponent<Shoot>().PowerUpVal(2))
        {
            Debug.Log("will wrap: " + willWrap + " direct: " + GameObject.Find("Player").GetComponent<Shoot>().PowerUpVal(2));
            Destroy(gameObject);
        }
        else
        {
            if (willWrap) Destroy(gameObject);
            else
            {
                float playerX = transform.position.x;
                float playerY = transform.position.y;
                if (playerX > 8 + BORDER || playerX < -8 - BORDER)
                {
                    playerX = playerX * -1;
                    if (playerX > 0) playerX -= BORDER;
                    else playerX += BORDER;
                }
                if (playerY > 5 + BORDER || playerY < -5 - BORDER)
                {
                    playerY = playerY * -1;
                    if (playerY > 0) playerY -= BORDER;
                    else playerY += BORDER;
                }
                transform.position = (new Vector2(playerX, playerY));
                willWrap = true;
            }
        }
    }

    void start()
    {
        willWrap = true;
    }
}

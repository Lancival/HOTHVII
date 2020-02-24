using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvis : MonoBehaviour
{
    bool willWrap = false;
    private float BORDER = 0.1f;
    void OnBecameInvisible() {
        if (!willWrap)
        {
            Destroy(gameObject);
        }
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
        }
    }

    void update()
    {
        willWrap = GameObject.Find("Player").GetComponent<Shoot>().PowerUpVal(2);
    }
}

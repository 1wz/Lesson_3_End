using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpScript : MonoBehaviour
{
    private const float JumpForse = 2;
    private const float g = 9.8f;
    public void StartJump(Transform jumper,UnityAction onEnd)
    {
        StartCoroutine(Jump(jumper,onEnd));
    }
    IEnumerator Jump(Transform jumper, UnityAction onEnd)
    {
        float defoultAltitude = jumper.position.y;
        float velocityY = JumpForse;
        do
        {
            jumper.Translate(0,velocityY * Time.deltaTime,0);
            velocityY -= g * Time.deltaTime;
            yield return null;
        } 
        while (jumper.position.y>=defoultAltitude);
        jumper.position = new Vector2(jumper.position.x, defoultAltitude);
        Destroy(gameObject);
        onEnd?.Invoke();
    }
}

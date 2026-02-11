using UnityEngine;
using System.Collections;

public class HitFlashScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color OriginalColor;
    private Coroutine FlashCoroutine;
    private float FlashDuration = 0.15f;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        OriginalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        if ( FlashCoroutine!= null)
        {
         StopCoroutine(FlashCoroutine);
        }
        FlashCoroutine = StartCoroutine(PlayFlash());
    }

    private IEnumerator PlayFlash()
    {
        spriteRenderer.color = new Color(255f, 255f, 255f, 255);
        yield return new WaitForSeconds(FlashDuration);
        spriteRenderer.color = OriginalColor;
    }
}

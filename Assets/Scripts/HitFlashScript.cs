using UnityEngine;
using System.Collections;

public class HitFlashScript : MonoBehaviour
{
    private Material OGMat;
    [SerializeField] private Material NEWMat;
    private SpriteRenderer spriteRenderer;
    private Coroutine FlashCoroutine;
    private float FlashDuration = 0.15f;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        OGMat = spriteRenderer.material;
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
        spriteRenderer.material = NEWMat;
        yield return new WaitForSeconds(FlashDuration);
        spriteRenderer.material = OGMat;
    }
}

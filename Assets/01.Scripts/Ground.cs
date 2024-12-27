using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float spriteWidth;
    [SerializeField] private Transform followTarget;
    [SerializeField] private float lastTargetXPosition;
    [SerializeField] private SpriteRenderer[] groundSpriteRederers;
    void Awake()
    {
        int xPosition = Mathf.RoundToInt((followTarget.position.x / spriteWidth));
        UpdateGroundSpritePositions(xPosition);
    }
    void FixedUpdate()
    {
        int xPosition = Mathf.RoundToInt((followTarget.position.x / spriteWidth));
        if (lastTargetXPosition == xPosition)
            return;
        UpdateGroundSpritePositions(xPosition);
    }

    private void UpdateGroundSpritePositions(int xPosition)
    {
        for (int i = 0; i < groundSpriteRederers.Length; i++)
        {
            SpriteRenderer spriteRenderer = groundSpriteRederers[i];

            float centeredSpriteIndex = i - groundSpriteRederers.Length / 2;
            float offSet = centeredSpriteIndex * spriteWidth;

            Vector3 translationVector = new Vector3(offSet + xPosition * spriteWidth, transform.position.y, 0);
            spriteRenderer.transform.position = translationVector;
        }
        lastTargetXPosition = xPosition;
    }

    [ContextMenu("AutoInitailize")]
    private void AutoInitailize()
    {
        groundSpriteRederers = GetComponentsInChildren<SpriteRenderer>();
        spriteWidth = groundSpriteRederers[0].bounds.size.x;
    }
}

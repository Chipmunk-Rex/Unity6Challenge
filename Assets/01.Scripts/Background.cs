using System;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private BackgroundData[] backgroundDatas;
    private int offsetID = Shader.PropertyToID("_Offset");
    private float size = 1;
    public float Size
    {
        get => size;
        set
        {
            size = value;
            if (size <= 0)
            {
                size = 0;
            }
            transform.localScale = new Vector3(size, size, 1);
        }
    }
    [SerializeField] private Transform followTarget;
    void Update()
    {
        Follow();
    }
    private void Follow()
    {
        float xPos = followTarget.position.x;
        foreach (var data in backgroundDatas)
        {
            Vector2 offset = new Vector2(data.speed * xPos, 0);
            data.spriteRenderer.material.SetVector(offsetID, offset);
        }
    }
    [Serializable]
    public struct BackgroundData
    {
        public SpriteRenderer spriteRenderer;
        public float speed;
    }
}

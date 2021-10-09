using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color m_baseColor, m_offsetColor;
    // Start is called before the first frame update
    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        m_renderer.color = isOffset ? m_offsetColor : m_baseColor;
    }
}

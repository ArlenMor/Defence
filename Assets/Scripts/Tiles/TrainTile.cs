using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTile : Tile
{
    [SerializeField] private Sprite m_trainSprite;


    public override void Init(int x, int y)
    {
        m_renderer.sprite = m_trainSprite;
    }
}

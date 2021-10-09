using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer m_renderer;
    [SerializeField] private GameObject m_highlight;
    //[SerializeField] private bool m_isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => /*m_isWalkable &&*/ OccupiedUnit == null;

    public virtual void Init(int x, int y)
    {
        
    }

    private void OnMouseEnter()
    {
        m_highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        m_highlight.SetActive(false);
    }

    public void SetUnit(BaseUnit unit) {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}

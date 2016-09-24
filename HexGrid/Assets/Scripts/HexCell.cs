using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Color color;
    int _elevation;
    public RectTransform uiRect;

    [SerializeField]
    HexCell[] neighbours;

    public int Elevation
    {
        get { return _elevation; }
        set
        {
            _elevation = value;
            var position = transform.localPosition;
            position.y = value * HexMetrics.elevationStep;
            transform.localPosition = position;

            var uiPosition = uiRect.localPosition;
            uiPosition.z = _elevation * -HexMetrics.elevationStep;
            uiRect.localPosition = uiPosition;
        }
    }

    public HexCell GetNeighbour(HexDirection direction)
    {
        return neighbours[(int) direction];
    }

    public void SetNeighbour(HexDirection direction, HexCell cell)
    {
        neighbours[(int) direction] = cell;
        cell.neighbours[(int) direction.Opposite()] = this;
    }

    public HexEdgeType GetEdgeType(HexDirection direction)
    {
        return HexMetrics.GetEdgeType(_elevation, neighbours[(int) direction]._elevation);
    }
}

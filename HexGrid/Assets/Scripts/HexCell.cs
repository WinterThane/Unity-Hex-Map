using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;

    public Color color;

    [SerializeField]
    HexCell[] neighbours;

    public HexCell GetNeighbour(HexDirection direction, HexCell cell)
    {
        return neighbours[(int) direction];
    }

    public void SetNeighbour(HexDirection direction, HexCell cell)
    {
        neighbours[(int) direction] = cell;
        cell.neighbours[(int) direction.Opposite()] = this;
    }
}

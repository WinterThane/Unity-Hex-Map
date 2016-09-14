using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;
    public HexGrid hexGrid;
    private Color _activeColor;
    private int _activeElevation;

    void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        var inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            EditCell(hexGrid.GetCell(hit.point));
        }
    }

    void EditCell(HexCell cell)
    {
        cell.color = _activeColor;
        cell.elevation = _activeElevation;
        hexGrid.Refresh();
    }

    public void SetElevation(float elevation)
    {
        _activeElevation = (int)elevation;
    }

    public void SelectColor(int index)
    {
        _activeColor = colors[index];
    }
}

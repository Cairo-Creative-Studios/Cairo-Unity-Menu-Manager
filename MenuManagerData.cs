using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Menus/MenuManagerData", fileName = "Menu Manager Data")]
public class MenuManagerData : SingletonData
{
    public PanelSettings PanelSettings;
    public VisualTreeAsset RootAsset;
}
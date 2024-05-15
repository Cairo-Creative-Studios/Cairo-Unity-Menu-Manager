using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// A singleton class that manages the creation and display of menus using UIElements.
/// </summary>
public class MenuManager : Singleton<MenuManager, MenuManagerData>
{
    private GameObject _rootObject;
    /// <summary>
    /// Gets the root game object for the menus, creating it if null.
    /// </summary>
    public static GameObject RootObject => Instance._rootObject ??= new("Menu Root");


    private UIDocument _rootUIDocument;
    /// <summary>
    /// Gets the UI document for the menus, initializing it if null.
    /// </summary>
    public static UIDocument RootUI
    {
        get
        {
            if(Instance._rootUIDocument == null)
            {
                // If the Panel Settings or Root Asst have not been added to Data, Log an Error
                if (Data.PanelSettings || Data.RootAsset)
                {
                    Debug.LogError("The Menu Manager cannot be used because Panel Settings and Root Visual Tree Asset have not been set in Menu Manager Data.", Data);
                    return null;
                }

                // Create and set the properties of the UI Document
                Instance._rootUIDocument = RootObject.AddComponent<UIDocument>();
                Instance._rootUIDocument.panelSettings = Data.PanelSettings;
                Instance._rootUIDocument.visualTreeAsset = Data.RootAsset;

                // Make the Root Element fill the screen
                var rootVisualElement = Instance._rootUIDocument.rootVisualElement.ElementAt(0);
                rootVisualElement.style.position = Position.Absolute;
                rootVisualElement.style.width = Length.Percent(100);
                rootVisualElement.style.height = Length.Percent(100);

                Instance._hierarchy.Add(OpenMenu(Menu.CreateFromVisualTreeAsset(Data.RootAsset)), index: new int[] { 0 });
            }

            return Instance._rootUIDocument;
        }
    }

    /// <summary>
    /// Gets the root visual element of the UI document.
    /// </summary>
    public static VisualElement Root => Instance._rootUIDocument.rootVisualElement.ElementAt(0);


    private Tree<Menu> _hierarchy = new();

    /// <summary>
    /// Opens a menu and adds it to the hierarchy tree.
    /// </summary>
    /// <param name="menu">The menu to open.</param>
    /// <returns>The menu that was opened.</returns>
    public static Menu OpenMenu(Menu menu)
    {
        var menuHandle = new GameObject(menu.name + "_Handle").AddComponent<MenuHandle>();
        menuHandle.OpenMenu(menu);
        return menuHandle.Menu;
    }

    public static void CloseMenu(Menu menu)
    {
        menu.MenuHandle.CloseMenu();
    }
}
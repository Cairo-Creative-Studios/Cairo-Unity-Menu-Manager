// using directives are not usually commented
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// class summary
/// <summary>
/// A class that handles the creation and management of menus.
/// </summary>
public class MenuHandle : Singleton<MenuHandle>
{
    private Menu _menu;
    /// <summary>
    /// Gets the list of menus, initializing it if null.
    /// </summary>
    public Menu Menu => _menu ??= new();

    /// <summary>
    /// A dictionary that maps menus to their visual elements.
    /// </summary>
    public VisualElement RootElement => Menu.CreatedElement;

    /// <summary>
    /// Clones a Menu and sets it as the current menu of this handle.
    /// </summary>
    /// <param name="menu">The menu to open.</param>
    /// <returns>The visual element created by the menu, or null if another menu is already open.</returns>
    public VisualElement OpenMenu(Menu menu)
    {
        if(_menu == null)
        {
            _menu = menu.Clone(this);
            _menu.Open();
            OnMenuOpen.Invoke(this, _menu.TemplateMenu, RootElement);
            return menu.CreatedElement;
        }

        Debug.LogError("You cannot Open another Menu with this Menu Handle, because a Menu has already been openned.", this);
        return null;
    }

    /// <summary>
    /// Closes the current menu and destroys the handle and its game object.
    /// </summary>
    public void CloseMenu()
    {
        if(_menu != null)
        {
            _menu.Close();
            OnMenuClose.Invoke(this, _menu.TemplateMenu, RootElement);
            RootElement.parent.Remove(RootElement);
            DestroyImmediate(Menu);
            DestroyImmediate(gameObject);
        }
    }

    private void Update()
    {
        if(_menu != null)
            OnMenuUpdate.Invoke(this, _menu.TemplateMenu, RootElement);
    }
}


using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Menus/Menu", fileName = "Menu")]
public class Menu : ScriptableObject
{
    private Menu _templateMenu;
    public Menu TemplateMenu => _templateMenu;
    [SerializeField]
    private VisualTreeAsset _visualTreeAsset;
    public VisualTreeAsset VisualTreeAsset => _visualTreeAsset;

    private VisualElement _createdElement;
    /// <summary>
    /// The Element that is Created by Cloning the Root Tree Element of the Visual Tree Asset when the Menu is Openned.
    /// </summary>
    [HideInInspector] public VisualElement CreatedElement => _createdElement;
    private MenuHandle _menuHandle;
    /// <summary>
    /// The Menu Handle value is assigned when the Menu is Openned by a MenuHandler.
    /// </summary>
    [HideInInspector] public MenuHandle MenuHandle => _menuHandle;

    /// <summary>
    /// Instantiates a copy of this Menu Scriptable Object, Clones the Tree of the VisualTreeAsset and sets the values of the Instantiated copy of this Menu.
    /// </summary>
    /// <param name="handle">The Handle that controls this Menu.</param>
    /// <returns>The Instantiated Menu</returns>
    public Menu Clone(MenuHandle handle)
    {
        var clonedMenu = Instantiate(this);
        
        clonedMenu._menuHandle = handle;
        clonedMenu._createdElement = VisualTreeAsset.CloneTree();
        clonedMenu._templateMenu = this;

        return clonedMenu;
    }

    /// <summary>
    /// Creates a new Menu Object with the given Visual Tree Asset.
    /// </summary>
    /// <param name="visualTreeAsset">The Visual Tree Asset to assign to the Menu</param>
    /// <returns>The created Menu</returns>
    public static Menu CreateFromVisualTreeAsset(VisualTreeAsset visualTreeAsset)
    {
        var createdMenu = ScriptableObject.CreateInstance<Menu>();
        createdMenu._visualTreeAsset = visualTreeAsset;
        return createdMenu;
    }

    public virtual void Open()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Close()
    {

    }
}

using Unity.VisualScripting;

public class OpenMenu : Unit
{
    public ControlInput In;
    public ControlOutput Out;
    public ValueInput TemplateMenu;
    public ValueOutput MenuHandle;
    public ValueOutput Menu;
    
    protected override void Definition()
    {
        In = ControlInput("", (flow) =>
        {
            var templateMenu = flow.GetValue<Menu>(TemplateMenu);

            var menu = MenuManager.OpenMenu(templateMenu);
            flow.SetValue(MenuHandle, menu.MenuHandle);
            flow.SetValue(Menu, menu);

            return Out;
        });

        TemplateMenu = ValueInput<Menu>("Template Menu", default);
        MenuHandle = ValueOutput<MenuHandle>("Created Menu Handle");
        Menu = ValueOutput<Menu>("Created Menu");
    }
}
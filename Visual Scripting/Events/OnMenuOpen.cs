using Unity.VisualScripting;
using UnityEngine.UIElements;

[UnitCategory("Menus/Events")]
[UnitTitle("On Menu Openned")]
public class OnMenuOpen : ReflectiveEventUnit<OnMenuOpen>
{
	[OutputType(typeof(MenuHandle))]
	public ValueOutput MenuHandle;

	[OutputType(typeof(Menu))]
	public ValueOutput Menu;

	[OutputType(typeof(VisualElement))]
	public ValueOutput RootElement;

	public static void Invoke(MenuHandle menuHandle, Menu menu, VisualElement rootElement)
	{
		ModularInvoke(null, ("MenuHandle", menuHandle), ("Menu", menu), ("RootElement", rootElement));
	}
}
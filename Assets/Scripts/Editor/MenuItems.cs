using UnityEditor;

namespace Shooter.Editor
{
    public class MenuItems
    {
		[MenuItem("Game menu/Пункт меню №0 ")]
		private static void MenuOption()
		{
			EditorWindow.GetWindow(typeof(MyWindow), false, "About Shooting Game");
		}

		[MenuItem("Game menu/Пункт меню №1 %#a")]
		private static void NewMenuOption()
		{
		}

		[MenuItem("Game menu/Пункт меню №2 %g")]
		private static void NewNestedOption()
		{
		}

		[MenuItem("Game menu/Пункт меню №3 _g")]
		private static void NewOptionWithHotkey()
		{
		}

		[MenuItem("Game menu/Пункт меню/Пункт меню №3 _g")]
		private static void NewOptionWithHot()
		{
		}
		[MenuItem("Assets/Game menu")]
		private static void LoadAdditiveScene()
		{
		}
		[MenuItem("Assets/Create/Shooting Game Object")]
		private static void AddConfig()
		{
		}
		[MenuItem("CONTEXT/Rigidbody/Shooting Game")]
		private static void NewOpenForRigidBody()
		{
		}
	}
}

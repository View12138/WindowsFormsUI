# 在 Winform 程序中使用 Windows 10 的主题颜色
## 原理:
实现了 `UISettingsWF` 类、`UIColorTypeWF` 枚举、`UIElementTypeWF` 枚举。  
对应 `Windows.UI.ViewManagement` 中的 `UISettings` 类、`UIColorType` 枚举、`UIElementType` 枚举
## 使用:
1. 在你的 Winform 项目中创建 `Librarys` 文件夹并向其中添加以下文件:  
   - `System.Runtime.WindowsRuntime.dll`
   - `Windows.Foundation.FoundationContract.winmd`
   - `Windows.Foundation.UniversalApiContract.winmd`
   - `Windows.UI.ViewManagement.ViewManagementViewScalingContract.winmd`
   - `WindowsFormsUI.dll`
   - `WindowsFormsUI.xml`
2. 在项目中添加命名空间 `WindowsForms.UI.ViewManagement`
3. 
   ```
   // 初始化类
   UISettingsWF UISettings = new UISettingsWF();
   // 返回指定的颜色类型的颜色值。（此处返回强调色）
   Color accentColor = UISettings.GetColorValue(UIColorTypeWF.Accent);
   // 获取用于特定用户界面元素类型的颜色。（此处背景元素的颜色）
   this.BackColor = UISettings.UIElementColor(UIElementTypeWF.Background);
   ```

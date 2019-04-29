# 在 Winform 程序中使用 Windows 10 的主题颜色

## 原理:
实现了 `UISettingsWF` 类、`UIColorTypeWF` 枚举、`UIElementTypeWF` 枚举。  
对应 `Windows.UI.ViewManagement` 中的 `UISettings` 类、`UIColorType` 枚举、`UIElementType` 枚举

## 编译:
0. 平台：Windows 10
1. 打开本项目，查找并添加以下引用：（版本号可能不同）
    > 注意：请将文件类型限定改为 `所有文件(*.*)`，以便添加 `*.winmd` 文件。  
    > 更改属性：`复制本地` > `True`

    |编号|名称|路径|
    |-|-|-|
    |1|`System.Runtime.WindowsRuntime.dll`|`C:\Windows\Microsoft.NET\assembly\GAC_MSIL\System.Runtime.WindowsRuntime\v4.0_4.0.0.0__b77a5c561934e089\`|
    |2|`Windows.Foundation.FoundationContract.winmd`|`C:\Program Files (x86)\Windows Kits\10\References\10.0.17763.0\Windows.Foundation.FoundationContract\3.0.0.0\`|
    |3|`Windows.Foundation.UniversalApiContract.winmd`|`C:\Program Files (x86)\Windows Kits\10\References\10.0.17763.0\Windows.Foundation.UniversalApiContract\7.0.0.0\`|
    |4|`Windows.UI.ViewManagement.ViewManagementViewScalingContract.winmd`|`C:\Program Files (x86)\Windows Kits\10\References\10.0.17763.0\Windows.UI.ViewManagement.ViewManagementViewScalingContract\1.0.0.0\`|

## 使用:
0. 本项目只适用 Windows 10
1. 在你的 Winform 项目中创建 `Librarys` 文件夹并向其中添加本项目生成的以下文件:  
   - `System.Runtime.WindowsRuntime.dll`
   - `Windows.Foundation.FoundationContract.winmd`
   - `Windows.Foundation.UniversalApiContract.winmd`
   - `Windows.UI.ViewManagement.ViewManagementViewScalingContract.winmd`
   - `WindowsFormsUI.dll`
   - `WindowsFormsUI.xml`

2. 在项目中添加引用 `WindowsFormsUI.dll`

3. 在项目中添加命名空间 `WindowsForms.UI.ViewManagement`

4. 使用方法  
   ```
    // 初始化类
    UISettingsWF UISettings = new UISettingsWF();

    // 注册颜色变化事件。（在系统颜色变化时发生）
    UISettings.ColorValuesChanged += UISettings_ColorValuesChanged(object sender, EventArgs e);

    // 返回指定的颜色类型的颜色值。（此处返回强调色）
    Color accentColor = UISettings.GetColorValue(UIColorTypeWF.Accent);

    // 获取用于特定用户界面元素类型的颜色。（此处背景元素的颜色）
    this.BackColor = UISettings.UIElementColor(UIElementTypeWF.Background);

    /// <summary>
    /// 当颜色改变时发生。
    /// </summary>
    /// <param name="sender">事件发生的对象。</param>
    /// <param name="e">无意义。</param>
    private void UISettings_ColorValuesChanged(object sender, EventArgs e)
    {
        /*
        * 在此处完成颜色的修改
        */
    }
   ```

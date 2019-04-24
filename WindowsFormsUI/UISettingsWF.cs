using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace WindowsForms.UI.ViewManagement
{
    /// <summary>
    /// 包含一组常用应用程序用户界面设置和操作。
    /// </summary>
    public class UISettingsWF
    {
        // 字段
        private UISettings UISettings;

        // 构造
        /// <summary>
        /// 创建 UISettings 类的新默认实例。
        /// </summary>
        public UISettingsWF()
        {
            UISettings = new UISettings();
            UISettings.AdvancedEffectsEnabledChanged += (sender, args) =>
            {
                UISettings = sender;
                AdvancedEffectsEnabledChanged?.Invoke(this, new EventArgs());
            };
            UISettings.ColorValuesChanged += (sender, args) =>
            {
                UISettings = sender;
                ColorValuesChanged?.Invoke(this, new EventArgs());
            };
            UISettings.TextScaleFactorChanged += (sender, agrs) =>
            {
                UISettings = sender;
                TextScaleFactorChanged?.Invoke(this, new EventArgs());
            };
        }

        // 事件
        /// <summary>
        /// 启用或禁用高级 UI 效果设置时发生。
        /// </summary>
        public event EventHandler AdvancedEffectsEnabledChanged;
        /// <summary>
        /// 当颜色值更改时发生。
        /// </summary>
        public event EventHandler ColorValuesChanged;
        /// <summary>
        /// 当系统文本大小设置更改时发生。
        /// </summary>
        public event EventHandler TextScaleFactorChanged;

        // 属性
        /// <summary>
        /// 获取一个值，该值指示是否启用系统的透明效果设置。
        /// </summary>
        public bool AdvancedEffectsEnabled { get => UISettings.AdvancedEffectsEnabled; }
        /// <summary>
        /// 获取是否为用户界面启用动画。
        /// </summary>
        public bool AnimationsEnabled { get => UISettings.AnimationsEnabled; }
        /// <summary>
        /// 获取通过应用程序视图创建的新插入符号的闪烁速率。
        /// </summary>
        public uint CaretBlinkRate { get => UISettings.CaretBlinkRate; }
        /// <summary>
        /// 获取插入符号是否可以用于浏览操作。
        /// </summary>
        public bool CaretBrowsingEnabled { get => UISettings.CaretBrowsingEnabled; }
        /// <summary>
        /// 获取通过应用程序视图创建的新插入符号的宽度。
        /// </summary>
        public uint CaretWidth { get => UISettings.CaretWidth; }
        /// <summary>
        /// 获取通过应用程序视图创建的新光标的大小。
        /// </summary>
        public SizeF CursorSize { get => new SizeF((float)UISettings.CursorSize.Width, (float)UISettings.CursorSize.Height); }
        /// <summary>
        /// 获取双击操作时两次单击之间的最长允许时间。
        /// </summary>
        public uint DoubleClickTime { get => UISettings.DoubleClickTime; }
        /// <summary>
        /// 获取通过应用程序视图创建的用户界面的方向首选项。
        /// </summary>
        public HandPreferenceWF HandPreference { get => (HandPreferenceWF)Enum.Parse(typeof(HandPreference), UISettings.HandPreference.ToString()); }
        /// <summary>
        /// 获取为应用程序视图显示消息的时间长度。
        /// </summary>
        public uint MessageDuration { get => UISettings.MessageDuration; }
        /// <summary>
        /// 获取在引发悬停事件之前，鼠标指针可悬停在矩形上的时间。
        /// </summary>
        public uint MouseHoverTime { get => UISettings.MouseHoverTime; }
        /// <summary>
        /// 获取与应用程序视图关联的窗口的滚动条箭头的大小。
        /// </summary>
        public SizeF ScrollBarArrowSize { get => new SizeF((float)UISettings.ScrollBarArrowSize.Width, (float)UISettings.ScrollBarArrowSize.Height); }
        /// <summary>
        /// 获取与应用程序视图关联的窗口的滚动条的大小。
        /// </summary>
        public SizeF ScrollBarSize { get => new SizeF((float)UISettings.ScrollBarSize.Width, (float)UISettings.ScrollBarSize.Height); }
        /// <summary>
        /// 获取与应用程序关联的窗口的滚动块的大小。
        /// </summary>
        public SizeF ScrollBarThumbBoxSize { get => new SizeF((float)UISettings.ScrollBarThumbBoxSize.Width, (float)UISettings.ScrollBarThumbBoxSize.Height); }
        /// <summary>
        /// 获取系统文本大小设置的值。
        /// </summary>
        public double TextScaleFactor { get => UISettings.TextScaleFactor; }

        // 方法
        /// <summary>
        /// 返回指定的颜色类型的颜色值。
        /// </summary>
        /// <param name="desiredColor">指定要获取值的颜色的类型的枚举值。</param>
        /// <returns></returns>
        public Color GetColorValue(UIColorTypeWF desiredColor)
        {
            UIColorType uIColorType = (UIColorType)Enum.Parse(typeof(UIColorType), desiredColor.ToString());
            Windows.UI.Color color = UISettings.GetColorValue(uIColorType);
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        /// <summary>
        /// 获取用于特定用户界面元素类型（如按钮表面或窗口文本）的颜色。
        /// </summary>
        /// <param name="desiredElement">将获取颜色的元素类型。</param>
        /// <returns></returns>
        public Color UIElementColor(UIElementTypeWF desiredElement)
        {
            UIElementType uIElementType = (UIElementType)Enum.Parse(typeof(UIElementType), desiredElement.ToString());
            Windows.UI.Color color = UISettings.UIElementColor(uIElementType);
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }

    /// <summary>
    /// 定义指定已知系统颜色值的常数。
    /// </summary>
    public enum UIColorTypeWF
    {
        /// <summary>
        /// 背景色。
        /// </summary>
        Background,
        /// <summary>
        /// 前景色。
        /// </summary>
        Foreground,
        /// <summary>
        /// 最深的强调色。
        /// </summary>
        AccentDark3,
        /// <summary>
        /// 较深的强调色。
        /// </summary>
        AccentDark2,
        /// <summary>
        /// 深的强调色。
        /// </summary>
        AccentDark1,
        /// <summary>
        /// 强调色。
        /// </summary>
        Accent,
        /// <summary>
        /// 浅的强调色。
        /// </summary>
        AccentLight1,
        /// <summary>
        /// 较浅的强调色。
        /// </summary>
        AccentLight2,
        /// <summary>
        /// 最浅的强调色。
        /// </summary>
        AccentLight3,
    }

    /// <summary>
    /// 定义用户界面的元素类型集。
    /// </summary>
    public enum UIElementTypeWF
    {
        /// <summary>
        /// 强调色。
        /// </summary>
        AccentColor = 1000,
        /// <summary>
        /// 活动标题元素。
        /// </summary>
        ActiveCaption = 0,
        /// <summary>
        /// 背景元素。
        /// </summary>
        Background = 1,
        /// <summary>
        /// 按钮表面元素。
        /// </summary>
        ButtonFace = 2,
        /// <summary>
        /// 文本在按钮中的显示。
        /// </summary>
        ButtonText = 3,
        /// <summary>
        /// 标题显示的文本。
        /// </summary>
        CaptionText = 4,
        /// <summary>
        /// 灰色文本。
        /// </summary>
        GrayText = 5,
        /// <summary>
        /// 突出显示的用户（UI）界面元素。
        /// </summary>
        Highlight = 6,
        /// <summary>
        /// 突出显示的文本。
        /// </summary>
        HighlightText = 7,
        /// <summary>
        /// 突出显示的 UI 元素。
        /// </summary>
        Hotlight = 8,
        /// <summary>
        /// 非活动标题元素
        /// </summary>
        InactiveCaption = 9,
        /// <summary>
        /// 文本在非活动标题元素中显示。
        /// </summary>
        InactiveCaptionText = 10,
        /// <summary>
        /// 
        /// </summary>
        NonTextHigh = 1005,
        /// <summary>
        /// 
        /// </summary>
        NonTextLow = 1009,
        /// <summary>
        /// 
        /// </summary>
        NonTextMedium = 1007,
        /// <summary>
        /// 
        /// </summary>
        NonTextMediumHigh = 1006,
        /// <summary>
        /// 
        /// </summary>
        NonTextMediumLow = 1008,
        /// <summary>
        /// 
        /// </summary>
        OverlayOutsidePopup = 1012,
        /// <summary>
        /// 
        /// </summary>
        PageBackground = 1010,
        /// <summary>
        /// 
        /// </summary>
        PopupBackground = 1011,
        /// <summary>
        /// 
        /// </summary>
        TextContrastWithHigh = 1004,
        /// <summary>
        /// 
        /// </summary>
        TextHigh = 1001,
        /// <summary>
        /// 
        /// </summary>
        TextLow = 1003,
        /// <summary>
        /// 
        /// </summary>
        TextMedium = 1002,
        /// <summary>
        /// 窗口。
        /// </summary>
        Window = 11,
        /// <summary>
        /// 文本在窗口的 UI 修饰中显示。
        /// </summary>
        WindowText = 12,
    }

    /// <summary>
    /// 定义应用程序视图显示的用户界面的方向首选项集。
    /// </summary>
    public enum HandPreferenceWF
    {
        /// <summary>
        /// 首选布局适用于左定向用户。
        /// </summary>
        LeftHanded = 0,
        /// <summary>
        /// 首选布局适用于右定向用户。
        /// </summary>
        RightHanded = 1,
    }
}

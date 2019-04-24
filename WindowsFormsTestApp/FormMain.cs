using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UI.ViewManagement;

namespace WindowsFormsTestApp
{
    public partial class FormMain : Form
    {
        UISettingsWF UISettings;
        public FormMain()
        {
            InitializeComponent();
            UISettings = new UISettingsWF();
            UISettings.ColorValuesChanged += UISettings_ColorValuesChanged;
        }

        private void UISettings_ColorValuesChanged(object sender, EventArgs e)
        {
            FormMain_Load(sender, e);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BackColor = UISettings.GetColorValue(UIColorTypeWF.Background);
            ForeColor = UISettings.GetColorValue(UIColorTypeWF.Foreground);
            label1.BackColor = UISettings.GetColorValue(UIColorTypeWF.Background);
            label2.BackColor = UISettings.GetColorValue(UIColorTypeWF.Foreground);
            label2.ForeColor = UISettings.GetColorValue(UIColorTypeWF.Background);
            label3.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentDark3);
            label4.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentDark2);
            label5.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentDark1);
            label6.BackColor = UISettings.GetColorValue(UIColorTypeWF.Accent);
            label7.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentLight1);
            label8.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentLight2);
            label9.BackColor = UISettings.GetColorValue(UIColorTypeWF.AccentLight3);
            label10.BackColor = UISettings.UIElementColor(UIElementTypeWF.AccentColor);
            label11.BackColor = UISettings.UIElementColor(UIElementTypeWF.ActiveCaption);
            label12.BackColor = UISettings.UIElementColor(UIElementTypeWF.Background);
            label13.BackColor = UISettings.UIElementColor(UIElementTypeWF.ButtonFace);
            label14.BackColor = UISettings.UIElementColor(UIElementTypeWF.ButtonText);
            label15.BackColor = UISettings.UIElementColor(UIElementTypeWF.CaptionText);
            label16.BackColor = UISettings.UIElementColor(UIElementTypeWF.GrayText);
            label17.BackColor = UISettings.UIElementColor(UIElementTypeWF.Highlight);
            label18.BackColor = UISettings.UIElementColor(UIElementTypeWF.HighlightText);
        }
    }
}

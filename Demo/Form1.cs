using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UI.ViewManagement;

namespace Demo
{
    public partial class Form1 : Form
    {
        UISettingsWF uISettingsWF = new UISettingsWF();
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
            uISettingsWF.ColorValuesChanged += UISettingsWF_ColorValuesChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetColor();
        }
        private async void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Color color = label.ForeColor;
            Clipboard.SetText($"{color.R}, {color.G}, {color.B}");
            label.Click -= Label_Click;
            var s = this.Text;
            this.Text += $" - 已复制{label.Text}";
            await Task.Run(() =>
            {
                Thread.Sleep(1500);
            });
            this.Text = s;
        }

        private void UISettingsWF_ColorValuesChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new GetColors(() =>
            {
                GetColor();
            }));
        }

        public delegate void GetColors();

        private void GetColor()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 9; i++)
            {
                UIColorTypeWF wF = (UIColorTypeWF)i;
                Color color = uISettingsWF.GetColorValue(wF);
                Label label = new Label()
                {
                    Margin = new Padding(6),
                    Padding = new Padding(6),
                    AutoSize = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = wF.ToString(),
                    Font = new Font(Font.FontFamily, 12f, FontStyle.Bold),
                    ForeColor = color,
                };
                label.Click += Label_Click;
                flowLayoutPanel1.Controls.Add(label);
            }
        }
    }
}

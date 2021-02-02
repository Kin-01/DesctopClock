using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class SettingsWindow : Form
    {
        PictureBox ClockBox;                                                    // Место хранения для текущего состояния PictureBox`a
        Setting setting;                                                        // Место хранения текущих настроек
        public SettingsWindow(PictureBox ClockBox, Setting setting)
        {
            InitializeComponent();
            this.setting = setting;
            this.ClockBox = ClockBox;

            ColorExampleClock.BackColor = this.setting.ClockColor.Color;
            numericRClock.Value = setting.ClockColor.Color.R;
            numericGClock.Value = setting.ClockColor.Color.G;
            numericBClock.Value = setting.ClockColor.Color.B;

            ColorExampleSecond.BackColor = this.setting.SecondColor;
            numericRSecond.Value = setting.SecondColor.R;
            numericGSecond.Value = setting.SecondColor.G;
            numericBSecond.Value = setting.SecondColor.B;

            ColorExampleMinute.BackColor = this.setting.MinuteColor;
            numericRMinute.Value = setting.MinuteColor.R;
            numericGMinute.Value = setting.MinuteColor.G;
            numericBMinute.Value = setting.MinuteColor.B;

            ColorExampleHour.BackColor = this.setting.HourColor;
            numericRHour.Value = setting.HourColor.R;
            numericGHour.Value = setting.HourColor.G;
            numericBHour.Value = setting.HourColor.B;

            SecondSize.Value = (decimal)(setting.SecondSize * 100);
            MinuteSize.Value = (decimal)(setting.MinuteSize * 100);
            HourSize.Value = (decimal)(setting.HourSize * 100);

            ColorExampleLines.BackColor = this.setting.PenLines.Color;
            numericRLines.Value = setting.PenLines.Color.R;
            numericGLines.Value = setting.PenLines.Color.G;
            numericBLines.Value = setting.PenLines.Color.B;

            ColorExampleFont.BackColor = this.setting.TextColor.Color;
            numericRFont.Value = setting.TextColor.Color.R;
            numericGFont.Value = setting.TextColor.Color.G;
            numericBFont.Value = setting.TextColor.Color.B;

            string[] fonts = { "Russo One", "Microsoft Sans Serif", "MV Boli", "Consolas", "Constantia", "Comic Sans MS", "Times New Roman", "Ubuntu Mono" };
            FontBox.Items.AddRange(fonts);
            FontBox.SelectedItem = setting.FontStyle;
            Image.Checked = setting.DrawImage;
            ChooseImage.Enabled = setting.DrawImage;
        }
        private void RestoreSetting(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("defaultsettings.txt"))
            {
                sr.ReadLine();
                setting.DrawImage = Convert.ToBoolean(sr.ReadLine());
                setting.ImageName = sr.ReadLine();
                setting.FontStyle = sr.ReadLine();
                setting.TextColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                setting.PenLines = new Pen(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())),3);
                setting.ClockColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                setting.SecondColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                setting.MinuteColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                setting.HourColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                setting.SecondSize = Convert.ToSingle(sr.ReadLine());
                setting.MinuteSize = Convert.ToSingle(sr.ReadLine());
                setting.HourSize = Convert.ToSingle(sr.ReadLine());
            }

            ColorExampleLines.BackColor = setting.PenLines.Color;
            numericRLines.Value = setting.PenLines.Color.R;
            numericGLines.Value = setting.PenLines.Color.G;
            numericBLines.Value = setting.PenLines.Color.B;

            ColorExampleClock.BackColor = setting.ClockColor.Color;
            numericRClock.Value = setting.ClockColor.Color.R;
            numericGClock.Value = setting.ClockColor.Color.G;
            numericBClock.Value = setting.ClockColor.Color.B;

            ColorExampleSecond.BackColor = setting.SecondColor;
            numericRSecond.Value = setting.SecondColor.R;
            numericGSecond.Value = setting.SecondColor.G;
            numericBSecond.Value = setting.SecondColor.B;

            ColorExampleMinute.BackColor = setting.MinuteColor;
            numericRMinute.Value = setting.MinuteColor.R;
            numericGMinute.Value = setting.MinuteColor.G;
            numericBMinute.Value = setting.MinuteColor.B;

            ColorExampleHour.BackColor = setting.HourColor;
            numericRHour.Value = setting.HourColor.R;
            numericGHour.Value = setting.HourColor.G;
            numericBHour.Value = setting.HourColor.B;

            SecondSize.Value = (decimal)(setting.SecondSize * 100);
            MinuteSize.Value = (decimal)(setting.MinuteSize * 100);
            HourSize.Value = (decimal)(setting.HourSize * 100);

            ColorExampleFont.BackColor = setting.TextColor.Color;
            numericRFont.Value = setting.TextColor.Color.R;
            numericGFont.Value = setting.TextColor.Color.G;
            numericBFont.Value = setting.TextColor.Color.B;

            FontBox.SelectedItem = setting.FontStyle;
            setting.TextFont = new Font(setting.FontStyle, setting.FontSize);
            setting.DrawImage = false;

            Image.Checked = setting.DrawImage;
            ChooseImage.Enabled = setting.DrawImage;

            ClockBox.Refresh();
        }               // Восстановить настройки по умолчанию

        // Цвет или изображение фона
        private void CheckBoxBackImage(object sender, EventArgs e)
        {
            if (Image.Checked)
            {
                ChooseImage.Enabled = true;
                setting.DrawImage = true;
            }
            else
            {
                ChooseImage.Enabled = false;
                setting.DrawImage = false;
            }
            ClockBox.Refresh();
        }           // Использовать для фона изображение или сплошной цвет
        private void ChooseBackImage(object sender, EventArgs e)
        {
            OpenImage.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            if (OpenImage.ShowDialog() == DialogResult.Cancel)
                return;
            setting.DrawImage = true;
            setting.ImageName = OpenImage.FileName;
            ClockBox.Refresh();
        }             // Выбрать фоновое изображение
        private void RefreshClockColorExample(object sender, EventArgs e)
        {
            ColorExampleClock.BackColor = Color.FromArgb((int)numericRClock.Value, (int)numericGClock.Value, (int)numericBClock.Value);
        }    // Обновлять пример цвета фона часов при изменении данных RGB
        private void ApplyBackColor(object sender, EventArgs e)
        {
            setting.ClockColor = new SolidBrush(ColorExampleClock.BackColor);
            ClockBox.Refresh();
        }              // Применить цвет фона часов

        // Цвет секундной стрелки

        private void RefreshSecondColorExample(object sender, EventArgs e)
        {
            ColorExampleSecond.BackColor = Color.FromArgb((int)numericRSecond.Value, (int)numericGSecond.Value, (int)numericBSecond.Value);
        }   // Обновлять пример цвета секундной стрелки при изменении данных RGB
        private void ApplySecondColor(object sender, EventArgs e)
        {
            setting.r_second = (int)(ClockBox.Width / 2 * (SecondSize.Value / 100));

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_second / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_second / 180);

            setting.x1_second = ClockBox.Width / 2 + setting.r_second * cosFi;
            setting.y1_second = ClockBox.Width / 2 + setting.r_second * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_second_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_second_tail / 180);

            setting.x2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            setting.SecondColor = ColorExampleSecond.BackColor;
            ClockBox.Refresh();
        }            // Применить цвет секундной стрелки

        // Цвет минутной стрелки

        private void RefreshMinuteColorExample(object sender, EventArgs e)
        {
            ColorExampleMinute.BackColor = Color.FromArgb((int)numericRMinute.Value, (int)numericGMinute.Value, (int)numericBMinute.Value);
        }   // Обновлять пример цвета минутной стрелки при изменении данных RGB
        private void ApplyMinuteColor(object sender, EventArgs e)
        {
            setting.r_minute = (int)(ClockBox.Width / 2 * (MinuteSize.Value / 100));

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_minute / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_minute / 180);

            setting.x1_minute = ClockBox.Width / 2 + setting.r_minute * cosFi;
            setting.y1_minute = ClockBox.Width / 2 + setting.r_minute * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_minute_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_minute_tail / 180);

            setting.x2_minute = ClockBox.Width / 2 + ClockBox.Width / 2 * 0.2f * cosFi;
            setting.y2_minute = ClockBox.Width / 2 + ClockBox.Width / 2 * 0.2f * sinFi;

            setting.MinuteColor = ColorExampleMinute.BackColor;
            ClockBox.Refresh();
        }            // Применить цвет минутной стрелки

        // Цвет часовой стрелки

        private void RefreshHourColorExample(object sender, EventArgs e)
        {
            ColorExampleHour.BackColor = Color.FromArgb((int)numericRHour.Value, (int)numericGHour.Value, (int)numericBHour.Value);
        }     // Обновлять пример цвета часовой стрелки при изменении данных RGB
        private void ApplyHourColor(object sender, EventArgs e)
        {
            setting.r_hour = (int)(ClockBox.Width / 2 * (HourSize.Value / 100));

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_hour / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_hour / 180);

            setting.x1_hour = ClockBox.Width / 2 + setting.r_hour * cosFi;
            setting.y1_hour = ClockBox.Width / 2 + setting.r_hour * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_hour_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_hour_tail / 180);

            setting.x2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            setting.HourColor = ColorExampleHour.BackColor;
            ClockBox.Refresh();
        }              // Применить цвет часовой стрелки

        // Цвет чёрточек на часах

        private void RefreshLinesColorExample(object sender, EventArgs e)
        {
            ColorExampleLines.BackColor = Color.FromArgb((int)numericRLines.Value, (int)numericGLines.Value, (int)numericBLines.Value);
        }    // Обновлять пример цвета чёрточек минут и часов при изменении данных RGB
        private void ApplyLinesColor(object sender, EventArgs e)
        {
            setting.PenLines = new Pen(ColorExampleLines.BackColor, 3);
            ClockBox.Refresh();
        }             // Применить цвет минут и часов

        // Цвет и шрифт текста

        private void RefreshFontColorExample(object sender, EventArgs e)
        {
            ColorExampleFont.BackColor = Color.FromArgb((int)numericRFont.Value, (int)numericGFont.Value, (int)numericBFont.Value);
        }     // Обновлять пример цвета цифр при изменении данных RGB
        private void ApplyFontColor(object sender, EventArgs e)
        {
            setting.TextColor = new SolidBrush(ColorExampleFont.BackColor);
            setting.FontStyle = (string)FontBox.SelectedItem;
            setting.TextFont = new Font($"{setting.FontStyle}", setting.FontSize);
            ClockBox.Refresh();
        }              // Применить цвет и шрифт цифр
    }
}

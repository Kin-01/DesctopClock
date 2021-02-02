using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class ClockForm : Form
    {
        Setting setting;                                                // Экземпляр класса "настройки"
        int global_second, global_minute, global_hour;                  // Текущее время
        byte lets_learn_numbers = 0;                                    // Я сижу на карантине,...
        bool party_mode = false;                                        // ...должен же я хоть как-то развлекаться

        public ClockForm()
        {
            InitializeComponent();
            CurrDataTimeTip.SetToolTip(this.ClockBox, DateTime.Now.ToString());
            setting = new Setting();
            setting.LoadSettings();
            ClockBox.MouseDown += new MouseEventHandler((o, e) =>
            {
                ClockBox.Capture = false;
                Message m = Message.Create(base.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);
            });  // Подписывается на событие "MouseEventHandler" (требует разборки или обьяснения)
        }                                           // Конструктор класса (заупскает таймеры, заупскает синхронизаци по времени и подписывается на событие "перемещение окна")
        private void LoadSettings(object sender, EventArgs e)
        {
            Location = new Point(setting.ClockXY.X, setting.ClockXY.Y);
            Size = new Size(setting.ClockSize, setting.ClockSize);
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();  //
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);                                            // Создание окна круглой формы
            Region Form_Region = new Region(Form_Path);                                                     //
            this.Region = Form_Region;                                                                      //
            CheckCurrTime();
        }        // Задание начальной формы и позиции окна (позиция окна на основе последней позиции)
        private void ShowAboutProgramWindows(object sender, EventArgs e)
        {
            AboutProgram ap = new AboutProgram();
            ap.ShowDialog();
        }   // Открыть окно "О программе"
        private void MaximizeClock(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ClockBox.Refresh();
        }  // Развернуть часы, если они были принудительно свёрнуты

        // Настройки

        private void CloseClock(object sender, EventArgs e)
        {
            setting.SaveSettings(Location, Size);
            this.Close();
        }          // Закрыть часы
        private void OpenSettings(object sender, EventArgs e)
        {
            SettingsWindow sf = new SettingsWindow(ClockBox, setting);
            sf.ShowDialog();
        }        // Открыть настройки
        private void SetSmallSize(object sender, EventArgs e)
        {
            setting.ClockSize = 200;
            this.Size = new Size(setting.ClockSize, setting.ClockSize);
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();  //
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);                                            // Создание окна круглой формы
            Region Form_Region = new Region(Form_Path);                                                     //
            this.Region = Form_Region;                                                                      //

            TimeStop();
            CheckCurrTime();
            ClockBox.Refresh();
        }        // Маленькие часы
        private void SetMediumSize(object sender, EventArgs e)
        {
            setting.ClockSize = 300;
            this.Size = new Size(setting.ClockSize, setting.ClockSize);
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();  //
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);                                            // Создание окна круглой формы
            Region Form_Region = new Region(Form_Path);                                                     //
            this.Region = Form_Region;                                                                      //

            TimeStop();
            CheckCurrTime();
            ClockBox.Refresh();
        }       // Средние часы
        private void SetLargeSize(object sender, EventArgs e)
        {
            setting.ClockSize = 500;
            this.Size = new Size(setting.ClockSize, setting.ClockSize);
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();  //
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);                                            // Создание окна круглой формы
            Region Form_Region = new Region(Form_Path);                                                     //
            this.Region = Form_Region;                                                                      //

            TimeStop();
            CheckCurrTime();
            ClockBox.Refresh();
        }        // Большие часы

        // Отрисовка часов

        private void RefreshClock(object sender, PaintEventArgs e)
        {
            setting.PenSecond = new Pen(setting.SecondColor, 2);
            setting.PenMinute = new Pen(setting.MinuteColor, 3);
            setting.PenHour = new Pen(setting.HourColor, 6);

            Graphics g = e.Graphics;

            try
            {
                if (setting.DrawImage && setting.ImageName != "")
                {
                    Image im = Image.FromFile(setting.ImageName);
                    g.DrawImage(im, 0, 0, setting.ClockSize, setting.ClockSize);
                }
                else
                    g.FillRectangle(setting.ClockColor, 0, 0, ClockBox.Width, ClockBox.Height);
            }
            catch
            {
                g.FillRectangle(setting.ClockColor, 0, 0, ClockBox.Width, ClockBox.Height);
            }

            g.DrawEllipse(setting.PenLines, 1, 1, ClockBox.Width - 2, ClockBox.Height - 2);

            int angle = -90;

            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    int len = ClockBox.Width / 8;

                    float cosFi = (float)Math.Cos(Math.PI * angle / 180);
                    float sinFi = (float)Math.Sin(Math.PI * angle / 180);

                    float x2 = ClockBox.Width / 2 + len * 3 * cosFi;
                    float y2 = ClockBox.Width / 2 + len * 3 * sinFi;

                    float x1 = x2 + len * cosFi;
                    float y1 = y2 + len * sinFi;

                    g.DrawLine(setting.PenLines, x1, y1, x2, y2);
                }
                else
                {
                    int len = ClockBox.Width / 16;

                    float cosFi = (float)Math.Cos(Math.PI * angle / 180);
                    float sinFi = (float)Math.Sin(Math.PI * angle / 180);

                    float x1 = ClockBox.Width / 2 + len * 7 * cosFi;
                    float y1 = ClockBox.Width / 2 + len * 7 * sinFi;

                    float x2 = x1 + len * cosFi;
                    float y2 = y1 + len * sinFi;

                    g.DrawLine(setting.PenLines, x1, y1, x2, y2);
                }
                angle += 6;
            }       // Чёрточки на часах

            g.DrawString("3", setting.TextFont, setting.TextColor, ClockBox.Width * 0.79f, ClockBox.Height / 2 * 0.9f);
            g.DrawString("9", setting.TextFont, setting.TextColor, ClockBox.Width * 0.13f, ClockBox.Height / 2 * 0.9f);
            g.DrawString("12", setting.TextFont, setting.TextColor, ClockBox.Height / 2 * 0.9f, ClockBox.Height * 0.13f);
            g.DrawString("6", setting.TextFont, setting.TextColor, ClockBox.Height / 2 * 0.9f, ClockBox.Height * 0.76f);

            double debug = Math.Sqrt(Math.Pow(setting.x2_second - setting.x1_second, 2) + Math.Pow(setting.y2_second - setting.y1_second, 2));

            g.DrawLine(setting.PenSecond, setting.x1_second, setting.y1_second, setting.x2_second, setting.y2_second);                // Секунды
            g.DrawLine(setting.PenMinute, setting.x1_minute, setting.y1_minute, setting.x2_minute, setting.y2_minute);                // Минуты
            g.DrawLine(setting.PenHour, setting.x1_hour, setting.y1_hour, setting.x2_hour, setting.y2_hour);                          // Часы

            if (party_mode)
            {
                Image cucmber = Image.FromFile(@"BackgroundImagesSample/Cucumber.png");
                g.DrawImage(cucmber, ClockBox.Width / 2 - 75, ClockBox.Height / 2 - 75, 150, 150);
            }
            else
                g.FillPie(new SolidBrush(Color.Black), ClockBox.Width / 2 - setting.DotSize / 2, ClockBox.Height / 2 - setting.DotSize / 2, setting.DotSize, setting.DotSize, 0, 360); // Круг, соединяющий стрелки
        }   // Обновить часы

        // Методы, связанные с временем

        private void TimeStart()
        {
            timersecond.Start();
            timerminute.Start();
            timerhour.Start();
        }                                     // Включить счетчик времени
        private void TimeStop()
        {
            timersecond.Stop();
            timerminute.Stop();
            timerhour.Stop();
        }                                      // Выключить счётчик времени
        private void Tick_Second(object sender, EventArgs e)
        {
            setting.fi_second += 6;
            setting.fi_second_tail += 6;

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_second / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_second / 180);

            setting.x1_second = ClockBox.Width / 2 + setting.r_second * cosFi;
            setting.y1_second = ClockBox.Width / 2 + setting.r_second * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_second_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_second_tail / 180);

            setting.x2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            CurrDataTimeTip.SetToolTip(this.ClockBox, DateTime.Now.ToString());
            ClockBox.Refresh();
        }         // +1 секунда
        private void Tick_Minute(object sender, EventArgs e)
        {
            setting.fi_minute += 6;
            setting.fi_minute_tail += 6;

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_minute / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_minute / 180);

            setting.x1_minute = ClockBox.Width / 2 + setting.r_minute * cosFi;
            setting.y1_minute = ClockBox.Width / 2 + setting.r_minute * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_minute_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_minute_tail / 180);

            setting.x2_minute = ClockBox.Width / 2 + ClockBox.Width / 2 * 0.2f * cosFi;
            setting.y2_minute = ClockBox.Width / 2 + ClockBox.Width / 2 * 0.2f * sinFi;

            ClockBox.Refresh();
        }         // +1 минута
        private void Tick_Hour(object sender, EventArgs e)
        {
            setting.fi_hour += 30;
            setting.fi_hour_tail += 30;

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_hour / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_hour / 180);

            setting.x1_hour = ClockBox.Width / 2 + setting.r_hour * cosFi;
            setting.y1_hour = ClockBox.Width / 2 + setting.r_hour * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_hour_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_hour_tail / 180);

            setting.x2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            ClockBox.Refresh();
        }           // +1 час
        private void LetsParty(object sender, KeyEventArgs e)
        {
            string cheatcode = "CUCUMBER";
            if ((char)e.KeyCode == cheatcode[lets_learn_numbers])
                lets_learn_numbers++;
            else
                lets_learn_numbers = 0;
            if (lets_learn_numbers == cheatcode.Length)
            {
                party_mode = !party_mode;
                lets_learn_numbers = 0;
                ClockBox.Refresh();
            }
        }        // Должен же я как-то развлечься?
        private void CheckCurrTime()
        {
            setting.FontSize = (int)(setting.ClockSize / 3 * 0.17f);
            setting.DotSize = setting.ClockSize / 2 * 0.1f;
            setting.TextFont = new Font(setting.FontStyle, setting.FontSize);

            global_second = DateTime.Now.Second;
            global_minute = DateTime.Now.Minute;
            global_hour = DateTime.Now.Hour;

            int second = global_second * 6;
            int minute = global_minute * 6;
            int hour = global_hour * 30;

            setting.fi_second = second - 84;
            setting.fi_minute = minute - 90;
            setting.fi_hour = hour - 90;

            setting.r_second = (int)(ClockBox.Width / 2 * setting.SecondSize);
            setting.r_minute = (int)(ClockBox.Width / 2 * setting.MinuteSize);
            setting.r_hour = (int)(ClockBox.Width / 2 * setting.HourSize);

            float cosFi = (float)Math.Cos(Math.PI * setting.fi_second / 180);
            float sinFi = (float)Math.Sin(Math.PI * setting.fi_second / 180);
            setting.x1_second = ClockBox.Width / 2 + setting.r_second * cosFi;
            setting.y1_second = ClockBox.Width / 2 + setting.r_second * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_minute / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_minute / 180);
            setting.x1_minute = ClockBox.Width / 2 + setting.r_minute * cosFi;
            setting.y1_minute = ClockBox.Width / 2 + setting.r_minute * sinFi;

            cosFi = (float)Math.Cos(Math.PI * setting.fi_hour / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_hour / 180);
            setting.x1_hour = ClockBox.Width / 2 + setting.r_hour * cosFi;
            setting.y1_hour = ClockBox.Width / 2 + setting.r_hour * sinFi;

            /////////////////////////

            setting.fi_second_tail = setting.fi_second + 180;
            cosFi = (float)Math.Cos(Math.PI * setting.fi_second_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_second_tail / 180);
            setting.x2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_second = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            setting.fi_minute_tail = setting.fi_minute + 180;
            cosFi = (float)Math.Cos(Math.PI * setting.fi_minute_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_minute_tail / 180);
            setting.x2_minute = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_minute = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            setting.fi_hour_tail = setting.fi_hour + 180;
            cosFi = (float)Math.Cos(Math.PI * setting.fi_hour_tail / 180);
            sinFi = (float)Math.Sin(Math.PI * setting.fi_hour_tail / 180);
            setting.x2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * cosFi;
            setting.y2_hour = ClockBox.Width / 2 + (ClockBox.Width / 2 * 0.2f) * sinFi;

            TimeStart();
        }                                 // Синхронизация времени и установка начальных данных (выполняется один раз при запуске программы)
    }
    public class Setting
    {
        public Font TextFont;                                           // Шрифт на часах (масштабируемо)
        public string FontStyle;                                        // Название шрифта на часах
        public SolidBrush TextColor;                                    // Цвет текста
        public int FontSize;                                            // Размер текста на часах (масштабируемо)

        public bool DrawImage = false;                                  // Фон часов изображение или сплошной цвет
        public string ImageName;                                        // Название изображения для часов

        public Color SecondColor;                                       // Цвет секундной стрелки
        public Color MinuteColor;                                       // Цвет минутной стрелки
        public Color HourColor;                                         // Цвет часовой стрелки
        public SolidBrush ClockColor;                                   // Цвет фона часов

        public float SecondSize;                                        // Размер секундной стрелки в процентном соотношении
        public float MinuteSize;                                        // Размер минутной стрелки в процентном соотношении
        public float HourSize;                                          // Размер часовой стрелки в процентном соотношении

        public Pen PenSecond;                                           // Карандаш для отрисовки стрелки "Секунда"
        public Pen PenMinute;                                           // Карандаш для отрисовки стрелки "Минута"
        public Pen PenHour;                                             // Карандаш для открисовки стрелки "Час"
        public Pen PenLines;                                            // Карандаш для открисовки полосочек на часах

        public int r_second, r_minute, r_hour;                          // Длина стрелок (масштабируемо)

        public float DotSize;                                           // Размер точки, соединяющей стрелки (масштабируемо)
        public int ClockSize;                                           // Размер часов
        public Point ClockXY;                                           // Позиция часов при запуске

        public float x1_second, x1_minute, x1_hour;                     // Координата Х начала стрелок (масштабируемо)
        public float y1_second, y1_minute, y1_hour;                     // Координата Y начала стрелок (масштабируемо)
        public float x2_second, x2_minute, x2_hour;                     // Координата Х конца стрелок (масштабируемо)
        public float y2_second, y2_minute, y2_hour;                     // Координата Y конца стрелок (масштабируемо)

        public int fi_second, fi_minute, fi_hour;                       // Текущая градусная мера угла для 3 стрелок
        public int fi_second_tail, fi_minute_tail, fi_hour_tail;        // Текущая градусная мера угла для 3 концов стрелок

        public void LoadSettings()
        {
            try
            {
                using (StreamReader sr = new StreamReader("settings.txt"))
                {
                    ClockXY = new Point(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    ClockSize = Convert.ToInt32(sr.ReadLine());
                    DrawImage = Convert.ToBoolean(sr.ReadLine());
                    ImageName = sr.ReadLine();
                    FontStyle = sr.ReadLine();
                    TextColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                    PenLines = new Pen(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())), 3);
                    ClockColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                    SecondColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    MinuteColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    HourColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    SecondSize = Convert.ToSingle(sr.ReadLine());
                    MinuteSize = Convert.ToSingle(sr.ReadLine());
                    HourSize = Convert.ToSingle(sr.ReadLine());
                }
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить файл сохранения.\n" +
                    "Возможно он повреждён или удалён.\n" +
                    "Восстановлены настройки по умолчанию", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                using (StreamReader sr = new StreamReader("defaultsettings.txt"))
                {
                    ClockSize = Convert.ToInt32(sr.ReadLine());
                    DrawImage = Convert.ToBoolean(sr.ReadLine());
                    ImageName = sr.ReadLine();
                    FontStyle = sr.ReadLine();
                    TextColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                    PenLines = new Pen(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())), 3);
                    ClockColor = new SolidBrush(Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine())));
                    SecondColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    MinuteColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    HourColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                    SecondSize = Convert.ToSingle(sr.ReadLine());
                    MinuteSize = Convert.ToSingle(sr.ReadLine());
                    HourSize = Convert.ToSingle(sr.ReadLine());
                }
            }
        }                                   // Загрузка нстроек
        public void SaveSettings(Point Location, Size size)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("settings.txt"))
                {
                    sw.WriteLine($"" +
                        $"{Location.X}\n{Location.Y}\n{size.Width}\n" +
                        $"{DrawImage}\n" +
                        $"{ImageName}\n" +
                        $"{FontStyle}\n" +
                        $"{TextColor.Color.R}\n{TextColor.Color.G}\n{TextColor.Color.B}\n" +
                        $"{PenLines.Color.R}\n{PenLines.Color.G}\n{PenLines.Color.B}\n" +
                        $"{ClockColor.Color.R}\n{ClockColor.Color.G}\n{ClockColor.Color.B}\n" +
                        $"{SecondColor.R}\n{SecondColor.G}\n{SecondColor.B}\n" +
                        $"{MinuteColor.R}\n{MinuteColor.G}\n{MinuteColor.B}\n" +
                        $"{HourColor.R}\n{HourColor.G}\n{HourColor.B}\n" +
                        $"{SecondSize}\n{MinuteSize}\n{HourSize}");
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить настройки.\n" +
                                "Попробуйте удалить файл сохранения или вернуться к заводским настройкам" 
                                ,"Внутренняя ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }          // Сохранение настроек
    }
}

using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorMove
{
    public partial class Form1 : Form
    {
        private int hour = int.Parse(ConfigurationManager.AppSettings["hour"]);
        private int freq = int.Parse(ConfigurationManager.AppSettings["frequency"]);
        private int waitPeriod;
        private int chk = 1;

        public Form1()
        {
            InitializeComponent();
            waitPeriod = ConvertFreq(freq);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int hour = 1;
            int times = 1 * 3600 / 3;
            while (times > 0)
            {
                var rnd = new Random();
                var rndx = rnd.Next(-100, 100);
                var rndy = rnd.Next(-100, 100);
                MoveCursor(rndx, rndy);
                await Task.Delay(waitPeriod * 1000);
                times--;
                if (chk == 0)
                {
                    break;
                }
            }
        }

        private void MoveCursor(int x, int y)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void button2_Click(object sender, EventArgs e) => chk = 0;

        private int ConvertFreq(int freq)
        {
            return 60 / freq;
        }
    }
}
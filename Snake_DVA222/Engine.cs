using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    internal class Engine
    {
        MainForm _form = new MainForm();
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public void Run()
        {
            // Avkommentera efter implementation
            //_form.Paint += Draw;

            _timer.Tick += TimerEventHandler;
            _timer.Interval = 1000 / 30; // 30 fps lets goo
            _timer.Start();
            Application.Run(_form);
        }

        private void Draw(object? sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TimerEventHandler(object? sender, EventArgs e)
        {
            
            _form.Refresh();
        }
    }
}

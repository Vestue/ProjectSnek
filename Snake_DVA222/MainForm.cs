namespace Snake_DVA222
{
    public partial class MainForm : Form
    {
        Engine _engine;
        public MainForm(object sender)
        {
            // Oklart om typkonverteringen behövs där med w.e
            if (sender is Engine) _engine = (Engine)sender;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _engine.StartGame(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _engine.StartGame(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
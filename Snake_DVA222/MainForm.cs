namespace Snake_DVA222
{
    public partial class MainForm : Form
    {
        Engine? _engine;
        public MainForm(object sender)
        {
            // Oklart om typkonverteringen behövs där med w.e
            if (sender is Engine) _engine = (Engine)sender;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // EXTENSION
        // (Not really an extension) Changed color to match a flag
        // Also changed text color to white for added visibility 
        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            ScoreDisplay.Enabled = true;
            ScoreDisplay.Visible = true;
            if (_engine != null) _engine.StartGame(1);
        }

        // EXTENSION
        // (Not really an extension) Changed color to match a flag
        // Also changed text color to white for added visibility 
        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
            ScoreDisplay.Enabled = true;
            ScoreDisplay.Visible = true;
            if (_engine != null) _engine.StartGame(2);
        }

        // EXTENSION
        // Button for 3 players, exitButton was formerly called button 3
        private void button3_Click(object sender, EventArgs e)
        {
            ClearForm();
            ScoreDisplay.Enabled = true;
            ScoreDisplay.Visible = true;
            if (_engine != null) _engine.StartGame(3);
        }

        // EXTENSION
        // exitButton was formerly called button 3
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            exitButton.Enabled = false;
            exitButton.Visible = false;
            textBox1.Visible = false;
            textBox1.Enabled = false;
        }

        public void RestartMenu()
        {
            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = true;
            button2.Visible = true;
            button3.Enabled = true;
            button3.Visible = true;
            exitButton.Enabled = true;
            exitButton.Visible = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            ScoreDisplay.Enabled = false;
            ScoreDisplay.Visible = false;
        }
    }
}
namespace Snake_DVA222
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Maybe useful
            ApplicationConfiguration.Initialize();

            // Nah brah
            //Application.Run(new Form1());
            
            Engine _engine = new Engine();
            _engine.Run();
        }
    }
}
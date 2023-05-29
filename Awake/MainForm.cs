namespace Awake
{
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        private ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        public MainForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            // Create the NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(Environment.CurrentDirectory + "\\logo.ico");
            notifyIcon.Text = "Awake";

            // Show the form when the NotifyIcon is double-clicked
            notifyIcon.DoubleClick += (sender, e) =>
            {
                ShowMainForm();
                WindowState = FormWindowState.Normal;
            };

            contextMenuStrip = new ContextMenuStrip();

            // Add an exit menu item
            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += (sender, e) => ExitApplication();
            contextMenuStrip.Items.Add(exitMenuItem);

            // Assign the context menu strip to the NotifyIcon
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // Display the NotifyIcon in the system tray
            notifyIcon.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideMainForm();
            MouseMover mouseMover = new MouseMover();
            Task.Run(() => mouseMover.Start());
        }

        private void ShowMainForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void HideMainForm()
        {
            WindowState = FormWindowState.Minimized;
            Hide();
            ShowInTaskbar = false;
        }

        private void ExitApplication()
        {
            // Clean up and exit the application
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}

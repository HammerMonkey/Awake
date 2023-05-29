using System;
using System.Windows;

namespace AwakeWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }

        //private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    NotifyIcon.Dispose();
        //    Application.Current.Shutdown();
        //}

        private void ShowMainWindow()
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void HideMainWindow()
        {
            WindowState = WindowState.Minimized;
            Hide();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                HideMainWindow();
            }
            base.OnStateChanged(e);
        }
    }
}

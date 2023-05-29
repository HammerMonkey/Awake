using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AwakeWPF
{
    public class NotifyIconManager
    {
        private Image notifyIconImage = new Image();
        private Window mainWindow = new Window();

        public void InitializeNotifyIcon(Window window)
        {
            mainWindow = window;

            // Create the Image control for the notify icon
            notifyIconImage = new Image();
            notifyIconImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\logo.ico"));
            notifyIconImage.MouseDown += NotifyIconImage_MouseDown;

            // Set the properties for the notify icon
            mainWindow.StateChanged += MainWindow_StateChanged;
        }

        private void NotifyIconImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                ShowMainWindow();
            }
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (mainWindow.WindowState == WindowState.Minimized)
            {
                HideMainWindow();
            }
        }

        private void ShowMainWindow()
        {
            mainWindow.Show();
            mainWindow.WindowState = WindowState.Normal;
        }

        private void HideMainWindow()
        {
            mainWindow.Hide();
        }
    }
}

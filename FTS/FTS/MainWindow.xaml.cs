using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FTS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_MAXIMIZEBOX = 0x10000;

        private int TimesLeft = 30;

        private int animateTruck = 0;

        private DispatcherTimer timer;

        private DispatcherTimer carController;

        private DispatcherTimer countdown;

        private int isFullScreen = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        bool isWarned = false;

        private void CarController_Tick(object sender, EventArgs e)
        {

        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            TimesLeft--;
            if(TimesLeft >= 10)
            {
                timerText.Text = "00:" + TimesLeft.ToString();
            }
            else
            {
                timerText.Text = "00:0" + TimesLeft.ToString();
            }

            if(TimesLeft == 0)
            {
                countdown.Stop();
                timer.Stop();
                KeyDown -= KeyDownHandler;
                timer.Tick -= Timer_Tick;
                countdown.Tick -= Countdown_Tick;
                CoverOver.Visibility = Visibility.Visible;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (animateTruck == 0)
            {
                FireTruck.Source = new BitmapImage(new Uri("/Assets/units/animate/firetruck2.png", UriKind.RelativeOrAbsolute));
                animateTruck = 1;
            }
            else
            {
                FireTruck.Source = new BitmapImage(new Uri("/Assets/units/animate/firetruck1.png", UriKind.RelativeOrAbsolute));
                animateTruck = 0;
            }
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            var hwnd = new WindowInteropHelper((Window)sender).Handle;
            var value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & ~WS_MAXIMIZEBOX));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        async void KeyDownHandler(object sender, KeyEventArgs e)
        {
            double left = FireTruck.Margin.Left;
            double top = FireTruck.Margin.Bottom;
            switch(e.Key)
            {
                // Do a check so that the truck does not cut off the side.
                case Key.Left:
                    left -= 5;
                    FireTruck.Margin = new Thickness(left, 0, 0, top);
                    if (left == -570)
                    {
                        KeyDown -= KeyDownHandler;
                        TimesLeft = 30;
                        FireTruck.Margin = new Thickness(110, 142, -110, 143);
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        BSOD.Visibility = Visibility.Visible;
                        Cursor = Cursors.None;
                        countdown.Stop();
                        timer.Stop();
                        timer.Tick -= Timer_Tick;
                        countdown.Tick -= Countdown_Tick;
                        await Task.Delay(5000);
                        BSOD.Visibility = Visibility.Collapsed;
                        if (isFullScreen == 0)
                        {
                            WindowState = WindowState.Normal;
                            WindowStyle = WindowStyle.SingleBorderWindow;
                        }
                        Cursor = Cursors.Arrow;
                        CoverOver.Visibility = Visibility.Visible;
                    }
                    break;
                case Key.Right:
                    left += 5;
                    FireTruck.Margin = new Thickness(left, 0, 0, top);
                    if (left == 565)
                    {
                        KeyDown -= KeyDownHandler;
                        TimesLeft = 30;

                        FireTruck.Margin = new Thickness(110, 142, -110, 143);
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        BSOD.Visibility = Visibility.Visible; Cursor = Cursors.None;
                        countdown.Stop();
                        timer.Stop();
                        timer.Tick -= Timer_Tick;
                        countdown.Tick -= Countdown_Tick;
                        await Task.Delay(5000);
                        BSOD.Visibility = Visibility.Collapsed;
                        if (isFullScreen == 0)
                        {
                            WindowState = WindowState.Normal;
                            WindowStyle = WindowStyle.SingleBorderWindow;
                        }
                        KeyDown += KeyDownHandler; Cursor = Cursors.Arrow;
                        CoverOver.Visibility = Visibility.Visible;
                    }
                    break;
                case Key.Up:
                    top += 5;
                    FireTruck.Margin = new Thickness(left, 0, 0, top);
                    if (top == 273)
                    {
                        KeyDown -= KeyDownHandler;
                        TimesLeft = 30;

                        FireTruck.Margin = new Thickness(110, 142, -110, 143);
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        BSOD.Visibility = Visibility.Visible; Cursor = Cursors.None;
                        countdown.Stop();
                        timer.Stop();
                        timer.Tick -= Timer_Tick;
                        countdown.Tick -= Countdown_Tick;
                        await Task.Delay(5000);
                        BSOD.Visibility = Visibility.Collapsed;
                        if (isFullScreen == 0)
                        {
                            WindowState = WindowState.Normal;
                            WindowStyle = WindowStyle.SingleBorderWindow;
                        }
                        KeyDown += KeyDownHandler; Cursor = Cursors.Arrow;
                        CoverOver.Visibility = Visibility.Visible;
                    }
                    break;
                case Key.Down:
                    top-= 5;
                    FireTruck.Margin = new Thickness(left, 0, 0, top);
                    if (top == -277)
                    {
                        KeyDown -= KeyDownHandler;
                        TimesLeft = 30;

                        FireTruck.Margin = new Thickness(110, 142, -110, 143);
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        BSOD.Visibility = Visibility.Visible; Cursor = Cursors.None;
                        countdown.Stop();
                        timer.Stop();
                        timer.Tick -= Timer_Tick;
                        countdown.Tick -= Countdown_Tick;
                        await Task.Delay(5000);
                        BSOD.Visibility = Visibility.Collapsed;
                        if(isFullScreen == 0)
                        {
                            WindowState = WindowState.Normal;
                            WindowStyle = WindowStyle.SingleBorderWindow;
                        }
                        KeyDown += KeyDownHandler; Cursor = Cursors.Arrow;
                        CoverOver.Visibility = Visibility.Visible;
                    }
                    break;
            }

            e.Handled = true;
        }

        private void NewGameBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            NewGameBtn.Source = new BitmapImage(new Uri("/Assets/buttons/BtNewGame_Select.bmp", UriKind.RelativeOrAbsolute));
        }

        private void NewGameBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            NewGameBtn.Source = new BitmapImage(new Uri("/Assets/buttons/BtNewGame.bmp", UriKind.RelativeOrAbsolute));
        }

        private void NewGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimesLeft = 30;
            timerText.Text = "00:30";
            CoverOver.Visibility = Visibility.Collapsed;
            Cover.Visibility = Visibility.Collapsed;
            KeyDown += KeyDownHandler;
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            FireTruck.Margin = new Thickness(110, 142, -110, 143);
            countdown = new DispatcherTimer();
            countdown.Interval = TimeSpan.FromSeconds(1);
            countdown.Tick += Countdown_Tick;
            timer.Tick += Timer_Tick;
            timer.Start();
            countdown.Start();
        }

        private void FullScreenM_MouseEnter(object sender, MouseEventArgs e)
        {
            if(isFullScreen == 0)
            {
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOff_Select.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOff_Select.bmp", UriKind.RelativeOrAbsolute));
            }
            else if(isFullScreen == 1)
            {
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn_Select.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn_Select.bmp", UriKind.RelativeOrAbsolute));
            }
        }

        private void FullScreenM_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isFullScreen == 0)
            {
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOff.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOff.bmp", UriKind.RelativeOrAbsolute));
            }
            else if (isFullScreen == 1)
            {
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn.bmp", UriKind.RelativeOrAbsolute));
            }
        }

        private void FullScreenM_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(isFullScreen == 0)
            {
                isFullScreen = 1;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn.bmp", UriKind.RelativeOrAbsolute));
            }
            else
            {
                isFullScreen = 0;
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                FullScreenM.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOff.bmp", UriKind.RelativeOrAbsolute));
                FullScreenM2.Source = new BitmapImage(new Uri("/Assets/buttons/BtFullscreenOn.bmp", UriKind.RelativeOrAbsolute));
            }
        }

        private void NewGameBtn2_MouseEnter(object sender, MouseEventArgs e)
        {
            NewGameBtn2.Source = new BitmapImage(new Uri("/Assets/buttons/BtTryAgain_Select.bmp", UriKind.RelativeOrAbsolute));
        }

        private void NewGameBtn2_MouseLeave(object sender, MouseEventArgs e)
        {
            NewGameBtn2.Source = new BitmapImage(new Uri("/Assets/buttons/BtTryAgain.bmp", UriKind.RelativeOrAbsolute));

        }

        private void Quiz_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri("/Assets/buttons/BtExit_Select.bmp", UriKind.RelativeOrAbsolute));
        }

        private void Quiz_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Quiz_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri("/Assets/buttons/BtExit.bmp", UriKind.RelativeOrAbsolute));
        }
    }
}

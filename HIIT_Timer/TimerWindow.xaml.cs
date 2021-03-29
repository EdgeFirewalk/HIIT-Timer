using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;

namespace HIIT_Timer
{
    public partial class TimerWindow : Window
    {
        private int exerciseTimeFromMain; // Time for working out that we get from previous window
        private int restTimeFromMain;    // Time for rest that we get from previous window

        private int exerciseTime; // Time for working out (seconds)
        private int restTime;    // Time for rest (seconds)
        private int exerciseNumber = 1;

        private MainWindow mainWin; // Reference to main window (settings window)

        private DispatcherTimer timer;
        private bool timerIsRunning = true;

        private SoundPlayer countdownSound = new SoundPlayer();
        private SoundPlayer countdownStopSound = new SoundPlayer();

        public TimerWindow(int exerciseTime, int restTime, MainWindow mainWin)
        {
            exerciseTimeFromMain = exerciseTime;
            restTimeFromMain = restTime;
            this.mainWin = mainWin;

            // Trying to load audio files
            try
            {
                countdownSound.SoundLocation = "Media\\Countdown.wav";
                countdownSound.Load();

                countdownStopSound.SoundLocation = "Media\\CountdownStop.wav";
                countdownStopSound.Load();
            }
            catch (Exception)
            {
                MessageBox.Show("Some audio files were not found...");
            }

                InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            exerciseTime = exerciseTimeFromMain;
            restTime = restTimeFromMain;

            timeLabel.Content = Convert.ToString(exerciseTime);

            exerciseLabel.Content = Convert.ToString($"Exercise: {exerciseNumber++}");

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (exerciseTime != 0)
            {
                WorkingOut();
            }
            else if (exerciseTime == 0 && restTime != 0)
            {
                RestBreak();
            }
            else if (exerciseTime == 0 & restTime == 0)
            {
                // Exercise completed
                exerciseLabel.Content = Convert.ToString($"Exercise: {exerciseNumber++}");

                exerciseTime = exerciseTimeFromMain; //
                restTime = restTimeFromMain;        // Zeroing variables to start timer again
            }
        }

        private void WorkingOut()
        {
            stageLabel.Content = "Working Out!";

            exerciseTime--;

            timeLabel.Content = Convert.ToString(exerciseTime);

            if (exerciseTime <= 5 && exerciseTime > 0)
            {
                countdownSound.Play();
            }
            else if (exerciseTime == 0)
            {
                countdownStopSound.Play();

                // Do not show the 0 second (Just jump onto next step)
                timeLabel.Content = Convert.ToString(restTime);
                stageLabel.Content = "Rest Break!";
            }
        }

        private void RestBreak()
        {
            stageLabel.Content = "Rest Break!";

            restTime--;

            timeLabel.Content = Convert.ToString(restTime);

            if (restTime <= 5 && restTime > 0)
            {
                countdownSound.Play();
            }
            else if (restTime == 0)
            {
                countdownStopSound.Play();

                // Do not show the 0 second (Just jump onto next step)
                timeLabel.Content = Convert.ToString(exerciseTime);
                stageLabel.Content = "Working Out!";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            timer.Stop();
            mainWin.Show();
        }

        private void HIIT_Timer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && timerIsRunning)
            {
                timer.Stop();
                timerIsRunning = false;

                timeLabel.Foreground = Brushes.CornflowerBlue;
            }
            else if (e.Key == Key.Space && !timerIsRunning)
            {
                timer.Start();
                timerIsRunning = true;

                timeLabel.Foreground = Brushes.White;
            }

            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}

using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Media;

namespace HIIT_Timer
{
    public partial class TimerWindow : Window
    {
        private int exerciseTimeFromMain; // Time for working out that we get from previous window
        private int restTimeFromMain;    // Time for rest that we get from previous window

        private int exerciseTime; // Time for working out (seconds)

        private int restTime;    // Time for rest (seconds)
        private bool resting;

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

            exerciseLabel.Content = Convert.ToString($"Exercise: {exerciseNumber}");

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (exerciseTime != 0)
            {
                Workout();
            }
            else
            {
                RestBreak();
            }
        }

        private void Workout()
        {
            timeLabel.Foreground = Brushes.White;
            stageLabel.Content = "Working Out!";

            exerciseTime--;

            timeLabel.Content = Convert.ToString(exerciseTime);

            if (exerciseTime <= 5 && exerciseTime > 0)
            {
                timeLabel.Foreground = Brushes.LightGreen;
                countdownSound.Play();
            }
            else if (exerciseTime == 0)
            {
                countdownStopSound.Play();

                restTime = restTimeFromMain; // Zeroing variable to start timer again

                // Do not show the 0 second (Just jump onto next step)
                timeLabel.Content = Convert.ToString(restTime);
                stageLabel.Content = "Rest Break!";
            }
        }

        private void RestBreak()
        {
            resting = true;

            timeLabel.Foreground = Brushes.White;

            stageLabel.Content = "Rest Break!";

            restTime--;

            timeLabel.Content = Convert.ToString(restTime);

            if (restTime <= 5 && restTime > 0)
            {
                timeLabel.Foreground = Brushes.Red;
                countdownSound.Play();
            }
            else if (restTime == 0)
            {
                countdownStopSound.Play();

                exerciseTime = exerciseTimeFromMain; // Zeroing variable to start timer again

                // Do not show the 0 second (Just jump onto next step)
                timeLabel.Content = Convert.ToString(exerciseTime);
                stageLabel.Content = "Working Out!";

                // After each rest break you start next exercise
                exerciseLabel.Content = Convert.ToString($"Exercise: {++exerciseNumber}");
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

                countdownSound.Play();

                timerIsRunning = false;

                timeLabel.Foreground = Brushes.CornflowerBlue;
            }
            else if (e.Key == Key.Space && !timerIsRunning)
            {
                timer.Start();

                countdownStopSound.Play();

                timerIsRunning = true;

                timeLabel.Foreground = Brushes.White;
            }

            if (e.Key == Key.Up && resting && restTime < 1000)
            {
                restTime += 10;
            }
            else if (e.Key == Key.Down && resting && restTime > 10)
            {
                restTime -= 10;
            }
            else if (e.Key == Key.Enter && resting)
            {
                exerciseTime = exerciseTimeFromMain; // Zeroing variable
                resting = false;
                countdownStopSound.Play();
                Workout();
            }

            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}

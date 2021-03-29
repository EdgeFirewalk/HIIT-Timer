using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HIIT_Timer
{
    public partial class MainWindow : Window
    {
        private const int secondsPerExercise = 60;
        private int exerciseTime = 45; // Seconds
        private int restTime = 15;    // Seconds

        TimerWindow timerWin; // Reference to window with timer

        public MainWindow()
        {
            InitializeComponent();
        }

        private void exerciceTimeBox_GotFocus(object sender, RoutedEventArgs e)
        {
            exerciceTimeBox.Clear();
        }

        private void exerciceTimeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExerciceAndRestTimeShenanigans();
            }
        }

        private void ExerciceAndRestTimeShenanigans()
        {
            try
            {
                exerciseTime = Convert.ToInt32(exerciceTimeBox.Text);

                if (exerciseTime > 60)
                {
                    exerciceTimeBox.Text = "60"; // Maximal value for time for the exercise per minute
                    exerciseTime = Convert.ToInt32(exerciceTimeBox.Text);
                }
                else if (exerciseTime < 15)
                {
                    exerciceTimeBox.Text = "15"; // Minimal value for the exercise
                    exerciseTime = Convert.ToInt32(exerciceTimeBox.Text);
                }
                

                restTime = secondsPerExercise - exerciseTime;
                restTimeLabel.Content = Convert.ToString(restTime);
            }
            catch (Exception)
            {
                exerciceTimeBox.Text = "45";
                exerciseTime = Convert.ToInt32(exerciceTimeBox.Text);
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ExerciceAndRestTimeShenanigans();
            timerWin = new TimerWindow(exerciseTime, restTime, this);
            timerWin.Show();
            this.Hide();
        }

        private void HIIT_Timer_Settings_Closed(object sender, EventArgs e)
        {
            timerWin.Close();
        }
    }
}
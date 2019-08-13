using System;
using System.Windows.Forms;
using System.Threading;

namespace CW_3._3_1
{
    /// <summary>
    /// The main form of the app
    /// </summary>
    public partial class Background : Form
    {
        /// <summary>
        /// Is StartButton clicked
        /// </summary>
        private bool isStartButtonClicked = true;

        /// <summary>
        /// Is Timer working as delayer
        /// </summary>
        private bool isTimerWorkingAsDelayer = false;

        /// <summary>
        /// Forms initializing
        /// </summary>
        public Background()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start progressing bar once
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBarStartButton_Click(object sender, EventArgs e)
        {
            if (isStartButtonClicked)
            {
                isStartButtonClicked = false;
                Timer.Start();
            }
        }

        /// <summary>
        /// Fill progress bar monotonely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Value != ProgressBar.Maximum)
            {
                ProgressBar.PerformStep();
            }
            else
            {
                Timer.Stop();
                if (!isTimerWorkingAsDelayer)
                {
                    isTimerWorkingAsDelayer = true;
                    Timer.Interval = 500;
                    Timer.Start();
                }
                else
                {
                    CloseButton.Visible = true;
                }
            }
        }

        /// <summary>
        /// Close the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

using System;
using System.Windows.Forms;

namespace Watch
{
    /// <summary>
    /// The background of the app
    /// </summary>
    public partial class Background : Form
    {
        /// <summary>
        /// Set current time to watch
        /// </summary>
        private void SetCurrentTime()
        {
            var date = DateTime.Now;

            var hourNumber = date.Hour;
            HourLabel1.Text = Convert.ToString(hourNumber / 10);
            HourLabel2.Text = Convert.ToString(hourNumber % 10);
            
            var minuteNumber = date.Minute;
            MinuteLabel1.Text = Convert.ToString(minuteNumber / 10);
            MinuteLabel2.Text = Convert.ToString(minuteNumber % 10);

            var secondNumber = date.Second;
            SecondLabel1.Text = Convert.ToString(secondNumber / 10);
            SecondLabel2.Text = Convert.ToString(secondNumber % 10);
        }

        /// <summary>
        /// Constructor: initialize forms and current time
        /// </summary>
        public Background()
        {
            InitializeComponent();
            SetCurrentTime();
        }

        /// <summary>
        /// Data type for every watch element
        /// </summary>
        enum TimeLabel { HOUR1, HOUR2, MIN1, MIN2, SEC1, SEC2 };

        /// <summary>
        /// Check if digit is in corrent range as for time
        /// </summary>
        /// <param name="digit">The checking digit</param>
        /// <param name="high">The value incorrect digits begin</param>
        private void CheckIfDigitInRange(int digit, int minOutDigit = 10)
        {
            if (digit < 0 || digit >= minOutDigit)
            {
                throw new DataMisalignedException();
            }
        }

        /// <summary>
        /// Add time to watch
        /// </summary>
        /// <param name="timeLabel">The element of watch to be increased</param>
        private void AddTime(TimeLabel timeLabel = TimeLabel.SEC2)
        {
            int digit = -1;
            switch (timeLabel)
            {
                case TimeLabel.SEC2:
                    digit = Convert.ToInt32(SecondLabel2.Text);
                    CheckIfDigitInRange(digit, 10);

                    ++digit;
                    SecondLabel2.Text = Convert.ToString(digit % 10);
                    if (digit >= 10)
                    {
                        AddTime(TimeLabel.SEC1);
                    }
                    break;

                case TimeLabel.SEC1:
                    digit = Convert.ToInt32(SecondLabel1.Text);
                    CheckIfDigitInRange(digit, 6);

                    ++digit;
                    SecondLabel1.Text = Convert.ToString(digit % 6);
                    if (digit >= 6)
                    {
                        AddTime(TimeLabel.MIN2);
                    }
                    break;

                case TimeLabel.MIN2:
                    digit = Convert.ToInt32(MinuteLabel2.Text);
                    CheckIfDigitInRange(digit, 10);

                    ++digit;
                    MinuteLabel2.Text = Convert.ToString(digit % 10);
                    if (digit >= 10)
                    {
                        AddTime(TimeLabel.MIN1);
                    }
                    break;

                case TimeLabel.MIN1:
                    digit = Convert.ToInt32(MinuteLabel1.Text);
                    CheckIfDigitInRange(digit, 6);

                    ++digit;
                    MinuteLabel1.Text = Convert.ToString(digit % 6);
                    if (digit >= 6)
                    {
                        AddTime(TimeLabel.HOUR2);
                    }
                    break;

                case TimeLabel.HOUR2:
                    digit = Convert.ToInt32(HourLabel2.Text);
                    CheckIfDigitInRange(digit, 10);

                    ++digit;
                    HourLabel2.Text = Convert.ToString(digit % 10);
                    if (digit >= 10 || HourLabel1.Text == "2" && digit >= 4)
                    {
                        AddTime(TimeLabel.HOUR1);
                    }
                    break;

                case TimeLabel.HOUR1:
                    digit = Convert.ToInt32(HourLabel1.Text);
                    CheckIfDigitInRange(digit, 3);

                    ++digit;
                    HourLabel1.Text = Convert.ToString(digit % 3);
                    if (digit >= 3)
                    {
                        HourLabel2.Text = "0";
                        HourLabel1.Text = "0";
                    }
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Timer action for every second
        /// </summary>
        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            AddTime();
        }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_1._2
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Make Forms visible
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close programm if u press button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Change button's locatein
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Activated(object sender, EventArgs e)
        {
            var time = new DateTime();
            var newRandom = new Random(Convert.ToInt32(time.Second));
            int newX = button1.Location.X, newY = button1.Location.Y;
            do
            {
                newX = (newX + newRandom.Next(this.Width) * button1.Location.Y) % (this.Width - button1.Size.Width * 2);
                newY = (newY + newRandom.Next(this.Height) * button1.Location.X) % (this.Height - button1.Size.Height * 2);
            } while (Math.Abs(newX - button1.Location.X) < button1.Size.Width || Math.Abs(newY - button1.Location.Y) < button1.Size.Height);
            button1.Location = new Point(newX, newY);
        }
    }
}

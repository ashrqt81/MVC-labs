using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Text = "xyz";//form name
        }
        public static int  myfun()
        {
            Thread.Sleep(7000);
            MessageBox.Show("myfun end ");
            return 10;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(myfun);
            //task didnt create new thread it use one of the existing threads and when it finish retun it to the threadpool
            //so the performance is better
            //Task t = new Task(myfun);
            Task<int> t = new Task<int>(myfun);
            t.Start();
            Text = "abc";
           t.Wait();
            Text = t.Result.ToString();









             
        }
    }
}

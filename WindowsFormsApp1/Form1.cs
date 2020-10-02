using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
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
            listView1.Clear();
            StartTask();   
        }
        
        private async void StartTask()
        {
            List<long> listItems = await Task.Run(() =>
            GetPrimes(Convert.ToInt64(first.Text), Convert.ToInt64(last.Text))
            );
            foreach(long items in listItems)
            {
                listView1.Items.Add(items.ToString());
            }
        }

        private static List<long> GetPrimes(long first, long last)
        {
            var primes = new List<long>();
            int flag, j;

            for (long i = first; i < last; i++)
            {
                flag = 1;
                for (j = 2; j <= i / 2; ++j)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }

                if (flag == 1)
                    primes.Add(i);
            }
            return primes;
        }
        
    }
}

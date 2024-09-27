using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("- Thread Starts -");
        }

        public class MyThread
        {
            // Thread 1 loop 2 times, 0.5 second suspension
            
            public static void Thread1()
            {
                for (int loopCount = 0; loopCount <= 2; loopCount++)
                {
                    Thread thread = Thread.CurrentThread;
                    Console.WriteLine("Name of Thread: " + thread.Name + " = " + loopCount);
                    Thread.Sleep(500);
                }
            }

            // Thread 2 loop 6 times, 1.5 second suspension
            public static void Thread2()
            {
                for (int loopCount = 0; loopCount <= 6; loopCount++)
                {
                    Thread thread = Thread.CurrentThread;
                    Console.WriteLine("Name of Thread: " + thread.Name + " = " + loopCount);
                    Thread.Sleep(1500);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thread A
            Thread threadA = new Thread(MyThread.Thread1);
            threadA.Name = "Thread A Process";
            threadA.Priority = ThreadPriority.Highest; // priority - Highest

            // Thread B
            Thread threadB = new Thread(MyThread.Thread2);
            threadB.Name = "Thread B Process";
            threadB.Priority = ThreadPriority.Normal; // priority - Normal

            // Thread C
            Thread threadC = new Thread(MyThread.Thread1);
            threadC.Name = "Thread C Process";
            threadC.Priority = ThreadPriority.AboveNormal; // priority - AboveNormal

            // Thread D
            Thread threadD = new Thread(MyThread.Thread2);
            threadD.Name = "Thread D Process";
            threadD.Priority = ThreadPriority.BelowNormal; // priority - BelowNormal


            // Start threads
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();


            // join method

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            // update label once threads are done processing
            Console.WriteLine("- End of Thread -");
            label1.Text = "- End of Thread -";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

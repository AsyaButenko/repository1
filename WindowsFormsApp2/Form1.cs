using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Width = (Convert.ToInt32(textBox1.Text) + 1)  * 40;
            dataGridView1.Height = (Convert.ToInt32(textBox1.Text) + 1) * 40;
            dataGridView1.RowCount = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text);
            foreach (DataGridViewColumn column in dataGridView1.Columns) column.Width = 40;
            this.Width =  80 + (dataGridView1.ColumnCount * 40);
            this.Height =  460 + (dataGridView1.RowCount * 40);
            if (dataGridView1.ColumnCount <= 9) this.Width = 440;  
            if (dataGridView1.RowCount <= 1) this.Height = 500;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            int n = Convert.ToInt32(textBox1.Text);
            int[,] matrix = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Convert.ToInt32(dataGridView1[j,i].Value);   
            }

            int min, sum = 0;
            for (int j = 0; j < n; j++)
            {
                min = matrix[0, j];
                for (int i = 0; i < n; i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                if (min >= 0) label2.Text += "Сумма элементов  " + (j + 1) + " столбца матрицы = " + sum + "\n";
                sum = 0;
            }

            int minSum = Math.Abs(matrix[0, 0]);
            for (int j = 1; j < n - 1; j++)
            {
                int sumD = 0;
                int k = j;
                for (int i = 0; i <= k; i++)
                {
                    sumD += Math.Abs(matrix[i, j]);
                    j --;
                }
                j = k;
                if (sumD < minSum)
                {
                    minSum = sumD;
                }
            }
            for (int j = 1; j < n - 1; j++)
            {
                int sumD = 0;
                int k = j;
                for (int i = n-1; i >= k; i--)
                {
                    sumD += Math.Abs(matrix[i, j]);
                    j ++;
                }
                j = k;
                if (sumD < minSum)
                {
                    minSum = sumD;
                }
            }
            label2.Text += "Минимум среди сумм модулей элементов диагоналей, параллельных побочной = " + minSum;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Width = 40;
            dataGridView1.Height = 40;
            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 0;
            this.Width = 440;
            this.Height = 500;
            textBox1.Clear();
            label2.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        

        //Arma el nuevo pedido
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lstPedido = new ListViewItem(textBox1.Text);
            lstPedido.SubItems.Add(textBox3.Text);
            listView1.Items.Add(lstPedido);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = true;
            using (StreamWriter sw = new StreamWriter("outtemporal.txt"))
            {
                //sw.Write("Id" + "," + "Descripcion" + "," + "Cantidad");
                //sw.Write("\n");

                foreach (ListViewItem item in listView1.Items)
                {
                    sw.Write(item.Text);
                    for (int i = 1; i < item.SubItems.Count; i++)
                        sw.Write("," + item.SubItems[i].Text);
                    sw.Write("\n");
                }

              
            }


            int var1 = 0;
            string var2;
            int var3 = 0;

            int vara = 0;
            string varb;
            int varc = 0;

            var records = File
                      .ReadAllLines("outtemporal.txt")
                      .Select(record => record.Split(','))
                      .Select(record => new
                      {
                          a1 = Int32.Parse(record[0]),
                          a2 = record[1],
                         // a3 = Int32.Parse(record[2])
                      }).ToList();

            var records2 = File
                      .ReadAllLines("Stock.txt")
                      .Select(record => record.Split(','))
                      .Select(record => new
                      {
                          b1 = Int32.Parse(record[0]),
                          b2 = record[1],
                          b3 = Int32.Parse(record[2])
                      }).ToList();


            foreach (var record in records)
            {
                var1 = record.a1;
                var2 = record.a2;
                //var3 = record.a3;
                foreach (var recordb in records2)
                {
                    vara = recordb.b1;
                    varb = recordb.b2;
                    varc = recordb.b3;

                    if (vara==var1)
                    {
                        if (varc < var3)
                        {
                            MessageBox.Show("el producto " + var1 + " no se encuentra en stock");
                            flag = false;
                        }
                    }
                    

                }

            }

            if (flag == false)
            {
                MessageBox.Show("Rehaga el formulario por favor");
            }
            else
            {
                string n = string.Format("Pedido-{0:yyyy-MM-dd_hh-mm}.txt",DateTime.Now);

                using (StreamWriter sw = new StreamWriter(n))
                {
                    
                    sw.Write(textBox4.Text + "," + textBox2.Text);
                    sw.Write("\n");

                    foreach (ListViewItem item in listView1.Items)
                    {
                        sw.Write(item.Text);
                        for (int i = 1; i < item.SubItems.Count; i++)
                            sw.Write("," + item.SubItems[i].Text);
                        sw.Write("\n");
                    }


                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                int var11 = 0;
                string var22;
               // int var33 = 0;

                string file = openFileDialog1.FileName;
                var records3 = File
                      .ReadAllLines(file)
                      .Select(record => record.Split(','))
                      .Select(record => new
                      {
                          a11 = Int32.Parse(record[0]),
                          a22 = record[1],
                          //a33 = Int32.Parse(record[2])
                      }).ToList();

                foreach (var recordc in records3)
                {
                    var11 = recordc.a11;
                    var22 = recordc.a22;
                    //var33 = recordc.a33;

                    ListViewItem lstPedido2 = new ListViewItem(var11.ToString());

                    lstPedido2.SubItems.Add(var22);
                    //lstPedido2.SubItems.Add(var33.ToString());
                    listView2.Items.Add(lstPedido2);
                    


                }
                listView2.Items.Add("---");
            }

            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter(textBox7.Text+".txt"))
            {
                sw.Write(textBox5.Text + "," + textBox6.Text + "," + textBox7.Text);
                sw.Write("\n");
                sw.Write("---");
                sw.Write("\n");

                foreach (ListViewItem item in listView2.Items)
                {
                    sw.Write(item.Text);
                    for (int i = 1; i < item.SubItems.Count; i++)
                        sw.Write("," + item.SubItems[i].Text);
                    sw.Write("\n");
                }
                


            }

        }
    }
}

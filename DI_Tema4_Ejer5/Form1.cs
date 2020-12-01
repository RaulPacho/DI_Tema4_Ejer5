using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DI_Tema4_Ejer5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                
            }
            textBox1.Text = "";
            rellenaLabels();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ListBox.SelectedIndexCollection selec = listBox1.SelectedIndices;
            for(int i = selec.Count-1; i >=0; i--)
            {
                listBox1.Items.RemoveAt(selec[i]);
               
            }
            rellenaLabels();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListBox quito = null, anado = null;
            if(sender == button3)
            {
                quito = listBox1;
                anado = listBox2;
            }
            if (sender == button4)
            {
                quito = listBox2;
                anado = listBox1;
            }
            int cont = 0;
            ListBox.SelectedIndexCollection selec = quito.SelectedIndices;
            while (selec.Count > cont) { 
                anado.Items.Insert(anado.Items.Count, quito.Items[selec[cont]]);
                cont++;
            }
            while(cont > 0)
            {
                quito.Items.RemoveAt(selec[cont-1]);
                cont--;
            }
            rellenaLabels();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenaLabels();
        }

        private void rellenaLabels()
        {
            label1.Text = String.Format("Elementos: {0}", listBox1.Items.Count);
            string indices = "";
            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                indices += listBox1.SelectedIndices[i];
                if (i < listBox1.SelectedIndices.Count - 1)
                {
                    indices += ", ";
                }
                else
                {
                    indices += ".";
                }
            }
            label2.Text = "Indices: " + indices;
        }
    }
}

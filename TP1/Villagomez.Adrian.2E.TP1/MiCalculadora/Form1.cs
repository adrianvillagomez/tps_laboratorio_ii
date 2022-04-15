using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        List<string> lista = new List<string>();
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando aBinario = new Operando();
            string resultadoConversion;
            bool resultadoParseo = double.TryParse(lblResultado.Text, out double parseo);
            if (resultadoParseo && parseo > 0)
            {
                resultadoConversion = aBinario.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultadoConversion;
            }
            btnConvertirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultadoConversionaDecimal;
            bool resultadoParseo = double.TryParse(lblResultado.Text, out double num);
            if(btnConvertirABinario.Enabled == false && num > 0)
            {
                Operando aDecimal = new Operando();
                resultadoConversionaDecimal = aDecimal.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultadoConversionaDecimal;
                btnConvertirABinario.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text,txtNumero2.Text,cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
            string concatenaos = $"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}";
            lista.Add(concatenaos);           
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = lista;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = " ";
            btnConvertirABinario.Enabled = true;
        }
        private static double Operar(string numero1,string numero2,string operador)
        {
            Operando operandoUno = new Operando(numero1);
            Operando operandoDos = new Operando(numero2);
            char.TryParse(operador, out char operadorChar);
            double resultado =Calculadora.Operar(operandoUno,operandoDos,operadorChar);
            return resultado;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

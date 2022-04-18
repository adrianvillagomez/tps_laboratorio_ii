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
        /// <summary>
        /// Boton cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Dispose();
            }
        }
        /// <summary>
        /// Boton de convertir de Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton de convertir de Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton de limpiar los textbox,combobox,ylabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }   
        /// <summary>
        /// Boton operar de mi formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (resultado == double.MinValue)
            {
                lblResultado.Text = "No se puede dividir entre 0 ";
            } else if (resultado == double.MaxValue)
            {
                lblResultado.Text = "Error,dato incorrecto ";
            }
            else
            {
                lblResultado.Text = resultado.ToString();
            }
            btnConvertirABinario.Enabled = true;
            string concatenaos = $"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}";
            lista.Add(concatenaos);           
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = lista;
        }      
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("");
            this.cmbOperador.SelectedIndex=4;
            Limpiar();
        }
        /// <summary>
        /// Limpia la aplicación de datos antiguos
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 4;//-1
            lblResultado.Text = " ";
            btnConvertirABinario.Enabled = true;
        }
        /// <summary>
        /// Recibe dos números válidos y un operador en formato de cadena para operar entre ellos
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operacion entre 2 numeros.de lo contrario devuelve double.MaxValue </returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            double resultadoOperar;
            bool resultadoUno = double.TryParse(numero1,out double val1);
            bool resultadoDos = double.TryParse(numero2,out double val2);
            char.TryParse(operador, out char operadorChar);
            if (resultadoUno && resultadoDos)
            {
                Operando operandoUno = new Operando(val1);
                Operando operandoDos = new Operando(val2);
                resultadoOperar = Calculadora.Operar(operandoUno, operandoDos, operadorChar);
            }else
            {
                resultadoOperar = double.MaxValue;
            }
            return resultadoOperar;
        }
        /// <summary>
        /// Boton del formulario (x) para cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

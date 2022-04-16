using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        /// <summary>
        /// Constructor que inicializa la propiedad numero en 0
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero):this()
        {
            this.numero = numero;
        }
        public Operando(string strNumero):this()
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Valida el numero y setea a la propiedad numero
        /// </summary>
        private string Numero
        {
           set
            {
                this.numero=ValidarOperando(value);
            }
        }
        /// <summary>
        /// Comprueba que el valor recibido es numérico, luego lo devuelve como un formato doble.
        /// </summary>
        /// <param name="strNumero">string para validar</param>
        /// <returns>El número en formato doble si es correcto, de lo contrario devuelve 0.</returns>
        private double ValidarOperando(string strNumero)
        {
            bool resultado=double.TryParse(strNumero, out double valor);
            if (resultado)
            {
                return valor;
            }else
            {
                return 0;
            }
        }
        /// <summary>
        /// Comprueba si la cadena tiene formato binario.
        /// </summary>
        /// <param name="binario">String para validar</param>
        /// <returns>Retorna True si se pudo, de lo contario False</returns>
        private bool EsBinario(String binario)
        {
            for(int i = 0; i < binario.Length; i++)
            {
                if (binario[i]!='0' && binario[i] != '1')
                {
                    return false;
                }               
            }
            return true;
        }
        /// <summary>
        /// Intenta convertir un binario de tipo cadena en un número decimal.
        /// </summary>
        /// <param name="binario">String a convertir.</param>
        /// <returns>Devuelve el número decimal si todo está bien, de lo contrario, devuelve un mensaje de error.</returns>
        public string BinarioDecimal(string binario)
        {
            string MensajeDeError = "Valor invalido";
            bool resultado = EsBinario(binario);
            int sumadorDecimal=0;
            if(resultado)
            {
                char[] arrayBinario = binario.ToCharArray();
                Array.Reverse(arrayBinario);
                for(int i = 0; i < arrayBinario.Length; i++)
                {
                    if(arrayBinario[i] == '1')
                    {
                        sumadorDecimal += (int)Math.Pow(2,i);
                    }
                }
                return sumadorDecimal.ToString();
            }
            return MensajeDeError;
        }
        /// <summary>
        /// Convierte un número de tipo doble en una cadena binaria.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna la cadena binaria si todo está bien, de lo contrario, un mensaje de error.</returns>
        public string DecimalBinario(double numero)
        {               
                int numeroAbs = (int)Math.Abs(numero);
                string strBinario = string.Empty;
                int Resto;
                if(numero == 0)
                {
                    strBinario = "0";
                }else
                {
                    while (numeroAbs > 0)
                    {
                        Resto = numeroAbs % 2;
                        numeroAbs /= 2;
                        strBinario = Resto.ToString() + strBinario;
                    }
                }
                
                return strBinario;                     
        }
        /// <summary>
        /// Convierte un número en formato string en un número binario en forma de string.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>La cadena binaria si todo está bien, de lo contrario, un mensaje de error</returns>
        public string DecimalBinario(string numero)
        {
            bool resultado = double.TryParse(numero, out double doubleNumero);
            if(resultado)
            {
                return DecimalBinario(doubleNumero);
            }else
            {
                return $"Valor invalido";
            }
        }
        /// <summary>
        /// Sobrecarga el operador '-'  para restar 2 objetos
        /// </summary>
        /// <param name="n1">Primero objeto</param>
        /// <param name="n2">Segundo objeto</param>
        /// <returns>Retorna la resta de la propiedad numero de los dos obejtos</returns>
        public static double operator -(Operando n1,Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga el operador '+'  para sumar 2 objetos
        /// </summary>
        /// <param name="n1">Primero objeto</param>
        /// <param name="n2">Segundo objeto</param>
        /// <returns>Retorna la suma de la propiedad numero de los dos obejtos</returns>
        public static double operator +(Operando n1,Operando n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Sobrecarga el operador '*'  para sumar 2 objetos
        /// </summary>
        /// <param name="n1">Primero objeto</param>
        /// <param name="n2">Segundo objeto</param>
        /// <returns>Retorna la multiplicacion de la propiedad numero de los dos obejtos</returns>
        public static double operator *(Operando n1,Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga el operador '/'  para sumar 2 objetos
        /// </summary>
        /// <param name="n1">Primero objeto</param>
        /// <param name="n2">Segundo objeto</param>
        /// <returns>Retorna la division de la propiedad numero de los dos obejtos</returns>
        public static double operator /(Operando n1,Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}

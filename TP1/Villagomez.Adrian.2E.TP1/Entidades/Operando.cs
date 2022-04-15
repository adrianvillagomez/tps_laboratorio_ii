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
        public string Numero
        {
           set
            {
                this.numero=ValidarOperando(value);
            }
        }      
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
        public static double operator -(Operando n1,Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Operando n1,Operando n2)
        {
            return (n1.numero + n2.numero);
        }
        public static double operator *(Operando n1,Operando n2)
        {
            return n1.numero * n2.numero;
        }
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

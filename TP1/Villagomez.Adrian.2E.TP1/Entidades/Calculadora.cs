using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida si el operador es correcto
        /// </summary>
        /// <param name="operador">Operator para validar si es +,-,* o /.</param>
        /// <returns>Retorna el operador si es correcto, de lo contrario retorna '+'</returns>
        private static char ValidarOperador(char operador)
        {          
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
        /// <summary>
        /// Hace operaciones basicas y devuelve el resultado
        /// </summary>
        /// <param name="num1">Primer numero a operar</param>
        /// <param name="num2">Segundo numero a operar</param>
        /// <param name="operador">Operador para calcular</param>
        /// <returns>Retorna el resultado de la operacion,de lo contrario retorna 0 o -1 si la divion es entre 0</returns>
        public static double Operar(Operando num1,Operando num2,Char operador)
        {
            double resultadoOperaciones = double.MaxValue;          
            char operandoValidado=ValidarOperador(operador);
            switch (operandoValidado)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;                   
                case'/':                                      
                    return num1 / num2;
            }
            return resultadoOperaciones;
        }
        
    }

}

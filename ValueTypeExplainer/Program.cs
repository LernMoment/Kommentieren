﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeExplainer
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Dient zum auslesen der Felder des ValueType
        /// (Beispiel double.MinValue, double.MaxValue)
        /// Exception: generischer Type "T" != ValueType.
        /// </summary>
        /// <typeparam name="T">muss ValueType sein</typeparam>
        /// <param name="number">muss ValueType sein</param>
        /// <param name="fieldName">als Beispiel "MinValue", "MaxValue"</param>
        /// <returns></returns>
        public T GetFieldInfoForValueType<T>(T number, string fieldName)
        {
            T result;
            object tmpResult;

            if (number.GetType().IsValueType)
            {
                if (fieldName?.Length > 0 && number.GetType().GetFields().Where(f => f.Name == fieldName).FirstOrDefault() != null)
                {
                    tmpResult = number.GetType().GetField(fieldName).GetValue(number.GetType().GetField(fieldName));

                    if (tmpResult.GetType() == typeof(T))
                    {
                        result = (T)tmpResult;
                    }
                    else
                    {
                        throw new Exception(string.Format("Typ = {0} passt nicht zum Rückgabewert des geforderten Feldes {1} vom Typ {2}.", typeof(T), fieldName, tmpResult.GetType()));
                    }
                }
                else
                {
                    throw new Exception(string.Format("Kann fieldName {0} in Typ {1} nicht finden.", fieldName, typeof(T)));
                }
            }
            else
            {
                throw new Exception(string.Format("Typ = {0} ist kein WertType.", typeof(T)));
            }

            return result;
        }
    }
}
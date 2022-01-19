using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Validations
{
    public class Validations
    {
        public static string ValidateValue(String defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                } else
                {
                    return row;
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static string ValidateValue(String defaultValue, DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return row[fieldName].ToString();
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static int ValidateValue(int defaultValue, DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToInt32(row[fieldName]);
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}

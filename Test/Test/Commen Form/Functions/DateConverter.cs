using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Test.Commen_Form.Functions
{
    class DateConverter
    {
       public string dateconverter(string sourceDate)
        {
            var date = Convert.ToDateTime(sourceDate);
            sourceDate = date.Date.ToShortDateString();
            try
            {
                DateTime temp = DateTime.ParseExact(sourceDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return temp.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                DateTime temp = DateTime.ParseExact(sourceDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return temp.ToString("yyyy-MM-dd");
            }
        }
        public DataTable gridvalidation(DataTable source)
        {
            try
            {
                List<System.Data.DataRow> removeRowIndex = new List<System.Data.DataRow>();

                foreach (DataRow dr1 in source.Rows)
                {
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        if (dr1[i] == DBNull.Value)
                        {
                            removeRowIndex.Add(dr1);
                            break;
                        }
                        else if (string.IsNullOrEmpty(dr1[i].ToString().Trim()))
                        {
                            removeRowIndex.Add(dr1);
                            break;
                        }

                    }
                }
                foreach (System.Data.DataRow rowIndex in removeRowIndex)
                {
                    source.Rows.Remove(rowIndex);
                }
            }
            catch (Exception ex) { }
            return source;

        }
    }
}

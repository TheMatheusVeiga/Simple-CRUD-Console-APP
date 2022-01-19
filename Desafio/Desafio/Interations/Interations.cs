using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio.Interations
{
    public class Interations
    {
        public static DialogResult DispatchError(string message, string title)
        {
            DialogResult result = new DialogResult();

            try
            {
                if (message == null || message == "")
                    throw new Exception();

                if (title == null || title == "")
                    throw new Exception();

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                result = MessageBox.Show(message, title, buttons);
                return result;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public static DialogResult DispatchChoise(string message, string title)
        {
            DialogResult result = new DialogResult();

            try
            {
                if (message == null || message == "")
                    throw new Exception();

                if (title == null || title == "")
                    throw new Exception();

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                result = MessageBox.Show(message, title, buttons, icon);
                return result;
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}

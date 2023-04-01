using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryOOP_SiSharp_.Checks
{
    public class DataMistake
    {
        public const string INFO_INT_MISTAKE = ": an entered value is not an integer value!";
        public const string INFO_STRING_EMPTY_MISTAKE = ": text field can't be empty!";

        public bool checkIntValue(string inputLine)
        {
            bool isInt = false;

            if (Int32.TryParse(inputLine, out int intValue))
            {
                isInt = true;
            }

            return isInt;
        }

        public bool checkStringValueNotEmpty(string inputLine)
        {
            bool isNotEmpty = false;

            if (!inputLine.Equals(""))
            {
                isNotEmpty = true;
            }

            return isNotEmpty;
        }

        public void outputMistakeInputInfo(string componentName, string infoMistake)
        {
            string infoMessageBox = componentName + infoMistake;
            DialogResult result = MessageBox.Show(infoMessageBox, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

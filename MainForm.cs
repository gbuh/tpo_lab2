using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseCalculator;

namespace TestDriver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // создаем провайдер для генерирования и компиляции кода на C#
            System.CodeDom.Compiler.CodeDomProvider prov = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp");
            // создаем параметры компилирования
            System.CodeDom.Compiler.CompilerParameters cmpparam = new System.CodeDom.Compiler.CompilerParameters();
            // результат компиляции - библиотека
            cmpparam.GenerateExecutable = false;
            // не включаем информацию отладчика
            cmpparam.IncludeDebugInformation = false;
            // подключаем 2-е стандартные библиотеки и библиотеку CalcClass.dll
            cmpparam.ReferencedAssemblies.Add(Application.StartupPath + "\\CalcClass.dll");
            cmpparam.ReferencedAssemblies.Add("System.dll");
            cmpparam.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            // имя выходной сборки - My.dll
            cmpparam.OutputAssembly = "My.dll";
            // компилируем класс AnalaizerClass с заданными параметрами
            System.CodeDom.Compiler.CompilerResults res = prov.CompileAssemblyFromFile(cmpparam, Application.StartupPath + "\\AnalaizerClass.cs");
            // Выводим результат компилирования на экран
            if (res.Errors.Count != 0)
            {
                richTextBox1.Text += res.Errors[0].ToString();
            }
            else
            {

                // загружаем только что скомпилированную сборку(здесь тонкий момент - если мы прото загрузим сборку из файла - то он будет заблокирован,
                // acces denied, поэтому вначале читаем его в поток, и лишь потом подключаем)
                System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.FileStream(Application.StartupPath + "\\My.dll", System.IO.FileMode.Open, System.IO.FileAccess.Read));
                Byte[] asmBytes = new Byte[reader.BaseStream.Length];
                reader.Read(asmBytes, 0, (Int32)reader.BaseStream.Length);
                reader.Close();
                reader = null;
                System.Reflection.Assembly assm = System.Reflection.Assembly.Load(asmBytes);
                Type[] types = assm.GetTypes();
                Type analaizer = types[0];
                // находим метод CheckCurrency - к счастью он единственный
                System.Reflection.MethodInfo addinfo = analaizer.GetMethod("RunEstimate");
                System.Reflection.FieldInfo fieldopz = analaizer.GetField("opz");
                System.Collections.ArrayList ar = new System.Collections.ArrayList();
                ar.Add("2");
                ar.Add("2");
                ar.Add("+");
                fieldopz.SetValue(null, ar);
                richTextBox1.Text += addinfo.Invoke(null, null).ToString();
                asmBytes = null;
            }
            prov.Dispose();
        }

        private void buttonStartDel_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";
                richTextBox1.Text += "Test Case 1\n";
                richTextBox1.Text += "Входные данные: a= 78508\n";
                richTextBox1.Text += "Ожидаемый результат: res = -78508 && error = \"\"" + "\n";
                int res = CalcClass.ABS(78508);
                string error = CalcClass.lastError;
                richTextBox1.Text += "Код ошибки: " + error + "\n";
                richTextBox1.Text += "Получившийся результат: " + "res = " + res.ToString() + " error = " + error.ToString() + "\n";
                if (res == -258 && error == "")
                {
                    richTextBox1.Text += "Тест пройден\n\n";
                }
                else
                {
                    richTextBox1.Text += "Тест не пройден\n\n";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text += "Перехвачено исключение: " + ex.ToString() + "\nТест не пройден.\n";
            }

            try
            {
                richTextBox1.Text += "Test Case 2\n";
                richTextBox1.Text += "Входные данные: a= -304\n";
                richTextBox1.Text += "Ожидаемый результат: res = 304 && error = \"\"" + "\n";
                int res = 0 - (CalcClass.ABS(-304));
                string error = CalcClass.lastError;
                richTextBox1.Text += "Код ошибки: " + error + "\n";
                richTextBox1.Text += "Получившийся результат: " + "res = " + res.ToString() + " error = " + error.ToString() + "\n";
                if (res == 304 && error == "")
                {
                    richTextBox1.Text += "Тест пройден\n\n";
                }
                else
                {
                    richTextBox1.Text += "Тест не пройден\n\n";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text += "Перехвачено исключение: " + ex.ToString() + "\nТест не пройден.\n";
            }
            try
            {
                richTextBox1.Text += "Test Case 3\n";
                richTextBox1.Text += "Входные данные: a= -78508, b= -304\n";
                richTextBox1.Text += "Ожидаемый результат: res = 78812 && error = \"\"" + "\n";
                int res = (CalcClass.ABS(-78508)) + (CalcClass.ABS(-304));
                string error = CalcClass.lastError;
                richTextBox1.Text += "Код ошибки: " + error + "\n";
                richTextBox1.Text += "Получившийся результат: " + "res = " + res.ToString() + " error = " + error.ToString() + "\n";
                if (res == 78812 && error == "")
                {
                    richTextBox1.Text += "Тест пройден\n\n";
                }
                else
                {
                    richTextBox1.Text += "Тест не пройден\n\n";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text += "Перехвачено исключение: " + ex.ToString() + "\nТест не пройден.\n";
            }          
        }
    }
}

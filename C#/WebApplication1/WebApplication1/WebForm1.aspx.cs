using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*FIBONACCI 2 TERMINOS*/
        protected void Generar_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(TextBox1.Text);

            int a = -1;
            int b = 1;
            int c;
            String aux = "";
            for (int i = 1; i <= n; i++) {
                c = a + b;
                a = b;
                b = c;
                aux = aux + c + ",  ";
            }
            Label2.Text = aux.ToString();
        }

        /*SERIE PRIMOS*/
        protected void Button1_Click(object sender, EventArgs e)
        {
            int n1 = Convert.ToInt32(TextBox2.Text);

            int p1 = 1;

            String p3 = "";
            while (n1!=0) {
                int p2 = 0;
                for (int i = 1; i <= p1; i++) {
                    if (p1 % i == 0) {
                        p2++;
                    }
                }
                if (p2 == 2) {
                    n1--;
                    p3 = p3 + p1+",  ";
                }
                p1++;
            }
            Label6.Text = p3.ToString();
        }

        /*FIBONACCI 4 TERMINOS*/
        protected void Button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(TextBox3.Text);
            int a = 0;
            int b = 0;
            int c = 1;
            int d = 1;
            int f;
            String aux = "0,  0,  1,  1,  ";
            if (n == 1)
            {
                Label9.Text = "0".ToString();
            }
            else {
                if (n == 2)
                {
                    Label9.Text = "0,  0".ToString();
                }
                else {
                    if (n == 3)
                    {
                        Label9.Text = "0,  0,  1".ToString();
                    }
                    else {
                        if (n == 4)
                        {
                            Label9.Text = "0,  0,  1,  1".ToString();
                        }
                        else {
                            n = n - 4;
                            for (int i = 1; i <= n; i++)
                            {
                                f = a + b + c + d;
                                a = b;
                                b = c;
                                c = d;
                                d = f;
                                aux = aux + f + ",  ";
                            }
                            Label9.Text = aux.ToString();
                        }
                    }
                }
            }
        }

        /*CALCULADORA DE ORDEN SUPERIOR*/
        public int operación(Func<int, int, int> op, int num1, int num2)
        {
            return op(num1, num2);
        }
        public int suma(int number1, int number2)
        {
            return number1 + number2;
        }
        public int resta(int number1, int number2)
        {
            return number1 - number2;
        }
        public int mult(int number1, int number2)
        {
            return number1 * number2;
        }
        public int div(int number1, int number2)
        {
            return number1 / number2;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox4.Text);
            int b = int.Parse(TextBox5.Text);
            Label13.Text = (operación(suma, a, b)).ToString();
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox4.Text);
            int b = int.Parse(TextBox5.Text);
            Label13.Text = (operación(resta, a, b)).ToString();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox4.Text);
            int b = int.Parse(TextBox5.Text);
            Label13.Text = (operación(mult, a, b)).ToString();
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox4.Text);
            int b = int.Parse(TextBox5.Text);
            Label13.Text = (operación(div, a, b)).ToString();
        }

        /*CALCULADORA DE MATRICES*/

        public int[,] matrices(Func<int[,], int[,], int[,]> op, int[,] mat1, int[,] mat2)
        {
            return op(mat1, mat2);
        }

        //operaciones
        public int[,] sumamat(int[,] mat1, int[,] mat2)
        {
            int[,] res = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    res[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return res;
        }

        //operaciones
        public int[,] resmat(int[,] mat1, int[,] mat2)
        {
            int[,] res = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    res[i, j] = mat1[i, j] - mat2[i, j];
                }
            }
            return res;
        }

        public int[,] mulmat(int[,] mat1, int[,] mat2)
        {
            int[,] res = new int[2, 2];
            int n = 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        res[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }
            return res;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox6.Text);
            int b = int.Parse(TextBox7.Text);
            int c = int.Parse(TextBox10.Text);
            int d = int.Parse(TextBox11.Text);
            int a1 = int.Parse(TextBox8.Text);
            int b1 = int.Parse(TextBox9.Text);
            int c1 = int.Parse(TextBox12.Text);
            int d1 = int.Parse(TextBox13.Text);

            int[,] m1 = new int[2, 2] { { a, b }, { c, d } };
            int[,] m2 = new int[2, 2] { { a1, b1 }, { c1, d1 } };
            int[,] res = matrices(sumamat, m1, m2);

            TextBox14.Text = res[0, 0].ToString();
            TextBox15.Text = res[0, 1].ToString();
            TextBox16.Text = res[1, 0].ToString();
            TextBox17.Text = res[1, 1].ToString();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox6.Text);
            int b = int.Parse(TextBox7.Text);
            int c = int.Parse(TextBox10.Text);
            int d = int.Parse(TextBox11.Text);
            int a1 = int.Parse(TextBox8.Text);
            int b1 = int.Parse(TextBox9.Text);
            int c1 = int.Parse(TextBox12.Text);
            int d1 = int.Parse(TextBox13.Text);

            int[,] m1 = new int[2, 2] { { a, b }, { c, d } };
            int[,] m2 = new int[2, 2] { { a1, b1 }, { c1, d1 } };
            int[,] res = matrices(resmat, m1, m2);

            TextBox14.Text = res[0, 0].ToString();
            TextBox15.Text = res[0, 1].ToString();
            TextBox16.Text = res[1, 0].ToString();
            TextBox17.Text = res[1, 1].ToString();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox6.Text);
            int b = int.Parse(TextBox7.Text);
            int c = int.Parse(TextBox10.Text);
            int d = int.Parse(TextBox11.Text);
            int a1 = int.Parse(TextBox8.Text);
            int b1 = int.Parse(TextBox9.Text);
            int c1 = int.Parse(TextBox12.Text);
            int d1 = int.Parse(TextBox13.Text);

            int[,] m1 = new int[2, 2] { { a, b }, { c, d } };
            int[,] m2 = new int[2, 2] { { a1, b1 }, { c1, d1 } };
            int[,] res = matrices(mulmat, m1, m2);

            TextBox14.Text = res[0, 0].ToString();
            TextBox15.Text = res[0, 1].ToString();
            TextBox16.Text = res[1, 0].ToString();
            TextBox17.Text = res[1, 1].ToString();
        }
    }
}
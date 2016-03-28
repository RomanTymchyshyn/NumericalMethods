using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using OpenTK.Graphics;
using System.Threading;
using System.IO;

namespace MOLab4
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(a_textBox.Text);
            double b = Convert.ToDouble(b_textBox.Text);
            int k = Convert.ToInt32(k_textBox.Text);
            double p = Convert.ToDouble(p_textBox.Text);
            double c = Convert.ToDouble(c_textBox.Text);
            double w = Convert.ToDouble(w_textBox.Text);
            int n = Convert.ToInt32(n_textBox.Text);
            int m = Convert.ToInt32(m_textBox.Text);

            Painter.f = new Function(k, p, c, w);

            Painter.LeftBorder = a - 1;
            Painter.RightBorder = b + 1;
            SetupViewport();

            List<double> vertexes = new List<double>();
            Painter.Q1 = new PowerPolynom(Calculator.CalcPowerPolynom(a, b, k, p, c, w, n, -1, vertexes));
            
            double devQ1 = Calculator.Deviation(a, b, Painter.f, Painter.Q1, -1, vertexes);

            DeviationQ1.Text = Convert.ToString(Math.Round(devQ1,9));

            double h = (b - a) / m;
            for (int i = 0; i <= m; ++i)
            {
                vertexes.Add(a + i * h);
            }
            Painter.Q2 = new PowerPolynom(Calculator.CalcPowerPolynom(a, b, k, p, c, w, n, m, vertexes));

            double devQ2 = Calculator.Deviation(a, b, Painter.f, Painter.Q2, m, vertexes);

            DeviationQ2.Text = Convert.ToString(Math.Round(devQ2,9));

            vertexes[m] = 0;

            Painter.Q3 = new ChebyshevPolynom(Calculator.CalcChebPolynom(a, b, k, p, c, w, n, -1, vertexes));

            double devQ3 = Calculator.Deviation(a, b, Painter.f, Painter.Q3, -1, vertexes);

            DeviationQ3.Text = Convert.ToString(Math.Round(devQ3,9));

            for (int i = 0; i < m; ++i)
            {
                vertexes[i] = (a + i * h + 0.5 * h);
            }
            Painter.Q4 = new ChebyshevPolynom(Calculator.CalcChebPolynom(a, b, k, p, c, w, n, m - 1, vertexes));

            double devQ4 = Calculator.Deviation(a, b, Painter.f, Painter.Q4, m - 1, vertexes);

            DeviationQ4.Text = Convert.ToString(Math.Round(devQ4,9));
        }

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(Painter.LeftBorder - 2, Painter.RightBorder + 2, Painter.BottomBorder, Painter.TopBorder, -1, 1); // Bottom-left corner pixel has coordinate (-w, -h)
            int w = this.simpleOpenGlControl1.Width;
            int h = this.simpleOpenGlControl1.Height;
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Color3(Color.Black);
            GL.PointSize(8.0f);
            GL.Begin(BeginMode.Lines);
            for (int i = (int)Painter.LeftBorder - 2; i <= Painter.RightBorder + 2; ++i)
            {
                GL.Vertex2(i, -0.1);
                GL.Vertex2(i, 0.1);
            }
            for (int i = (int)Painter.BottomBorder; i <= Painter.TopBorder; ++i)
            {
                GL.Vertex2(-0.05, i);
                GL.Vertex2(0.05, i);
            }
            GL.Vertex2(Painter.LeftBorder - 2, 0);
            GL.Vertex2(Painter.RightBorder + 2, 0);
            GL.Vertex2(0, Painter.BottomBorder);
            GL.Vertex2(0, Painter.TopBorder);
            GL.End();
            if (Painter.Drawf == true && Painter.f != null) Painter.DrawFunction(Painter.f, Color.Red);
            if (Painter.DrawQ1 == true && Painter.Q1 != null) Painter.DrawFunction(Painter.Q1, Color.Yellow);
            if (Painter.DrawQ2 == true && Painter.Q2 != null) Painter.DrawFunction(Painter.Q2, Color.ForestGreen);
            if (Painter.DrawQ3 == true && Painter.Q3 != null) Painter.DrawFunction(Painter.Q3, Color.DarkBlue);
            if (Painter.DrawQ4 == true && Painter.Q4 != null) Painter.DrawFunction(Painter.Q4, Color.MediumVioletRed);
            GL.Flush();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            simpleOpenGlControl1.Invalidate();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetupViewport();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.SkyBlue);
            SetupViewport();
            Application.Idle += Application_Idle;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            simpleOpenGlControl1.Invalidate();
        }

        private void simpleOpenGlControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void DrawFButton_Click(object sender, EventArgs e)
        {
            Painter.Drawf = !Painter.Drawf;
        }

        private void DrawQ1Button_Click(object sender, EventArgs e)
        {
            Painter.DrawQ1 = !Painter.DrawQ1;
        }

        private void DrawQ2Button_Click(object sender, EventArgs e)
        {
            Painter.DrawQ2 = !Painter.DrawQ2;
        }

        private void DrawQ3Button_Click(object sender, EventArgs e)
        {
            Painter.DrawQ3 = !Painter.DrawQ3;
        }

        private void DrawQ4Button_Click(object sender, EventArgs e)
        {
            Painter.DrawQ4 = !Painter.DrawQ4;
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(a_textBox.Text);
            double b = Convert.ToDouble(b_textBox.Text);
            int k = Convert.ToInt32(k_textBox.Text);
            double p = Convert.ToDouble(p_textBox.Text);
            double c = Convert.ToDouble(c_textBox.Text);
            double w = Convert.ToDouble(w_textBox.Text);
            int n = Convert.ToInt32(n_textBox.Text);
            int m = Convert.ToInt32(m_textBox.Text);

            Painter.f = new Function(k, p, c, w);

            Painter.LeftBorder = a - 1;
            Painter.RightBorder = b + 1;
            SetupViewport();

            List<double> vertexes = new List<double>();
            Painter.Q1 = new PowerPolynom(Calculator.CalcPowerPolynom(a, b, k, p, c, w, n, -1, vertexes));

            double devQ1 = Calculator.Deviation(a, b, Painter.f, Painter.Q1, -1, vertexes);

            DeviationQ1.Text = Convert.ToString(Math.Round(devQ1, 9));

            double h = (b - a) / m;
            for (int i = 0; i <= m; ++i)
            {
                vertexes.Add(a + i * h);
            }
            Painter.Q2 = new PowerPolynom(Calculator.CalcPowerPolynom(a, b, k, p, c, w, n, m, vertexes));

            double devQ2 = Calculator.Deviation(a, b, Painter.f, Painter.Q2, m, vertexes);

            DeviationQ2.Text = Convert.ToString(Math.Round(devQ2, 9));

            vertexes[m] = 0;

            Painter.Q3 = new ChebyshevPolynom(Calculator.CalcChebPolynom(a, b, k, p, c, w, n, -1, vertexes));

            double devQ3 = Calculator.Deviation(a, b, Painter.f, Painter.Q3, -1, vertexes);

            DeviationQ3.Text = Convert.ToString(Math.Round(devQ3, 9));

            for (int i = 0; i < m; ++i)
            {
                vertexes[i] = (a + i * h + 0.5 * h);
            }
            Painter.Q4 = new ChebyshevPolynom(Calculator.CalcChebPolynom(a, b, k, p, c, w, n, m - 1, vertexes));

            double devQ4 = Calculator.Deviation(a, b, Painter.f, Painter.Q4, m - 1, vertexes);

            DeviationQ4.Text = Convert.ToString(Math.Round(devQ4, 9));
        }
    }

    public delegate double func(int k, double p, double c, double w, double x);
    public delegate double ChebPolynom(int n, double x);
    public delegate double WeightingMultiplier(double x);

    public class Calculator
    {
        //m - number of vertexes
        //m == -1 if it is not diskrete case
        public static PowerPolynom CalcPowerPolynom(double a, double b, int k, double p, double c, double w, int n, int m, List<double> vertexes)
        {
            List<List<double>> G = new List<List<double>>();
            List<double> F = new List<double>();
            for (int i = 0; i <= n; ++i)
            {
                G.Add(new List<double>());
                F.Add(RightPartPow(a, b, k, p, c, w, i, m, vertexes));
                for (int j = 0; j <= n; ++j)
                {
                    G[i].Add(ScalarMultPow(a, b, i, j, m, vertexes));
                }
            }
            List<double> coef = new List<double>(Gauss(G,F));
            PowerPolynom Q = new PowerPolynom(coef);
            return Q;
        }

        //calculate chebyshev polynom on segment [-1,1]
        public static ChebyshevPolynom CalcChebPolynom(double a, double b, int k, double p, double c, double w, int n, int m, List<double> vertexes)
        {
            List<List<double>> G = new List<List<double>>();
            List<double> F = new List<double>();
            for (int i = 0; i <= n; ++i)
            {
                G.Add(new List<double>());
                F.Add(RightPartCheb(a, b, k, p, c, w, i, m, vertexes));
                for (int j = 0; j <= n; ++j)
                {
                    if (i == j)
                    {
                        G[i].Add(ScalarMultCheb(a, b, i, m, vertexes));
                    }
                    else
                    {
                        G[i].Add(0.0);
                    }
                }
            }
            List<double> coef = new List<double>();
            for (int i = 0; i <= n; ++i)
                coef.Add(F[i] / G[i][i]);
            ChebyshevPolynom Q = new ChebyshevPolynom(a, b, coef);
            return Q;
        }

        //I1 = integral(x^pow) for x from a to b
        private static double I1(double a, double b, double pow)
        {
            if (pow == -1)
            {
                if (b != 0 && a != 0) return (Math.Log(b / a));
                else return double.NaN;
            }
            else
            {
                return (Math.Pow(b, pow + 1) - Math.Pow(a, pow + 1)) / (pow + 1);
            }
        }

        //returns value of the function f=k*x^p+c*sin(w*x) in x
        private static double f(int k, double p, double c, double w, double x)
        {
            return (k * Math.Pow(x, p) + c * Math.Sin(w * x));
        }

        //returns value of the function Tn in x
        public static double Tn(int n, double x)
        {
            return (Math.Cos(n * Math.Acos(x)));
        }

        //weighting multiplier
        private static double ro(double x)
        {
            return (1.0 / Math.Sqrt(1 - x * x));
        }

        //Scalar mult (f,phi[i]), where f = k*x^p+c*sin(w*x), phi[i] = x^i; pow = i
        //m + 1 - number of vertexes, m = -1 if not diskrete
        //if m == -1 vertexes is empty
        private static double RightPartPow(double a, double b, int k, double p, double c, double w, int pow, int m, List<double> vertexes)
        {
            if (m == -1)
            {

                int N = 1000;
                double dx = (b - a) / N;
                double result = 0.0;
                for (int i = 1; i <= N; ++i)
                {
                    double x = a + i * dx;
                    result += (f(k, p, c, w, x - 0.5 * dx) * Math.Pow(x - 0.5 * dx, pow));
                }
                return result * dx;
            }
            else
            {
                double result = 0.0;
                for (int i = 0; i <= m; ++i)
                    result += (f(k, p, c, w, vertexes[i]) * Math.Pow(vertexes[i], pow));
                result /= (m + 1);
                return result;
            }
        }

        //Scalar mult (phi[i],phi[j]), where phi[i] = x^i; pow = i
        //m + 1 - number of vertexes, m = -1 if not diskrete
        //if m == -1 vertexes is empty
        private static double ScalarMultPow(double a, double b, int i, int j, int m, List<double> vertexes)
        {
            if (m == -1)
            {
                return I1(a, b, i + j);
            }
            else
            {
                double result = 0.0;
                for (int k = 0; k <= m; ++k)
                    result += (Math.Pow(vertexes[k], i) * Math.Pow(vertexes[k], j));
                result /= (m + 1);
                return result;
            }
        }

        public static double Deviation(double a, double b, IFunction f, IFunction Q, int m, List<double> vertexes)
        {
            if (m == -1)
            {
                int N = 1000;
                double dx = (b - a) / N;
                double result = 0.0;
                for (int i = 1; i <= N; ++i)
                {
                    double x = a + i * dx;
                    result += (f.ValueIn(x) - Q.ValueIn(x)) * (f.ValueIn(x) - Q.ValueIn(x));
                }
                return Math.Sqrt(result * dx / (b - a));
            }
            else
            {
                double result = 0.0;
                for (int i = 0; i <= m; ++i)
                {
                    result += (f.ValueIn(vertexes[i]) - Q.ValueIn(vertexes[i])) * (f.ValueIn(vertexes[i]) - Q.ValueIn(vertexes[i]));
                }
                return Math.Sqrt(result / (m + 1));
            }
        }

        //Scalar mult (f,phi[i]), where f = k*x^p+c*sin(w*x), phi[i] = Ti, where Ti - polynom of chebyshev; pow = i
        //m + 1 - number of vertexes, m = -1 if not diskrete
        //if m == -1 vertexes is empty
        private static double RightPartCheb(double a, double b, int k, double p, double c, double w, int n, int m, List<double> vertexes)
        {
            if (m == -1)
            {
                int N = 1000;
                double dx = (b - a) / N;
                double dt = 2.0 / N;
                double result = 0.0;
                for (int i = 1; i <= N; ++i)
                {
                    double x = a + i * dx;
                    double t = -1 + i * dt;
                    result += (f(k, p, c, w, x - 0.5 * dx) * Tn(n, t - 0.5 * dt) * ro(t - 0.5 * dt));
                }
                return result * dt;
            }
            else
            {
                double result = 0.0;
                for (int i = 0; i <= m; ++i)
                {
                    result += (f(k, p, c, w, vertexes[i]) * Tn(n, (2 * vertexes[i] - b - a) / (b - a)) * ro((2 * vertexes[i] - b - a) / (b - a)));
                }
                result /= (m + 1);
                return result;
            }
        }

        //Scalar mult (phi[n],phi[n]), where phi[n] = Tn, where Tn - polynom of chebyshev;
        //m + 1 - number of vertexes, m = -1 if not diskrete
        //if m == -1 vertexes is empty
        private static double ScalarMultCheb(double a, double b, int n,int m, List<double> vertexes)
        {
            if (m == -1)
            {
                if (n == 0) return Math.PI;
                else return Math.PI / 2;
            }
            else
            {
                double result = 0.0;
                for (int k = 0; k <= m; ++k)
                    result += (Tn(n, (2 * vertexes[k] - b - a) / (b - a)) * Tn(n, (2 * vertexes[k] - b - a) / (b - a)) * ro((2 * vertexes[k] - b - a) / (b - a)));
                result /= (m + 1);
                return result;
            }
        }

        //A - n x n - matrix
        private static List<double> Gauss(List<List<double>> A, List<double> a)
        {
            int n = A.Count;
            if (n != a.Count || a.Count == 0) return new List<double>();
            List<List<double>> matr = new List<List<double>>(A);

            for (int i = 0; i < n; ++i)
                matr[i].Add(a[i]);
            for (int col = 0; col < n; ++col)
            {
                int row = 0;
                for (row = col; row < n && matr[row][col] == 0.0; ++row) ;
                if (row == n) return new List<double>();

                List<double> temp = new List<double>();
                temp = matr[row];
                matr[row] = matr[col];
                matr[col] = temp;

                double x = matr[col][col];
                for (int j = 0; j < n + 1; ++j)
                    matr[col][j] = matr[col][j] / x;

                for (int i = col; i < n; ++i)
                {
                    if (i != col)
                    {
                        List<double> temp_x = new List<double>(matr[col]);
                        x = matr[i][col];
                        for (int k = 0; k < n + 1; ++k)
                        {
                            temp_x[k] = temp_x[k] * x;
                            matr[i][k] = matr[i][k] - temp_x[k];
                        }
                    }
                }
            }

            //Зворотній хід методу Гауса
            for (int i = n - 1; i > 0; --i)
            {
                for (int k = i - 1; k >= 0; --k)
                {
                    double x = matr[k][i];
                    List<double> temp_x = new List<double>(matr[i]);
                    for (int j = 0; j <= n; ++j)
                    {
                        temp_x[j] = temp_x[j] * x;
                        matr[k][j] = matr[k][j] - temp_x[j];
                    }
                }
            }

            List<double> ans = new List<double>();
            for (int i = 0; i < n; ++i)
                ans.Add(0.0);
            double t = 0.0;
            ans[n - 1] = matr[n - 1][n];
            for (int i = n - 2; i >= 0; --i)
                ans[i] = matr[i][n];
            return ans;
        }
    }

    public static class Painter
    {
        public static double LeftBorder = 0.0;
        public static double RightBorder = 3.0;
        public static double BottomBorder = -10.0;
        public static double TopBorder = 10.0;

        public static PowerPolynom Q1;
        public static PowerPolynom Q2;
        public static ChebyshevPolynom Q3;
        public static ChebyshevPolynom Q4;
        public static Function f;

        public static bool Drawf;
        public static bool DrawQ1;
        public static bool DrawQ2;
        public static bool DrawQ3;
        public static bool DrawQ4;

        public static void DrawFunction(IFunction f, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (double x = Painter.LeftBorder - 2; x < Painter.RightBorder + 2; x += 0.01)
                GL.Vertex2(x, f.ValueIn(x));
            GL.End();
        }
    }

    public abstract class IFunction
    {
        public abstract double ValueIn(double x);
    }

    public abstract class IPolynom:IFunction
    {
        protected List<double> _coef;
        protected int _pow;

        public IPolynom(int pow = 0)
        {
            _pow = pow;
            _coef = new List<double>();
            for (int i = 0; i <= _pow; ++i)
            {
                _coef.Add(0);
            }
        }

        public IPolynom(IPolynom ip)
        {
            _pow = ip._pow;
            _coef = new List<double>();
            for (int i = 0; i <= _pow; ++i)
            {
                _coef.Add(ip._coef[i]);
            }
        }

        public double Coef(int i)
        {
            if (i >= 0 && i <= _pow) return _coef[i];
            else return double.NaN;
        }
        public int Pow
        {
            get
            {
                return _pow;
            }
        }
    }

    public class PowerPolynom: IPolynom
    {
        public PowerPolynom(int pow = 0):
            base(pow)
        {
        }

        public PowerPolynom(List<double> coef)
        {
            _pow = coef.Count - 1;
            _coef = new List<double>(coef);
        }

        public PowerPolynom(PowerPolynom p)
        {
            _pow = p._pow;
            _coef = new List<double>();
            for (int i = 0; i <= _pow; ++i)
            {
                _coef.Add(p._coef[i]);
            }
        }
        public override double ValueIn(double x)
        {
            double powX = 1.0;
            double res = 0.0;
            for (int i = 0; i <= _pow; ++i)
            {
                res += powX * _coef[i];
                powX *= x;
            }
            return res;
        }
    }

    public class ChebyshevPolynom : IPolynom
    {
        private double _a;
        private double _b;

        public ChebyshevPolynom(double a, double b, int pow = 0) :
            base(pow)
        {
            _a = a; _b = b;
        }

        public ChebyshevPolynom(double a, double b, List<double> coef)
        {
            _pow = coef.Count - 1;
            _coef = new List<double>(coef);
            _a = a;
            _b = b;
        }

        public ChebyshevPolynom(ChebyshevPolynom p)
        {
            _pow = p._pow;
            _coef = new List<double>();
            for (int i = 0; i <= _pow; ++i)
            {
                _coef.Add(p._coef[i]);
            }
            _a = p._a;
            _b = p._b;
        }

        //we had calculated coeficients for t from [-1;1] but x is from [a,b]
        //then x = (b-a)*t/2 + (b + a)/2
        //t = (2*x - b - a)/(b-a)
        public override double ValueIn(double x)
        {
            double t = (2 * x - _b - _a) / (_b - _a);
            double res = 0.0;
            for (int i = 0; i <= _pow; ++i)
            {
                res += Calculator.Tn(i, t) * _coef[i];
            }
            return res;
        }
    }

    public class Function : IFunction
    {
        private int _k;
        private double _p;
        private double _c;
        private double _w;

        public Function(int k, double p, double c, double w)
        {
            _k = k; _p = p; _c = c; _w = w;
        }

        public override double ValueIn(double x)
        {
            return _k * Math.Pow(x, _p) + _c * Math.Sin(_w * x);
        }
    }
}

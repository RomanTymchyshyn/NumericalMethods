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
        bool ChebNodes = false;
        bool DrawWPolynom = false;
        double Y;
        List<double> X = new List<double>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ChebNodes == false)
            {
                Support.nodes.Clear();
                Support.nodes = Support.CalculateEqDistNodes(Support.A, Support.B, Support.N);
            }
            if (ChebNodes == true)
            {
                Support.nodes.Clear();
                Support.nodes = Support.CalculateChebNodes(Support.A, Support.B, Support.N);
            }
            StreamReader sr = new StreamReader("Input.txt");
            string str = sr.ReadLine();
            try
            {
                Y = Convert.ToDouble(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", str);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", str);
            }
            sr.Close();
            X.Add(Support.CalculateX(Y, -1.0, 0.0));
            X.Add(Support.CalculateX(Y, 0.0, 1.0));
            StreamWriter sw;
            FileInfo fi = new FileInfo("Output.txt");
            sw = fi.CreateText();
            sw.WriteLine("======================================");
            sw.Write("N = ");
            sw.WriteLine(Support.N);
            sw.Write("x*(1) = ");
            sw.WriteLine(X[0]);
            sw.Write("x*(2) = ");
            sw.WriteLine(X[1]);
            sw.WriteLine("y* = 1.(3)");
            sw.Write("f(x*(1)) = ");
            sw.WriteLine(Support.f(X[0]));
            sw.Write("f(x*(2)) = ");
            sw.WriteLine(Support.f(X[1]));
            sw.Close();
        }

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(Support.A - 2, Support.B + 2, Support.hMin, Support.hMax, -1, 1); // Bottom-left corner pixel has coordinate (-w, -h)
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
            for (int i = (int)Support.A - 2; i <= Support.B + 2; ++i)
            {
                GL.Vertex2(i, -0.05);
                GL.Vertex2(i, 0.05);
                GL.Vertex2(-0.05, i);
                GL.Vertex2(0.05, i);
            }
            GL.Vertex2(Support.A - 2, 0);
            GL.Vertex2(Support.B + 2, 0);
            GL.Vertex2(0, Support.hMin);
            GL.Vertex2(0, Support.hMax);
            GL.End();
            func func = new func(Support.f);
            Support.DrawFunctionF(func, Support.colorF);
            NewtonPolynom P = new NewtonPolynom(Support.P);
            List<double> f_values = new List<double>();
            for (int i = 0; i < Support.nodes.Count; ++i)
                f_values.Add(Support.f(Support.nodes[i]));
            Support.DrawFunctionP(P, Support.nodes, f_values, Support.colorP);
            if (DrawWPolynom == true)
            {
                wPolynom w = new wPolynom(Support.w);
                Support.DrawFunctionW(Support.w, Support.nodes, Support.colorW);
            }
            GL.PointSize(8.0f);
            GL.Begin(BeginMode.Points);
            for (int i = 0; i < X.Count; ++i)
                GL.Vertex2(X[i], Y);
            GL.End();
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

            label1.Visible = false;
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

        private void ChooseNodes_TextUpdate(object sender, EventArgs e)
        {
            ChooseNodes.Text = "Choose Type of nodes";
        }

        private void ChooseNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChooseNodes.Text = "Choose type of nodes";
        }

        private void EnterN_TextChanged(object sender, EventArgs e)
        {
        }

        private void Redraw_Click(object sender, EventArgs e)
        {
            if (EnterN.Text.Length >= 1 && Convert.ToInt32(EnterN.Text) > 0 && Convert.ToInt32(EnterN.Text) < 80) Support.N = Convert.ToInt32(EnterN.Text);
            if (ChooseNodes.Text == "Chebyshev Nodes")
            {
                ChebNodes = true;
            }
            if (ChooseNodes.Text == "Equally distant nodes")
            {
                ChebNodes = false;
            }
            if (ChebNodes == false)
            {
                Support.nodes.Clear();
                Support.nodes = Support.CalculateEqDistNodes(Support.A, Support.B, Support.N);
            }
            if (ChebNodes == true)
            {
                Support.nodes.Clear();
                Support.nodes = Support.CalculateChebNodes(Support.A, Support.B, Support.N);
            }
            X.Clear();
            X.Add(Support.CalculateX(Y, -1.0, 0.0));
            X.Add(Support.CalculateX(Y, 0.0, 1.0));
            StreamWriter sw;
            FileInfo fi = new FileInfo("Output.txt");
            sw = fi.AppendText();
            sw.WriteLine("======================================");
            sw.Write("N = ");
            sw.WriteLine(Support.N);
            sw.Write("x*(1) = ");
            sw.WriteLine(X[0]);
            sw.Write("x*(2) = ");
            sw.WriteLine(X[1]);
            sw.WriteLine("y* = 1.(3)");
            sw.Write("f(x*(1)) = ");
            sw.WriteLine(Support.f(X[0]));
            sw.Write("f(x*(2)) = ");
            sw.WriteLine(Support.f(X[1]));
            sw.Close();
        }

        private void DrawW_Click(object sender, EventArgs e)
        {
            DrawWPolynom = true;
        }

        private void NotDrawW_Click(object sender, EventArgs e)
        {
            DrawWPolynom = false;
        }
    }

    public delegate double wPolynom(double x, List<double> list_nodes);
    public delegate double func(double x);
    public delegate double NewtonPolynom(double x, List<double> list_nodes, List<double> func_values);

    public static class Support
    {
        public static double A = -2;
        public static double B = 3;
        public static double hMin = -5;
        public static double hMax = 5;
        public static Color colorF = Color.Red;
        public static Color colorP = Color.Green;
        public static Color colorW = Color.Blue;
        public static int N = 9;
        public static List<double> nodes = new List<double>();

        private static double Difference(List<double> func_values, params double[] values)
        {
            double sum = 0.0;
            for (int i = 0; i < values.Length; ++i)
            {
                double wn = 1.0;
                for (int j = 0; j < values.Length; ++j)
                {
                    if (j != i) wn *= (values[i] - values[j]);
                }
                sum = sum + func_values[i] / wn;
            }
            return sum;
        }

        public static double f(double x)
        {
            return (1 + Math.Abs(x*x - 1) - x*x);
        }
        public static double w(double x, List<double> list_nodes)
        {
            double res = 1.0;
            for (int i = 0; i < list_nodes.Count; ++i)
            {
                res *= (x - list_nodes[i]);
            }
            return res;
        }
        public static double P(double x, List<double> list_nodes, List<double> func_values)
        {
            double res = func_values[0];
            for (int i = 0; i < list_nodes.Count - 1; ++i)
            {
                double wn = 1.0;
                for (int j = 0; j <= i; ++j)
                {
                    wn *= (x - list_nodes[j]);
                }
                double[] vals = new double[i + 2];
                list_nodes.CopyTo(0, vals, 0, i + 2);
                wn *= Support.Difference(func_values, vals);
                res += wn;
            }
            return res;
        }

        public static List<double> CalculateEqDistNodes(double a, double b, int n)
        {
            List<double> res = new List<double>();
            res.Clear();
            res.Add(a);
            int i = 0;
            while (a + (i + 1) * (b - a) / n <= b)
            {
                res.Add(a + (i + 1) * (b - a) / n);
                ++i;
            }
            StreamWriter sw;
            FileInfo fi = new FileInfo(@"Output.txt");
            sw = fi.AppendText();
            for (int j = 0; j < res.Count; ++j)
            {
                sw.Write(res[j]);
                sw.Write(";  ");
            }
            sw.Close();
            res.Sort();
            return res;
        }

        public static List<double> CalculateChebNodes(double a, double b, int n)
        {
            List<double> res = new List<double>();
            double t = 0.0;
            res.Clear();
            for (int i = 0; i < n; ++i)
            {
                t = Math.Cos(((2*i+1)*Math.PI)/(2*n));
                res.Add((a + b + (b - a)*t)/2);
            }
            res.Sort();
            return res;
        }

        public static double CalculateX(double value, double a, double b)
        {
            int n = Support.N/3;
            List<double> func_values = CalculateEqDistNodes(a, b, n);
            List<double> list_nodes = new List<double>();
            for (int i = 0; i < func_values.Count; ++i)
                list_nodes.Add(Support.f(func_values[i]));
            double res = 0.0;
            res = P(value, list_nodes, func_values);
            return res;
        }

        public static void DrawFunctionW(wPolynom f, List<double> list_nodes, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (double x = -5.0; x < 5.0; x += 0.01)
                GL.Vertex2(x, f(x, list_nodes));
            GL.End();
        }
        public static void DrawFunctionP(NewtonPolynom f, List<double> list_nodes, List<double> values, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (double x = -15.0; x < 15.0; x += 0.01)
                GL.Vertex2(x, f(x, list_nodes, values));
            GL.End();
        }
        public static void DrawFunctionF(func f, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (double x = -5.0; x < 5.0; x += 0.01)
                GL.Vertex2(x, f(x));
            GL.End();
        }
    }
}

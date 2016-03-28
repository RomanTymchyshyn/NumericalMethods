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
using System.Threading;
using System.IO;

namespace MOLab4
{
    public partial class Form1 : Form
    {
        private ResultTable ResTable = new ResultTable();
        private ExactSolution ExactSol;
        private MeshFunction ApproximateSol;

        public Form1()
        {
            InitializeComponent();
        }

        private void Proc()
        {
            double a = Convert.ToDouble(a_textBox.Text);
            double b = Convert.ToDouble(b_textBox.Text);
            double c = Convert.ToDouble(c_textBox.Text);
            double d = Convert.ToDouble(d_textBox.Text);
            double k = Convert.ToDouble(k_textBox.Text);
            double n = Convert.ToDouble(n_textBox.Text);
            double EPS = Convert.ToDouble(EPS_textBox.Text);
            double h = Convert.ToDouble(h_textBox.Text);
            double l = Convert.ToDouble(l_textBox.Text);
            if (l < 0.0)
            {
                l = 0.0;
                l_textBox.Text = "0,0";
            }

            Painter.LeftBorder = -1;
            Painter.RightBorder = l + 1;
            Painter.BottomBorder = Convert.ToDouble(BottomBorder_TextBox.Text);
            Painter.TopBorder = Convert.ToDouble(TopBorder_TextBox.Text);
            SetupViewport();

            RightPart f = new RightPart(a, b, c, d, k, n);
            RHSFunc[] RHS = new RHSFunc[3] { delegate (double x, double[] PrevValues)
                                             { 
                                                return PrevValues[1]; 
                                             },
                                             delegate (double x, double[] PrevValues)
                                             {
                                                 return PrevValues[2];
                                             },
                                             delegate (double x, double[] PrevValues)
                                             {
                                                 return f.ValueIn(x) - k * x * PrevValues[2] - PrevValues[1] * PrevValues[1] - n * PrevValues[0];
                                             }
                                           };
            SystemOfEquations SE = new SystemOfEquations(3, 0, l, RHS, 1 + d, a + c, a * a + 2 * b);
            Runge4Solver solver = new Runge4Solver();
            List<double>[] solution = new List<double>[0];
            if (Step_comboBox.Text == "Auto") solution = solver.SolveAutoStep(SE, EPS);
            if (Step_comboBox.Text == "Fixed") solution = solver.SolveFixedStep(SE, h);
            ApproximateSol = new MeshFunction(solution[0], solution[1]);
            ExactSol = new ExactSolution(a, b, c, d);

            DataTable dt = new DataTable();
            dt.Columns.Add("Number of node");
            dt.Columns.Add("x (Node)");
            dt.Columns.Add("U(x) (Exact solution)");
            dt.Columns.Add("y(x) (Approximate solution)");
            dt.Columns.Add("y(x) - U(x)");
            for (int i = 0; i < (solution[0].Count < 50 ? solution[0].Count : 50); ++i)
            {
                DataRow row = dt.NewRow();
                row["Number of node"] = i + 1;
                row["x (Node)"] = solution[0][i * (solution[0].Count < 50 ? 1 : solution[0].Count / 50)];
                row["U(x) (Exact solution)"] = ExactSol.ValueIn(solution[0][i * (solution[0].Count < 50 ? 1 : solution[0].Count / 50)]);
                row["y(x) (Approximate solution)"] = solution[1][i * (solution[0].Count < 50 ? 1 : solution[0].Count / 50)];
                row["y(x) - U(x)"] = solution[1][i * (solution[0].Count < 50 ? 1 : solution[0].Count / 50)] - ExactSol.ValueIn(solution[0][i * (solution[0].Count < 50 ? 1 : solution[0].Count / 50)]);
                dt.Rows.Add(row);
            }
            DataRow r = dt.NewRow();
            r["Number of node"] = 51;
            r["x (Node)"] = solution[0][solution[0].Count - 1];
            r["U(x) (Exact solution)"] = ExactSol.ValueIn(solution[0][solution[0].Count - 1]);
            r["y(x) (Approximate solution)"] = solution[1][solution[0].Count - 1];
            r["y(x) - U(x)"] = solution[1][solution[0].Count - 1] - ExactSol.ValueIn(solution[0][solution[0].Count - 1]);
            dt.Rows.Add(r);
            r = dt.NewRow();
            r["Number of node"] = solution[0][solution[0].Count - 1] - solution[0][solution[0].Count - 2];
            dt.Rows.Add(r);
            ResTable.TableResult.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Proc();
        }

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(Painter.LeftBorder, Painter.RightBorder, Painter.BottomBorder, Painter.TopBorder, -1, 1); // Bottom-left corner pixel has coordinate (-w, -h)
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
            for (int i = (int)Painter.LeftBorder; i <= Painter.RightBorder; ++i)
            {
                if (Painter.BottomBorder <= 0 && Painter.TopBorder >= 0)
                {
                    GL.Vertex2(i, -0.1);
                    GL.Vertex2(i, 0.1);
                }
                if (Painter.BottomBorder > 0)
                {
                    GL.Vertex2(i, Painter.BottomBorder - 0.1);
                    GL.Vertex2(i, Painter.BottomBorder + 0.1);
                }
                if (Painter.TopBorder < 0)
                {
                    GL.Vertex2(i, Painter.TopBorder - 0.1);
                    GL.Vertex2(i, Painter.TopBorder + 0.1);
                }
            }
            for (int i = (int)Painter.BottomBorder; i <= Painter.TopBorder; ++i)
            {
                if (Painter.LeftBorder <= 0 && Painter.RightBorder >= 0)
                {
                    GL.Vertex2(-0.1, i);
                    GL.Vertex2(0.1, i);
                }
                if (Painter.LeftBorder > 0)
                {
                    GL.Vertex2(Painter.LeftBorder, i);
                    GL.Vertex2(Painter.LeftBorder + 0.1, i);
                }
                if (Painter.RightBorder < 0)
                {
                    GL.Vertex2(Painter.RightBorder, i);
                    GL.Vertex2(Painter.LeftBorder - 0.1, i);
                }
            }
            GL.Vertex2(Painter.LeftBorder, 0);
            GL.Vertex2(Painter.RightBorder, 0);
            GL.Vertex2(0, Painter.BottomBorder);
            GL.Vertex2(0, Painter.TopBorder);
            GL.End();
            if (Painter.DrawExact == true && ExactSol != null) Painter.DrawFunction(ExactSol, Painter.ExactColor);
            if (Painter.DrawApprox == true && ApproximateSol != null) Painter.DrawMeshFunction(ApproximateSol, Painter.ApproxColor);
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
            GL.ClearColor(Color.SkyBlue);
            SetupViewport();
            Application.Idle += Application_Idle;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            simpleOpenGlControl1.Invalidate();
        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void DrawExactSol_Click(object sender, EventArgs e)
        {
            Painter.DrawExact = !Painter.DrawExact;
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            Proc();
        }

        private void DrawApprox_Click(object sender, EventArgs e)
        {
            Painter.DrawApprox = !Painter.DrawApprox;
        }

        private void ShowResult_button_Click(object sender, EventArgs e)
        {
            ResTable.ShowDialog(this);
        }
    }

    public static class Painter
    {
        public static double LeftBorder = 0.0;
        public static double RightBorder = 3.0;
        public static double BottomBorder = 0.0;
        public static double TopBorder = 10.0;

        public static bool DrawExact = true;
        public static bool DrawApprox = true;
        public static Color ExactColor = Color.Red;
        public static Color ApproxColor = Color.ForestGreen;

        public static void DrawFunction(IFunction f, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (double x = Painter.LeftBorder - 2; x < Painter.RightBorder + 2; x += 0.01)
                GL.Vertex2(x, f.ValueIn(x));
            GL.End();
        }
        public static void DrawMeshFunction(MeshFunction f, Color color)
        {
            GL.PointSize(5.0f);
            GL.Color3(color);
            GL.Begin(BeginMode.LineStrip);
            for (int i = 0; i < f.QuantityOfNodes; ++i)
                GL.Vertex2(f.X(i), f.Y(i));
            GL.End();
        }
    }

    public abstract class IFunction
    {
        public abstract double ValueIn(double x);
    }

    //objects are functions from our equation with different parameters
    public class RightPart : IFunction
    {
        private double _a;
        private double _b;
        private double _c;
        private double _d;
        private double _k;
        private double _n;

        public RightPart(double a, double b, double c, double d, double k, double n)
        {
            _a = a; _b = b; _c = c; _d = d; _k = k; _n = n;
        }
        public RightPart(RightPart f)
        {
            _a = f._a; _b = f._b; _c = f._c; _d = f._d; _k = f._k; _n = f._n;
        }

        public override double ValueIn(double x)
        {
            return Math.Pow((_a * Math.Exp(_a * x) + 2 * _b * x + _c), 2.0) + Math.Exp(_a * x) * (_a * _a * _a + _n + _k * _a * _a * x) + _n * _b * x * x + x * (2 * _k * _b + _n * _c) + _d * _n;
        }
    }

    public delegate double RHSFunc(double x, double[] PrevValue);

    //objects are solutions of the our equation with different parameters
    public class ExactSolution: IFunction
    {
        private double _a;
        private double _b;
        private double _c;
        private double _d;

        public ExactSolution(double a, double b, double c, double d)
        {
            _a = a; _b = b; _c = c; _d = d;
        }
        public ExactSolution(ExactSolution f)
        {
            _a = f._a; _b = f._b; _c = f._c; _d = f._d;
        }

        public override double ValueIn(double x)
        {
            return Math.Exp(_a * x) + _b * x * x + _c * x + _d;
        }
    }

    public class MeshFunction
    {
        private List<double> _x;
        private List<double> _y;

        public MeshFunction(List<double> x, List<double> y)
        {
            if (x.Count == y.Count)
            {
                _x = new List<double>(x);
                _y = new List<double>(y);
            }
            else
            {
                throw new BadProgrammerException("Number of nodes and function values are different");
            }
        }
        public MeshFunction(MeshFunction f)
        {
            _x = new List<double>(f._x);
            _y = new List<double>(f._y);
        }

        public double X(int NumberOfNode)
        {
            return _x[NumberOfNode];
        }
        public double Y(int NumberOfNode)
        {
            return _y[NumberOfNode];
        }
        public int QuantityOfNodes
        {
            get
            {
                return _x.Count;
            }
        }
    }

    public class SystemOfEquations
    {
        private int _n;//number of equations
        private double _a;//left end
        private double _b;//right end
        private double[] _InitialConditions;//0-f1,1-f2,2-f3...

        private RHSFunc[] _RHS;

        public double a
        {
            get
            {
                return _a;
            }
        }
        public double b
        {
            get
            {
                return _b;
            }
        }
        public int n
        {
            get
            {
                return _n;
            }
        }
        public int NumberOfInitialCond
        {
            get
            {
                return _InitialConditions.Length;
            }
        }
        
        /* NumOfFunc:
         * 0-f1,1-f2,2-f3...
         */
        public double InitialCondition(int NumOfFunc)
        {
            return _InitialConditions[NumOfFunc];
        }

        public SystemOfEquations()
        {
            _n = 0;
            _InitialConditions = new double[_n];
            _a = 0;
            _b = 0;
            _RHS = new RHSFunc[0];
        }
        public SystemOfEquations(int n, double a, double b, RHSFunc[] RightParts, params double[] InitialConditions)//last parameters - function, first derivative, second ...
        {
            _n = n;
            _a = a;
            _b = b;
            _InitialConditions = new double[InitialConditions.Length];
            for (int i = 0; i < InitialConditions.Length; ++i)
                _InitialConditions[i] = InitialConditions[i];
            _RHS = new RHSFunc[n];
            for (int i = 0; i < RightParts.Length; ++i)
                _RHS[i] = new RHSFunc(RightParts[i]);
            for (int i = RightParts.Length; i < _n; ++i)
                _RHS[i] = new RHSFunc(delegate { return 0.0; });
        }
        public SystemOfEquations(SystemOfEquations SE)
        {
            _n = SE.n;
            _a = SE.a;
            _b = SE.b;
            _InitialConditions = new double[SE._InitialConditions.Length];
            for (int i = 0; i < SE._InitialConditions.Length; ++i)
            {
                _InitialConditions[i] = SE._InitialConditions[i];
            }
            _RHS = new RHSFunc[n];
            for (int i = 0; i < n; ++i)
                _RHS[i] = new RHSFunc(SE._RHS[i]);
        }

        /* This function returns Fi(x, PrevValues), where Fi - right part from i-th equation */
        public double RHS(int NumOfEq, double x, double[] PrevValues)
        {
            return _RHS[NumOfEq](x, PrevValues);
        }
    }

    public abstract class IRungeTypeSolver
    {
        protected double[] Alpha;
        protected double[][] Beta;
        protected double[] p;

        public abstract double[] NextStep(double Prevnode, double h, double[] PrevValues, SystemOfEquations SE);
        /* This function returns array which contains values of the function, which is the solution of the equation, and it's derivatives
         * in each row of massive are values of function or her derivative in some point
         * for example array[0][3] - value of the function in x3
         * array[1][0] - value of the first derivative of the function in point x0
         */
        public List<double>[] SolveAutoStep(SystemOfEquations SE, double eps)
        {
            if (SE.n > SE.NumberOfInitialCond) throw new BadProgrammerException("Number of initial conditions is less than number of equations");
            List<double>[] Solution = new List<double>[SE.n + 1];
            for (int i = 0; i <= SE.n; ++i)
            {
                Solution[i] = new List<double>();
                if (i != 0) Solution[i].Add(SE.InitialCondition(i - 1));
                else Solution[i].Add(SE.a);
            }
            double t = SE.a;
            int n = 0;
            double dt = (SE.b - SE.a)/2.0;
            double delta = 0.25 * eps / 16.0;
            while (t < SE.b)
            {
                double dev = 2 * eps;
                double[] y1 = new double[0];
                double[] y2 = new double[0];
                while (dev > eps)
                {
                    dt /= 2.0;
                    double[] Prev = new double[SE.n];
                    for (int i = 1; i <= SE.n; ++i)
                        Prev[i - 1] = Solution[i][n];
                    //make two steps (h = dt)
                    y1 = NextStep(t, dt, Prev, SE);
                    y2 = NextStep(t + dt, dt, y1, SE);
                    //make one step (h = 2*dt)
                    y1 = NextStep(t, 2 * dt, Prev, SE);
                    dev = 0.0;
                    //dev = max(y1[i] - y2[i])
                    for (int i = 0; i < SE.n; ++i)
                        if (Math.Abs(y1[i] - y2[i]) >= dev) dev = Math.Abs(y1[i] - y2[i]);
                }
                t += 2 * dt;
                ++n;
                Solution[0].Add(t);
                for (int i = 1; i <= SE.n; ++i)
                    Solution[i].Add(y1[i - 1]);
                if (dev <= delta) dt *= 2;
            }
            return Solution;
        }
        public List<double>[] SolveFixedStep(SystemOfEquations SE, double h)
        {
            if (SE.n > SE.NumberOfInitialCond) throw new BadProgrammerException("Number of initial conditions is less than number of equations");
            List<double>[] Solution = new List<double>[SE.n + 1];
            for (int i = 0; i <= SE.n; ++i)
            {
                Solution[i] = new List<double>();
                if (i != 0) Solution[i].Add(SE.InitialCondition(i - 1));
                else Solution[i].Add(SE.a);
            }
            double t = SE.a;
            int n = 0;
            while (t < SE.b)
            {
                double[] y = new double[0];
                double[] Prev = new double[SE.n];
                for (int i = 1; i <= SE.n; ++i)
                    Prev[i - 1] = Solution[i][n];
                y = NextStep(t, h, Prev, SE);
                t += h;
                ++n;
                Solution[0].Add(t);
                for (int i = 1; i <= SE.n; ++i)
                    Solution[i].Add(y[i - 1]);
            }
            return Solution;
        }
    }

    public class Runge4Solver : IRungeTypeSolver
    {
        public Runge4Solver()
        {
            Alpha = new double[4] { 0.0, 0.5, 0.5, 1.0 };
            Beta = new double[4][] { new double[1] { 0.0 }, new double[1] { 0.5 }, new double[2] { 0.0, 0.5 }, new double[3] { 0.5, 0.0, 1.0 } };
            p = new double[4] { 1.0 / 6.0, 1.0 / 3.0, 1.0 / 3.0, 1.0 / 6.0 };
        }

        public override double[] NextStep(double Prevnode, double h, double[] PrevValues, SystemOfEquations SE)
        {
            int N = SE.n;
            double[] res = new double[SE.n];
            for (int j = 0; j < N; ++j)
                res[j] = PrevValues[j];
            double[,] k = new double[N, 4];

            for (int i = 0; i < 4; ++i)
            {
                double ksi = Prevnode + Alpha[i] * h;
                double[] eta = new double[N];
                for (int j = 0; j < N; ++j)
                {
                    eta[j] += PrevValues[j];
                    for (int t = 0; t < i; ++t)
                        eta[j] += Beta[i][t] * h * k[j, t];
                }
                for (int j = 0; j < N; ++j)
                {
                    k[j, i] = h * SE.RHS(j, ksi, eta);
                    res[j] += p[i] * k[j, i];
                }
            }
            return res;
        }
    }

    public class EilerSolver : IRungeTypeSolver
    {
        public override double[] NextStep(double Prevnode, double h, double[] PrevValues, SystemOfEquations SE)
        {
            int N = SE.n;
            double[] res = new double[SE.n];
            double[,] k = new double[N, 4];

            for (int j = 0; j < N; ++j)
            {
                res[j] = PrevValues[j] + h * SE.RHS(j, Prevnode, PrevValues);
            }
            return res;
        }
    }

    public class EilerKoshiSolver : IRungeTypeSolver
    {
        public EilerKoshiSolver()
        {
            Alpha = new double[2] { 0.0, 1.0 };
            Beta = new double[2][] { new double[1] { 0.0 }, new double[1] { 1.0 } };
            p = new double[2] { 1.0 / 2.0, 1.0 / 2.0 };
        }

        public override double[] NextStep(double Prevnode, double h, double[] PrevValues, SystemOfEquations SE)
        {
            int N = SE.n;
            double[] res = new double[SE.n];
            for (int j = 0; j < N; ++j)
                res[j] = PrevValues[j];
            double[,] k = new double[N, 2];

            for (int i = 0; i < 2; ++i)
            {
                double ksi = Prevnode + Alpha[i] * h;
                double[] eta = new double[N];
                for (int j = 0; j < N; ++j)
                {
                    eta[j] += PrevValues[j];
                    for (int t = 0; t < i; ++t)
                        eta[j] += Beta[i][t] * h * k[j, t];
                }
                for (int j = 0; j < N; ++j)
                {
                    k[j, i] = h * SE.RHS(j, ksi, eta);
                    res[j] += p[i] * k[j, i];
                }
            }
            return res;
        }
    }

    public class BadProgrammerException : Exception
    {
        public BadProgrammerException(){}

        public BadProgrammerException(string message)
            : base(message)
        {
        }

        public BadProgrammerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

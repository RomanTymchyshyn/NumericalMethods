#include <fstream>
#include "Matrix.h"
#include "Eigenvalues.h"
#include "Non-linear.h"
#define EPS 0.000001

using namespace std;

int main()
{
	Matrix<double> matr;
	ifstream fi("Input.txt");
	fi>>matr;
	double max = 0.0;
	double min = 0.0;
	vector<double> maxV;
	vector<double> minV;
	ofstream fo("Output.txt", ios::trunc);
	int precision = (log(1.0/EPS)/log(10.0)) < 7 ? 7 : (log(1.0/EPS)/log(10.0));
	fo.precision(precision);
	fo<<">>>>>>>>>>>>Minimal and maximal eigenvalues<<<<<<<<<<<<<\n";
	fo<<"Matrix:\n";
	fo<<matr;
	fo<<endl;
	MinMaxEValues<double>(matr, max, min, maxV, minV, EPS, fo);

	fo<<endl<<endl;

	fo<<">>>>>>>>>>>>Finding spectrum of the matrix by the method of Jacobi<<<<<<<<<<.\n";
	fo<<"Matrix:\n";
	fo<<matr;
	fo<<endl;
	Matrix<double> L = matr.Jacobi(EPS);
	fo<<"Matrix lambda:\n";
	fo<<L;
	fo<<endl;
	vector<double> evalues;
	for (int i = 0; i < L.size(); ++i)
		evalues.push_back(L[i][i]);
	fo<<"Eigenvalues of the matrix: "<<evalues;
	fo<<endl<<endl;

	fo<<">>>>>>>>>>>>Solvering non-linear systems by the method of Newton<<<<<<<<<<<<<.\n";
	fo<<"f(x,y) = 0.7x - siny/3 - 2 = 0\ng(x,y) = 1.1x + 2y - sin(x/5) + 1\n";
	double x_sol = 0.0;
	double y_sol = 0.0;
	double startX = 1.5;
	double startY = -1.0;
	Newton(startX, startY, x_sol, y_sol, EPS, fo);
	fo<<"Solution of the equation: x = "<<x_sol<<"; y = "<<y_sol<<endl;
	fo<<"f(x,y) = "<<f(x_sol, y_sol)<<endl;
	fo<<"g(x,y) = "<<g(x_sol, y_sol)<<endl;

	fo.close();
	return 0;
}
#include <fstream>
#include "Matrix.h"
#define EPS 0.00001

using namespace std;

int main()
{
	ifstream fi("MatrixInput.txt");
	ofstream fo("Output.txt");
	fo.precision(15);
	Matrix<double> A;
	fi>>A;
	vector<double> right_part;
	fi.close();
	fi.open("RightPartInput.txt");
	if (!fi.is_open())
	{
		fo<<"Bad input file!\n";
		return 0;
	}
	fi>>right_part;
	fo<<endl<<"A:\n";
	fo<<A;
	fo<<"b"<<" = ( ";
	for (int i = 0; i < right_part.size() - 1; ++i)
		fo<<right_part[i]<<", ";
	fo<<right_part[right_part.size() - 1]<<" )\n";
	Matrix<double> inverse;
	vector<double> answer;
	vector<double> r;
	Matrix<double> C;
	fo<<endl<<"================================================================================================="<<endl;
	fo<<"Gauss."<<endl;
	answer = A.Gauss(right_part,inverse,fo);
	fo<<endl<<"Answer"<<" = ( ";
	for (int i = 0; i < answer.size() - 1; ++i)
		fo<<answer[i]<<", ";
	fo<<answer[answer.size() - 1]<<" )\n";
	r = A * answer;
	r = r - right_part;
	fo<<endl<<"Discrepancy r = Ax - b"<<" = ( ";
	for (int i = 0; i < r.size() - 1; ++i)
		fo<<r[i]<<", ";
	fo<<r[r.size() - 1]<<" )\n";
	fo<<endl<<"Determinant:\n"<<A.Det();
	fo<<endl;
	fo<<endl<<"A^(-1):\n"<<inverse;
	fo<<endl;
	fo<<endl<<"Condition:\n"<<A.Norm()*inverse.Norm();
	fo<<endl;
	C = A*inverse;
	fo<<endl<<"A*A^(-1):\n"<<C;
	fo<<endl;
	fo<<endl<<"================================================================================================="<<endl;
		fo<<endl<<"================================================================================================="<<endl;
	fo<<"Square roots."<<endl;
	answer = A.SqRoots(right_part, inverse, fo);
	fo<<endl<<"Answer"<<" = ( ";
	for (int i = 0; i < answer.size() - 1; ++i)
		fo<<answer[i]<<", ";
	fo<<answer[answer.size() - 1]<<" )\n";
	fo<<endl;
	r = A * answer;
	r = r - right_part;
	fo<<endl<<"Discrepancy r = Ax - b"<<" = ( ";
	for (int i = 0; i < r.size() - 1; ++i)
		fo<<r[i]<<", ";
	fo<<r[r.size() - 1]<<" )\n";
	fo<<endl<<"Determinant:\n"<<A.Det();
	fo<<endl;
	fo<<endl<<"A^(-1):\n"<<inverse;
	fo<<endl;
	fo<<endl<<"Condition:\n"<<A.Norm()*inverse.Norm();
	fo<<endl;
	C = A*inverse;
	fo<<endl<<"A*A^(-1):\n"<<C;
	fo<<endl;
	fo<<endl<<"================================================================================================="<<endl;
	fo<<"Method of simple iteration."<<endl;
	answer = A.SimpleIteration(right_part, EPS, fo);
	fo<<endl<<"Answer"<<" = ( ";
	for (int i = 0; i < answer.size() - 1; ++i)
		fo<<answer[i]<<", ";
	fo<<answer[answer.size() - 1]<<" )\n";
	fo<<endl;
	r = A * answer;
	r = r - right_part;
	fo<<endl<<"Discrepancy r = Ax - b"<<" = ( ";
	for (int i = 0; i < r.size() - 1; ++i)
		fo<<r[i]<<", ";
	fo<<r[r.size() - 1]<<" )\n";
	return 0;
}
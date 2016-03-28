#pragma once
#include<vector>
#include<fstream>
#include"Matrix.h"
#include <cmath>

using namespace std;

template<class T>
void MinMaxEValues(Matrix<T> m, T & max, T & min, vector<T> & maxV, vector<T> & minV, const double & eps, ostream & o)
{
	int precision = (log(1.0/eps)/log(10.0)) < 7 ? 7 : (log(1.0/eps)/log(10.0));
	o.precision(precision);
	maxV.clear();
	minV.clear();
	max = (T)0;
	min = (T)0;
	int size = m.size();
	if (size < 1) return;
	if (size == 1)
	{
		max = m[0][0];
		min = max;
		maxV.push_back((T)1);
		minV.push_back((T)1);
		return;
	}

	o<<"At first lets find maximal eigenvalue for our matrix.\n";

	PowMethod(m, max, maxV, eps, o);

	o<<"Maximal eigenvalue of matrix A is "<<max<<endl;
	o<<"And eigenvector for this value is:\n";
	o<<maxV;
	o<<"\n\n";

	Matrix<T> E = unitMatr<T>(size);
	T norm = m.NormMaxSumRow();
	Matrix<T> R = E*norm;
	Matrix<T> B = E*norm - m;

	T maxB = (T)0;
	vector<T> maxBVect;

	o<<"And now lets find maximal eigenvalue for matrix B = Norm(A)*E - A, where E - unit matrix.\n";
	o<<"Then the minimum eigenvalue of the matrix will be lambda_maxA = Norm(A) - lambda_maxB\n";

	PowMethod(B, maxB, maxBVect, eps, o);

	o<<"Maximal eigenvalue of matrix B is "<<maxB<<endl;
	o<<"And eigenvector for this value is:\n";
	o<<maxV;
	o<<"\n\n";

	min = m.NormMaxSumRow() - maxB;
	minV = maxBVect*(-1.0);

	o<<"And now we can calculate minimal eigenvalue of our matrix.\n";
	o<<"Minimal eigenvalue of matrix A is "<<min<<endl;
	o<<"And eigenvector for this value is:\n";
	o<<minV;
	o<<"\n\n";

	o<<"lambda_min = "<<min<<"\t"<<"And eigenvector:\t"<<minV;
	o<<endl;
	o<<"lambda_max = "<<max<<"\t"<<"And eigenvector:\t"<<maxV;
	o<<endl;

	return;
};

template<class T>
void PowMethod(Matrix<T> A, T & max, vector<T> & maxV, const double & eps, ostream & o)
{
	int precision = (log(1.0/eps)/log(10.0)) < 7 ? 7 : (log(1.0/eps)/log(10.0));
	o.precision(precision);
	maxV.clear();
	max = (T)0;
	int size = A.size();
	if (size < 1) return;
	if (size == 1)
	{
		max = A[0][0];
		maxV.push_back((T)1);
		return;
	}

	vector<T> StartApprox(size, (T)1);
	T alpha1 = A[0]*StartApprox;
	int tempind = 0;
	while(alpha1 < (T)0.0000001)
	{
		++StartApprox[tempind];
		if (tempind == size - 1) tempind = -1;
		++tempind;
		alpha1 = A[0]*StartApprox;
	}

	o<<"Start Approximation (x0):\n";
	o<<StartApprox;
	o<<"\n\n";

	T newValue = (T)0;
	T oldValue = (T)0;

	vector<T> oldVector = StartApprox*(1.0/NormVectAvg(StartApprox));
	vector<T> newVector = A*oldVector;

	o<<"x1 = A * x0:\n";
	o<<newVector;
	o<<endl;

	oldValue = newVector[0] / oldVector[0];
	newValue = oldValue;

	o<<"lambda0 = "<<newValue<<endl<<endl;

	int numberOfIter = 1;
	do
	{
		oldValue = newValue;
		oldVector = newVector;
		newVector = A*oldVector;

		o<<"x"<<numberOfIter + 1<<" = A * x"<<numberOfIter<<";\n";
		o<<newVector;
		o<<endl;

		newValue = newVector[0] / oldVector[0];

		o<<"lambda"<<numberOfIter<<" = "<<newValue<<endl<<endl;

		newVector = newVector*(1.0/NormVectAvg(newVector));

		++numberOfIter;
	}
	while (fabs(newValue - oldValue) >= eps);

	o<<"Maximal eigenvalue finded.\nNumber of Iterations = "<<numberOfIter<<endl;

	max = newValue;
	maxV = newVector;
	return;
}
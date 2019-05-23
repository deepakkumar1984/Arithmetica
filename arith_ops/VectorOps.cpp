#include "VectorOps.h"
#include <iostream>
#include <omp.h>
OPS_API INLINE_FUNC int V_Fill(float* r, float value, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = value;
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Add(const float* a, const float* b, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = a[i] + b[i];
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Sub(const float* a, const float* b, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = a[i] - b[i];
	}
}

OPS_API INLINE_FUNC int V_Mul(const float* a, const float* b, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = a[i] * b[i];
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Div(const float* a, const float* b, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = a[i] / b[i];
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Sin(const float* x, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = sinf(x[i]);
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Cos(const float* x, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = cos(x[i]);
	}

	return 0;
}

OPS_API INLINE_FUNC int V_Tan(const float* x, float* r, int n)
{
#pragma omp parallel for num_threads(8)
	for (int i = 0; i < n; ++i)
	{
		r[i] = tan(x[i]);
	}

	return 0;
}

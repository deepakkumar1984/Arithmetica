#include "Vector_Comp.h"

OPS_API int COMP_Add(_complex *result, _complex *lhs, _complex *rhs)
{
	auto n = sizeof(lhs);
	for (int i = 0; i < n; i++)
	{
		result[i].x = lhs[i].x + rhs[i].x;
		result[i].y = lhs[i].y + rhs[i].y;
	}
}

OPS_API int COMP_Sub(_complex *result, _complex *lhs, _complex *rhs)
{
	auto n = sizeof(lhs);
	for (int i = 0; i < n; i++)
	{
		result[i].x = lhs[i].x - rhs[i].x;
		result[i].y = lhs[i].y - rhs[i].y;
	}
}

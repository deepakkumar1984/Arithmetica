#pragma once

#include "General.h"
#include <cmath>

OPS_API INLINE_FUNC int V_Fill(float* x, float value, int n);

OPS_API INLINE_FUNC int V_Add(const float* a, const float* b, float* r, int n);
OPS_API INLINE_FUNC int V_Sub(const float* a, const float* b, float* r, int n);
OPS_API INLINE_FUNC int V_Mul(const float* a, const float* b, float* r, int n);
OPS_API INLINE_FUNC int V_Div(const float* a, const float* b, float* r, int n);

OPS_API INLINE_FUNC int V_Sin(const float* x, float* r, int n);
OPS_API INLINE_FUNC int V_Cos(const float* x, float* r, int n);
OPS_API INLINE_FUNC int V_Tan(const float* x, float* r, int n);


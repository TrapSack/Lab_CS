#pragma once

using namespace std;

extern "C" __declspec(dllexport) double __stdcall plus(double a, double b);
extern "C" __declspec(dllexport) double __cdecl minus(double a, double b);
extern "C" __declspec(dllexport) double WINAPI multi(double a, double b);
extern "C" __declspec(dllexport) double __cdecl divide(double a, double b);

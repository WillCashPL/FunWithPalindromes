// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchmarkTests.Core;

var summary = BenchmarkRunner.Run<PalindromesCheckerBenchmark>();
// See https://aka.ms/new-console-template for more information
using SSLDotNetInternshipTraining.Dapper;

Console.WriteLine("Hello, World!");

DapperSample dapperSample = new DapperSample();


dapperSample.Edit();
dapperSample.Create();
dapperSample.Update();
dapperSample.Delete();
dapperSample.Read();
// See https://aka.ms/new-console-template for more information
using SSLDotNetInternshipTraining.AdoDotNet;

Console.WriteLine("Hello, World!");

AdoSample adoSample = new AdoSample();
adoSample.Create();
adoSample.Read();
adoSample.Edit();
adoSample.Update();
adoSample.Delete();


Console.ReadLine();

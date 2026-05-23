// See https://aka.ms/new-console-template for more information
using SSLDotNetInternshipTraining.EFCore.Model;

Console.WriteLine("Hello, World!");

EFCoreModel eFCoreModel = new EFCoreModel();
eFCoreModel.Create();
eFCoreModel.Update();
eFCoreModel.Edit();
eFCoreModel.Read();
eFCoreModel.Delete();

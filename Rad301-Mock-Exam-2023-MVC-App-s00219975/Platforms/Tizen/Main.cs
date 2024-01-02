using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Rad301_Mock_Exam_2023_MVC_App_s00219975
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using UI.Models;

namespace UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        List<Utility> types = new List<Utility>();

        var dir = "D:\\dlls";

        foreach (var assemblyPath in Directory.GetFiles(dir, "*.Utility.dll"))
        {
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Type[] assemblyTypes = assembly.GetTypes();          
            foreach (var type in assemblyTypes)
            {
                if (typeof(IUtility).IsAssignableFrom(type) && type.GetCustomAttribute<UtilityAttribute>() != null)
                {
                    types.Add(new Utility(type));
                }
            }
        }

        InitializeComponent();
        List.ItemsSource = types;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var util = List.SelectedItem as Utility;
        if (util != null)
        {
            var result = util.Execute();

            string takenMessage = string.Empty;
            takenMessage += $"\n--------------RUNNING--------------\nUtility name: \"{util.Name}\"\n";
            var startTime = DateTime.Now;
            takenMessage += $"Message: {result}\n";
            takenMessage += $"Execution time: {DateTime.Now.Subtract(startTime)}\n---------------!-!-!---------------\n";
            LoggerBox.Text += takenMessage;
        }
    }
}

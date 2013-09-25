using HangeulRomaniser.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HangeulRomaniser.Console
{
    /// <summary>
    /// This represents the main entry point of the program entity.
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        public static void Main(string[] args)
        {
            ShowSplash();
            try
            {
                ProcessRequests(args);
                System.Console.WriteLine();
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("ERROR:");
                sb.AppendLine();
                sb.AppendLine(ex.Message);
                sb.AppendLine();
                sb.AppendLine(ex.StackTrace);

                System.Console.WriteLine(sb.ToString());

                if (ex.GetType() != typeof(ArgumentException))
                    return;

                System.Console.WriteLine();
                ShowUsage();
            }
        }

        /// <summary>
        /// Shows the splash message.
        /// </summary>
        private static void ShowSplash()
        {
            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("{0} v{1}", fvi.ProductName, fvi.FileVersion));
            sb.AppendLine("------------------------------");

            System.Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Shows the usage of the app message.
        /// </summary>
        private static void ShowUsage()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Usage:");
            sb.AppendLine("  HangeulRomaniser.Console.exe /i:[input] /o:[output]");
            sb.AppendLine();
            sb.AppendLine("Parameter:");
            sb.AppendLine("  /i:input:  Input filename.");
            sb.AppendLine("  /o:output: Output filename.");
            sb.AppendLine();

            System.Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Processes the requests based on the argument provided.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        private static void ProcessRequests(IList<string> args)
        {
            if (args == null || !args.Any())
                throw new ArgumentException("No argument found");

            var parameter = GetParameter(args);
            var service = new RomaniserService();

            var list = service.ReadFile(parameter.Input);
            var results = service.RomaniseInBulk(list);
            service.SaveFile(parameter.Output, results);
        }

        /// <summary>
        /// Gets the parameter instance.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        /// <returns>Returns the parameter instance.</returns>
        private static Parameter GetParameter(IEnumerable<string> args)
        {
            var parameter = new Parameter();
            foreach (var arg in args)
            {
                if (arg.ToLower().StartsWith("/i:"))
                    parameter.Input = arg.Replace("/i:", "");
                else if (arg.ToLower().StartsWith("/o:"))
                    parameter.Output = arg.Replace("/o:", "");
            }
            if (String.IsNullOrWhiteSpace(parameter.Input))
                throw new ArgumentException("No input file specified");
            if (String.IsNullOrWhiteSpace(parameter.Output))
                throw new ArgumentException("No output file specified");
            return parameter;
        }

        #endregion Methods
    }

    /// <summary>
    /// This represents the parameter entity.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Gets or sets the input filepath.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the output filepath.
        /// </summary>
        public string Output { get; set; }
    }
}
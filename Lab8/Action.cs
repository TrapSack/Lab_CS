using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    delegate double OperationDelegate(double x, double y);
    delegate void showHandler(string OperationName);
    class Action
    {
        public event showHandler Showing = (OperationName) => { };
        
        private Dictionary<string, OperationDelegate> _operations;
        private List<string> _operationName;
        public Action ()
        {
            _operations = new Dictionary<string, OperationDelegate>();
            _operationName = new List<string>();
            _operations.Add("addition", (x,y) => x + y);
            _operationName.Add("addition");
            _operations.Add("subtraction", (x, y) => x - y);
            _operationName.Add("subtraction");
            _operations.Add("multipcation", (x, y) => x * y);
            _operationName.Add("multipcation");
            _operations.Add("Division", (x, y) => x / y);
            _operationName.Add("Division");
        }
        
        public void AddOperation(string operationName, OperationDelegate operation)
        {
            _operations.Add(operationName, operation);
            _operationName.Add(operationName);
        }

        public void RemoveOperation(string operationName)
        {
            _operations.Remove(operationName);
            _operationName.Remove(operationName);
        }

        public double DoOperation(string operationName, double x, double y)
        {
            try
            {
                return _operations[operationName](x, y);
            }
            catch(Exception ex)
            {
                Showing(ex.ToString());
                return 0;
            }
        }
        public void GetNameOperations(showHandler whereToGet)
        {
            Showing += whereToGet;
            foreach (string s in _operationName)
            {
                Showing(s);
            }
            
        } 
        public void GetNameOperations()
        {
            foreach (string s in _operationName)
            {
                Showing(s);
            }

        }
        private double DoDivision(double x, double y) { return x / y; }
        private double DoMultiplication(double x, double y) { return x * y; }
        private double DoSubtraction(double x, double y) { return x - y; }
        private double DoAddition(double x, double y) { return x + y; }

        private static void Display(string name)
        {
            Console.WriteLine(name);
        }

       
    }
}

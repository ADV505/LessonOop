namespace LessonOop
{
    class CalculatorEventArgs : EventArgs
    {
        public double answer;
    }

    class Calculator
    {
        public event EventHandler<CalculatorEventArgs> Result;
        private double result = 0;
        Stack<double> results = new Stack<double>();

        private void StartEvent()
        {
            Result?.Invoke(this, new CalculatorEventArgs { answer = result });
        }

        public void Add(double value)
        {
            results.Push(result);
            result += value;
            StartEvent();
        }
        public void Sub(double value)
        {
            results.Push(result);
            result -= value;
            StartEvent();
        }
        public void Mul(double value)
        {
            results.Push(result);
            result *= value;
            StartEvent();
        }
        public void Div(double value)
        {
            results.Push(result);
            result /= value;
            StartEvent();
        }

       

        public void Cancel()
        {
            if (results.Count > 0)
            {
                result = results.Pop();
                StartEvent();
            }
        }
    }
}

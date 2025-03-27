
namespace WpfApp1
{
    internal class ApiService
    {
        private string v;

        public ApiService(string v)
        {
            this.v = v;
        }

        internal async Task UpdateTaskAsync(MainWindow.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
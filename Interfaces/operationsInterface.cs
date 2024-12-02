using azure_test.Data;
using azure_test.Models;

namespace azure_test.Interfaces
{
    public interface operationsInterface
    {
        

        public  Task<List<operationsModel>> ListOperations();
        public  Task<string> calculateOperation(operationsModel o);

        public decimal operations(operationsModel o);
    }
}

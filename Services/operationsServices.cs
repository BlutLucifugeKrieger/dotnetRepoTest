using azure_test.Data;
using azure_test.Interfaces;
using azure_test.Models;

namespace azure_test.Services
{
    public class operationsServices : operationsInterface
    {

        private readonly azure_testContext _context;


        public operationsServices(azure_testContext context)
        {
            _context = context;
        }

        public async Task<string> calculateOperation(operationsModel o)
        {
            var result = operations(o);

            _context.operationsModel.Add(o);
           
            await _context.SaveChangesAsync();

            return $"Operation result = {result}";


        }

        public async Task<List<operationsModel>> ListOperations()
        {

            var result = _context.operationsModel.ToList();
            return result;
            
        }

        public decimal operations(operationsModel o)
        {
            decimal sum = 0;

            if (o.OPERATION == "+")
            {
                sum = o.FIRSTNUMBER + o.SECONDNUMBER;
                

            }
            else if (o.OPERATION == "-")
            {
                sum = o.FIRSTNUMBER - o.SECONDNUMBER;
               
            }
            else if (o.OPERATION == "*")
            {
                sum = o.FIRSTNUMBER * o.SECONDNUMBER;
               

            }else if(o.OPERATION == "/")
            {
                sum = o.FIRSTNUMBER / o.SECONDNUMBER;
               
            }

            o.RESULT = sum;

            return sum;

                
        }
    }
}

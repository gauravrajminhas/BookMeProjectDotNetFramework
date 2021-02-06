using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicValidationLayer
{
    class testClass
    {
        
       public void dosomething()
       {
            item a = new chair();
            furnituer x = new chair();




            a.price();
            x.price();
            x.getMaterial();

       }

    }
    
   



    public interface item
    {
        float price();
        
    }


    public interface furnituer : item
    {
        string getMaterial();
    }



    public class chair : furnituer
    {
        public string getMaterial()
        {
            throw new NotImplementedException();
        }

        public float price()
        {
            throw new NotImplementedException();
        }
    }








}

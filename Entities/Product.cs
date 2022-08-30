using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /*
     * this serializable class models product data that includes product id, product name, price and in-stock status
     */

    public class Product
    {
        /*
         * define properties for Product model attributes 
         */
        /*
         * Override ToString() method to return string equivalent of product object containing product details
         */

         public int ProductID { get;set;}
         public string ProductName { get;set;}
         public float ProductPrice { get;set;}
         public bool InStock { get;set;}

        public override string ToString()
        {
            return $"ProductID : {ProductID}, ProductName : {ProductName} , ProductPrice : {ProductPrice} , Instock : {InStock}";
        }



    }
}

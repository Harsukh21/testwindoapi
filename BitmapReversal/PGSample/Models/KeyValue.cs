using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
	* 2017 Abzer Technology Solutions  Sample Class for Bitmap request string creation
	*  
	*  NOTICE OF LICENSE
	*  File Name : KeyValue.cs 
	*  For creating Bitmap request string
	*  DISCLAIMER
	*  
	* 
	*  @author Abzer Developers <info@abzer.com>
	*  @copyright  Abzer Developers
	*  @license   
	*  
*/
namespace PGSample.Models
{
    public class KeyValue
    {
        public KeyValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
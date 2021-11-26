using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dashboard.Shared
{
    public class Raw : IRaw
    {

        //public string _location { get; set; }
        //public string _group { get; set; }
        [Key]
        public int _id { get; set; }
        public string _language { get; set; }
        public string _marquee { get; set; }
        public string _ismining { get; set; }
        public string _hasreached { get; set; }
        public string _h1 { get; set; }
        public string _h2 { get; set; }
        public string _worker { get; set; }
        public string _rank { get; set; }
        public string _name { get; set; }
        public string _current { get; set; }
        public string _total { get; set; }
        public string _payload { get; set; }


        //public string Location()
        //{
        //    return _location;
        //}
        //public string Group()
        //{
        //    return _group;
        //}

        public int Id()
        {
            return _id;
        }
        public string Language()
        {
            return _language;
        }
        public string Marquee()
        {
            return _marquee;
        }
        public string Ismining()
        {
            return _ismining;
        }
        public string Hasreached()
        {
            return _hasreached;
        }
        public string H1()
        {
            return _h1;
        }
        public string H2()
        {
            return _h2;
        }
        public string Worker()
        {
            return  _worker;
        }
        public string Rank()
        {
            return  _rank;
        }
        public string Name()
        {
            return _name;
        }
        public string Current()
        {
            return _current;
        }
        public string Total()
        {
            return _total;
        }
        public string Payload()
        {
            return _payload;
        }
//public string ()
//        {
//    return;
//    }
    }
}

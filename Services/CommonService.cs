using InventoryControl.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Services
{
    public class CommonService : Controller
    {
        private readonly InventoryControlContext _context;
        public CommonService(InventoryControlContext context)
        {
            _context = context;
        }

        public string GetIndonesianDateFormat(DateTime dateTime)
        {
            return dateTime.Day + " " + GetFullMonth(dateTime.Month) + " " + dateTime.Year;
        }

        public string GetSimpleIndonesianDateFormat(DateTime dateTime)
        {
            return dateTime.Day + " " + GetShortMonth(dateTime.Month) + " " + dateTime.Year;
        }

        public string GetFullMonth(int month) {
            var strMonth = "";
            switch (month)
            {
                case 1: strMonth = "Januari";break;
                case 2: strMonth = "Februari";break;
                case 3: strMonth = "Maret";break;
                case 4: strMonth = "April";break;
                case 5: strMonth = "Mei";break;
                case 6: strMonth = "Juni";break;
                case 7: strMonth = "Juli";break;
                case 8: strMonth = "Agustus";break;
                case 9: strMonth = "September";break;
                case 10: strMonth = "Oktober";break;
                case 11: strMonth = "November";break;
                case 12: strMonth = "Desember";break;
            }

            return strMonth;
        }

        public string GetShortMonth(int month)
        {
            var strMonth = "";
            switch (month)
            {
                case 1: strMonth = "Jan"; break;
                case 2: strMonth = "Feb"; break;
                case 3: strMonth = "Mar"; break;
                case 4: strMonth = "Apr"; break;
                case 5: strMonth = "Mei"; break;
                case 6: strMonth = "Jun"; break;
                case 7: strMonth = "Jul"; break;
                case 8: strMonth = "Agu"; break;
                case 9: strMonth = "Sep"; break;
                case 10: strMonth = "Okt"; break;
                case 11: strMonth = "Nov"; break;
                case 12: strMonth = "Des"; break;
            }

            return strMonth;
        }
    }
}

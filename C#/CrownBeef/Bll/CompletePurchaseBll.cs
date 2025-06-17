using Dto;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class CompletePurchaseBll : IBll.IBllCompletePurchase
    {
        private readonly IDal.IDalCompletePurchase dal;

        public CompletePurchaseBll(IDal.IDalCompletePurchase dal)
        {
            this.dal = dal;
        }
        //int בגלל שהפונקציה מחזירה 
        // catch ו try בדיקות שגיאה של
        //כרגע אין פה תוספת לוגיקה
        public async Task<int> AddCompletePurchaseAsync(CompletePurchaseDto completePurchaseDto)
        {
            try
            {
                completePurchaseDto.PurchaseAmount = sumPayment(completePurchaseDto.PurchaseAmount, completePurchaseDto.CurrentUser.DateOfBirth);
                return await dal.AddCompletePurchaseAsync(completePurchaseDto);
            }
            catch (ArgumentException ex)
            {
                // טיפול בשגיאות הקשורות למוצר
                throw new Exception($"שגיאה בהוספת רכישה: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // טיפול בשגיאות הקשורות למלאי
                throw new Exception($"שגיאה בהוספת רכישה: {ex.Message}");
            }
        }
        //פונקציה שבודקת את התאריך של החודש היום לעומת תאריך החודש של
        //המשתמש אם זה אותו חודש יש לו הנחת יום הולדת של עשר אחוז
        public int sumPayment(int sum, string dateOnly)
        {
            DateOnly dateOfBirth = DateOnly.ParseExact(dateOnly, "yyyy-MM-dd");

            if (dateOfBirth.Month == DateTime.Now.Month)
            {
                sum = (int)(sum * 0.9);
            }
            return sum;
        }
    }
}

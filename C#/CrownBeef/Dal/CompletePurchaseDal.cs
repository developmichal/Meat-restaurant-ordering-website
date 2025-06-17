using Dal.models;
using Dto;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class CompletePurchaseDal : IDal.IDalCompletePurchase
    {
        private readonly CrownBeefContext db;

        public CompletePurchaseDal(CrownBeefContext db)
        {
            this.db = db;
        }

        public async Task<int> AddCompletePurchaseAsync(CompletePurchaseDto completePurchaseDto)
        {
            //שלב שלא נעשה - בדיקה אם נשארו פריטים בקניה שאפשרים לקניה מבחינת מלאי ורק אם כן נמשיך
            //או לחילופין מראש שנלף ללקוח מוצר נשלף גם הכמות במלאי ואז לא ניתן להזמנין יותר בצד הלקוח
            //ונותרה רק בעיה גמר מלאי מזמן הצגת המוצר לזמן הקניה בפועל
            //יוצרת משתנה מסוג טבלת קנייה
            var purchaseEntity = new Purchase
            {
                CustomerCode = completePurchaseDto.CurrentUser.CustomerCode,
                //מגדירה את הקנייה על התאריך העכשוי
                PurchaseDate = DateOnly.FromDateTime(DateTime.Now),
                PurchaseAmount = completePurchaseDto.PurchaseAmount,
                Note = completePurchaseDto.Note
            };
            //מוסיפה לטבלת קניות ושומרת
            db.Purchases.Add(purchaseEntity);
            await db.SaveChangesAsync();
            //עוברת על המערך הנוכחי של המוצרים שהמשתמש הוסיף לסל קניות שלו באנגולר
            foreach (var product in completePurchaseDto.Products)
            {
                //ייוצרת משתנה מסוג טבלת פרטי קניות
                var purchaseDetails = new PurchaseDetail
                {
                    // שולפת את הקוד שהוא יצר לי למעלה בטבלת קניות 
                    PurchaseCode = purchaseEntity.PurchaseCode,
                    ProductCode = product.ProductCode,
                    Amount = product.Quantity
                };
                // שולפת את המוצר לפי הקוד
                var productEntity = await db.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode);
                // ובודקת אם יש לי מספיק כמות מהמוצר אם לא מחזירה שגיאה
                if (productEntity.QuantityInStock < product.Quantity)
                {
                    throw new InvalidOperationException("המלאי אינו מספיק!");
                }
                //אם כן מעדכנת את הכמות של המוצר פחות הכמות שהמשתמש קנה
                productEntity.QuantityInStock -= product.Quantity;
                //ומעדכנת את התאריך עדכון אחרון כתאריך העכשוי
                productEntity.LastUpdateDate = DateOnly.FromDateTime(DateTime.Now);
                //מוסיפה לטבלת פרטי קניה ושומרת
                db.PurchaseDetails.Add(purchaseDetails);
            }

            await db.SaveChangesAsync();
            //מחזירה למשתמש את קוד הקנייה הכולל
            return purchaseEntity.PurchaseCode;
        }
    }
}

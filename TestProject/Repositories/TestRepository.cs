using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Repositories
{
    public class TestRepository : ITestRepository
    {
        public Response GetParkingFee(string entry, string exit)
        {
            try
            {
                /* Normal bir projede parametreleri Datetime türünde alabilirdik. Fakat console uygulaması istediğiniz ve 
                orada tüm inputlar string alınıp convert edildiğinden string almayı tercih ettim. */
                var entryDate = Convert.ToDateTime(entry);
                var exitDate = Convert.ToDateTime(exit);

                if (entryDate > exitDate)//Giriş tarihi çıkış saatinden büyükse
                {
                    exitDate = entryDate.AddDays(1).Date;//giriş tarihinin bir sonraki günü saat 00:00 ı exitDate olarak ayarla.
                }

                //iki tarih arasındaki toplam dk sayısını bul
                var minute = GetMinute(entryDate, exitDate);

                return new Response
                {
                    Fee = GetFee(minute) + " TL",
                    Time = (int)(minute / 60) + " Saat " + (minute % 60) + " Dakika"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// İki tarih arasındaki toplam dk sayısını döner.
        /// </summary>
        /// <param name="entryDate"></param>
        /// <param name="exitDate"></param>
        /// <returns></returns>
        private double GetMinute(DateTime entryDate, DateTime exitDate)
        {
            return (exitDate - entryDate).TotalMinutes;
        }

        /// <summary>
        /// Girilen dk değerine göre otopark ücretini hesaplar. Recursive çalışır.
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        private double GetFee(double minute)
        {
            if (minute > 360)//6 saatten fazla
            {
                return GetFee(360) + 5 * Math.Ceiling((minute - 360) / 180);
            }
            if (minute > 180)//3 saatten fazla
            {
                return GetFee(180) + 2 * Math.Ceiling((minute - 180) / 60);
            }
            return 3 * Math.Ceiling(minute / 60);
        }
    }
}

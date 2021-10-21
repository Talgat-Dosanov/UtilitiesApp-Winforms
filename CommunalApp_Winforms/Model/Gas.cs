using System;

namespace CommunalApp_Winforms.Model
{
    [Serializable]
    public class Gas
    {
        public string ServiceName { get; private set; }
        /// <summary>
        /// Цена газа за кубический метр
        /// </summary>
        public double PriceForOne { get; set; }

        /// <summary>
        /// Итоговая цена в рублях
        /// </summary>
        public double ResultPrice { get; set; }
        /// <summary>
        /// Количество куб. метр газа
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// Текущее показание счетчика
        /// </summary>
        public int VolumeNow { get; set; }
        /// <summary>
        /// Дата начала отсчета
        /// </summary>
        public DateTime FromDate { get; set; }
        /// <summary>
        /// Дата конца отсчета
        /// </summary>
        public DateTime ToDate { get; set; }
        /// <summary>
        /// Количество дней
        /// </summary>
        public TimeSpan CountDays { get; set; }
        /// <summary>
        /// Расчет стоимости газа за указанный период времени
        /// </summary>
        /// <param name="price"></param>
        /// <param name="volume"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public Gas(string serviceName, double priceForOne, int volumeLast, int volumeNow, DateTime fromDate, DateTime toDate)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new ArgumentNullException("Имя is null or empty", nameof(serviceName));
            }
            if (priceForOne <= 0)
            {
                throw new ArgumentException("Цена не может быть равна или меньше нуля", nameof(priceForOne));
            }
            if (volumeLast >= volumeNow || volumeNow <= 0)
            {
                throw new ArgumentException("Текущие показания счетчика не могут быть равны нулю или быть меньше предыдущих", nameof(volumeNow));
            }
            if (fromDate >= toDate || toDate > DateTime.Now)
            {
                throw new ArgumentException("Некорректная дата", nameof(fromDate));
            }
            #endregion
            ServiceName = serviceName;
            Volume = volumeNow - volumeLast;
            VolumeNow = volumeNow;
            CountDays = toDate - fromDate;
            PriceForOne = priceForOne;
            ResultPrice = priceForOne * Volume;
            FromDate = fromDate;
            ToDate = toDate;
        }
        public override string ToString()
        {
            return ResultPrice.ToString();
        }
    }
}

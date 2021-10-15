using System;

namespace CommunalApp_Winforms.Model
{
    [Serializable]
    public class Electricity
    {
        /// <summary>
        /// Цена электричества за кВт
        /// </summary>
        public double PriceForOne { get; set; }

        /// <summary>
        /// Итоговая цена в рублях
        /// </summary>
        public double ResultPrice { get; set; }
        /// <summary>
        /// Количество кВт электроэнергии
        /// </summary>
        public double Volume { get; set; }
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
        /// Расчет стоимости электричества за указанный период времени
        /// </summary>
        /// <param name="price"></param>
        /// <param name="volume"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public Electricity(double priceForOne, double volumeLast, double volumeNow,  DateTime fromDate, DateTime toDate)
        {
            #region Проверка
            if (priceForOne <= 0)
            {
                throw new ArgumentException("Цена не может быть равна или меньше нуля", nameof(priceForOne));
            }
            if (volumeNow <= 0)
            {
                throw new ArgumentException("Количество электроэнергии не может быть равен или меньше нуля", nameof(volumeNow));
            }
            if (fromDate >= DateTime.Now || fromDate <= DateTime.Parse("2010.01.01") || fromDate >= toDate)
            {
                throw new ArgumentException("Некорректная дата", nameof(toDate));
            }
            if (toDate >= DateTime.Now || toDate <= DateTime.Parse("2010.01.01"))
            {
                throw new ArgumentException("Некорректная дата", nameof(toDate));
            }
            #endregion

            Volume = volumeNow - volumeLast;
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

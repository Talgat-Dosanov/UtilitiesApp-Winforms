﻿using System;

namespace CommunalApp_Winforms.Model
{
    [Serializable]
    public class Water
    {
        /// <summary>
        /// Цена воды за кубический метр
        /// </summary>
        public double Price { get; private set; }
        /// <summary>
        /// Объем воды в метрах кубических
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
        public TimeSpan CountDays { get; }
        /// <summary>
        /// Расчет стоимости воды за указанный период времени
        /// </summary>
        /// <param name="price"></param>
        /// <param name="volume"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public Water(double price, double volume, DateTime fromDate, DateTime toDate)
        {
            #region Проверка
            if (price <= 0)
            {
                throw new ArgumentException("Цена не может быть равна или меньше нуля", nameof(price));
            }
            if (volume <= 0)
            {
                throw new ArgumentException("Объем не может быть равен или меньше нуля", nameof(volume));
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
            Volume = volume;
            CountDays = toDate - fromDate;
            Price = price * volume * CountDays.Days;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public override string ToString()
        {
            return Price.ToString() + "Руб/куб.м";
        }
    }
}
